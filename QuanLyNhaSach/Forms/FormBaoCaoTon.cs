using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using System.IO;
using OfficeOpenXml;

namespace QuanLyNhaSach
{
    public partial class FormBaoCaoTon : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormBaoCaoTon()
        {
            InitializeComponent();
        }

        private void FormBaoCaoTon_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = DateTime.Now.Month - 1;
            numNam.Value = DateTime.Now.Year;

            // Tự động xem báo cáo tháng hiện tại
            btnXemBaoCao_Click(null, null);

            // Cho phép nhấn F5 để cập nhật báo cáo
            this.KeyPreview = true;
            this.KeyDown += (s, ke) => {
                if (ke.KeyCode == Keys.F5)
                {
                    ke.Handled = true;
                    RefreshReport();
                }
            };
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int thang = cboThang.SelectedIndex + 1;
            int nam = (int)numNam.Value;

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM BaoCaoTon WHERE Thang = @Thang AND Nam = @Nam";
                int count = Convert.ToInt32(db.ExecuteScalar(checkQuery,
                    new SqlParameter[] {
                        new SqlParameter("@Thang", thang),
                        new SqlParameter("@Nam", nam)
                    }));

                if (count == 0)
                {
                    DialogResult result = MessageBox.Show(
                        $"Chưa có báo cáo tồn kho tháng {thang}/{nam}.\nBạn có muốn tạo báo cáo mới không?",
                        "Tạo báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        TaoBaoCaoTon(thang, nam, showSuccess: true);
                    }
                    else
                    {
                        dgvBaoCaoTon.DataSource = null;
                        lblTongTonDau.Text = "📦 Tổng tồn đầu: 0";
                        lblTongPhatSinh.Text = "📈 Tổng phát sinh: 0";
                        lblTongTonCuoi.Text = "💰 Tổng tồn cuối: 0";
                        return;
                    }
                }

                DisplayReport(thang, nam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── NÚT LÀM MỚI ──────────────────────────────────────────
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void DisplayReport(int thang, int nam)
        {
            string query = @"SELECT 
                                s.MaSach,
                                s.TenSach,
                                tl.TenTheLoai,
                                s.TacGia,
                                bct.TonDau,
                                bct.PhatSinh,
                                bct.TonCuoi
                             FROM BaoCaoTon bct 
                             JOIN Sach s ON bct.MaSach = s.MaSach
                             LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                             WHERE bct.Thang = @Thang AND bct.Nam = @Nam
                             ORDER BY bct.TonCuoi DESC";

            DataTable dt = db.ExecuteQuery(query,
                new SqlParameter[] {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                });

            dgvBaoCaoTon.DataSource = dt;
            FormatDataGridView();
            UpdateSummary(dt);
        }

        /// <summary>
        /// Tạo báo cáo tồn kho bằng cách tính từ dữ liệu thực tế (PhieuNhap, HoaDon).
        /// </summary>
        /// <param name="showSuccess">True = hiện MessageBox thành công; False = im lặng (dùng khi gọi từ RefreshReport).</param>
        private void TaoBaoCaoTon(int thang, int nam, bool showSuccess = true)
        {
            try
            {
                DataTable dtSach = db.ExecuteQuery("SELECT MaSach, SoLuongTon FROM Sach");

                foreach (DataRow row in dtSach.Rows)
                {
                    int maSach = Convert.ToInt32(row["MaSach"]);

                    // Tồn cuối tháng trước → tồn đầu tháng này
                    object tonDauObj = db.ExecuteScalar(
                        @"SELECT TonCuoi FROM BaoCaoTon 
                          WHERE MaSach = @MaSach AND Thang = @ThangTruoc AND Nam = @NamTruoc",
                        new SqlParameter[] {
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@ThangTruoc", thang == 1 ? 12 : thang - 1),
                            new SqlParameter("@NamTruoc",  thang == 1 ? nam - 1 : nam)
                        });

                    int tonDau = tonDauObj != null ? Convert.ToInt32(tonDauObj) : Convert.ToInt32(row["SoLuongTon"]);

                    // Số lượng nhập trong tháng
                    object nhap = db.ExecuteScalar(
                        @"SELECT ISNULL(SUM(ct.SoLuong), 0) 
                          FROM CT_PhieuNhap ct
                          JOIN PhieuNhap pn ON ct.MaPhieuNhap = pn.MaPhieuNhap
                          WHERE ct.MaSach = @MaSach
                            AND MONTH(pn.NgayNhap) = @Thang AND YEAR(pn.NgayNhap) = @Nam",
                        new SqlParameter[] {
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@Thang", thang),
                            new SqlParameter("@Nam", nam)
                        });

                    // Số lượng bán trong tháng
                    object ban = db.ExecuteScalar(
                        @"SELECT ISNULL(SUM(ct.SoLuong), 0) 
                          FROM CT_HoaDon ct
                          JOIN HoaDon hd ON ct.MaHD = hd.MaHD
                          WHERE ct.MaSach = @MaSach
                            AND MONTH(hd.NgayLapHD) = @Thang AND YEAR(hd.NgayLapHD) = @Nam",
                        new SqlParameter[] {
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@Thang", thang),
                            new SqlParameter("@Nam", nam)
                        });

                    int phatSinh = Convert.ToInt32(nhap) - Convert.ToInt32(ban);
                    int tonCuoi = tonDau + phatSinh;

                    db.ExecuteNonQuery(
                        @"INSERT INTO BaoCaoTon (Thang, Nam, MaSach, TonDau, PhatSinh, TonCuoi) 
                          VALUES (@Thang, @Nam, @MaSach, @TonDau, @PhatSinh, @TonCuoi)",
                        new SqlParameter[] {
                            new SqlParameter("@Thang",    thang),
                            new SqlParameter("@Nam",      nam),
                            new SqlParameter("@MaSach",   maSach),
                            new SqlParameter("@TonDau",   tonDau),
                            new SqlParameter("@PhatSinh", phatSinh),
                            new SqlParameter("@TonCuoi",  tonCuoi)
                        });
                }

                if (showSuccess)
                    MessageBox.Show($"✅ Đã tạo báo cáo tồn kho tháng {thang}/{nam} thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FormatDataGridView()
        {
            if (dgvBaoCaoTon.Columns.Count == 0) return;

            dgvBaoCaoTon.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvBaoCaoTon.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvBaoCaoTon.Columns["TenTheLoai"].HeaderText = "Thể Loại";
            dgvBaoCaoTon.Columns["TacGia"].HeaderText = "Tác Giả";
            dgvBaoCaoTon.Columns["TonDau"].HeaderText = "Tồn Đầu";
            dgvBaoCaoTon.Columns["PhatSinh"].HeaderText = "Phát Sinh";
            dgvBaoCaoTon.Columns["TonCuoi"].HeaderText = "Tồn Cuối";

            dgvBaoCaoTon.Columns["TonDau"].DefaultCellStyle.Format = "N0";
            dgvBaoCaoTon.Columns["PhatSinh"].DefaultCellStyle.Format = "N0";
            dgvBaoCaoTon.Columns["TonCuoi"].DefaultCellStyle.Format = "N0";

            dgvBaoCaoTon.Columns["TonDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoTon.Columns["PhatSinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoTon.Columns["TonCuoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBaoCaoTon.Columns["MaSach"].Width = 80;
            dgvBaoCaoTon.Columns["TenSach"].Width = 250;
            dgvBaoCaoTon.Columns["TenTheLoai"].Width = 120;
            dgvBaoCaoTon.Columns["TacGia"].Width = 150;
            dgvBaoCaoTon.Columns["TonDau"].Width = 100;
            dgvBaoCaoTon.Columns["PhatSinh"].Width = 100;
            dgvBaoCaoTon.Columns["TonCuoi"].Width = 100;

            // Tô màu phát sinh và tồn cuối thấp (đăng ký 1 lần)
            dgvBaoCaoTon.RowPrePaint -= DgvBaoCaoTon_RowPrePaint;
            dgvBaoCaoTon.RowPrePaint += DgvBaoCaoTon_RowPrePaint;
        }

        private void DgvBaoCaoTon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvBaoCaoTon.Rows[e.RowIndex];

            object phatSinhObj = row.Cells["PhatSinh"].Value;
            int phatSinh = phatSinhObj != null && phatSinhObj != DBNull.Value ? Convert.ToInt32(phatSinhObj) : 0;

            row.Cells["PhatSinh"].Style.ForeColor = phatSinh >= 0
                ? Color.FromArgb(46, 204, 113)   // xanh lá
                : Color.FromArgb(231, 76, 60);    // đỏ

            object tonCuoiObj = row.Cells["TonCuoi"].Value;
            int tonCuoi = tonCuoiObj != null && tonCuoiObj != DBNull.Value ? Convert.ToInt32(tonCuoiObj) : 0;
            row.Cells["TonCuoi"].Style.BackColor = tonCuoi < 20
                ? Color.FromArgb(255, 243, 224)   // cam nhạt
                : Color.White;
        }

        private void UpdateSummary(DataTable dt)
        {
            int tongTonDau = 0, tongPhatSinh = 0, tongTonCuoi = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongTonDau += row["TonDau"] != DBNull.Value ? Convert.ToInt32(row["TonDau"]) : 0;
                tongPhatSinh += row["PhatSinh"] != DBNull.Value ? Convert.ToInt32(row["PhatSinh"]) : 0;
                tongTonCuoi += row["TonCuoi"] != DBNull.Value ? Convert.ToInt32(row["TonCuoi"]) : 0;
            }

            lblTongTonDau.Text = $"📦 Tổng tồn đầu: {tongTonDau:N0}";
            lblTongPhatSinh.Text = $"📈 Tổng phát sinh: {tongPhatSinh:N0}";
            lblTongTonCuoi.Text = $"💰 Tổng tồn cuối: {tongTonCuoi:N0}";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoTon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"BaoCaoTon_{cboThang.SelectedIndex + 1}_{numNam.Value}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(saveDialog.FileName);
                    MessageBox.Show("✅ Xuất báo cáo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("BáoCáoTồnKho");
                int thang = cboThang.SelectedIndex + 1;
                int nam = (int)numNam.Value;

                // Tiêu đề
                worksheet.Cells[1, 1].Value = $"BÁO CÁO TỒN KHO - THÁNG {thang}/{nam}";
                worksheet.Cells[1, 1].Style.Font.Size = 14;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 7].Merge = true;

                // Ngày xuất
                worksheet.Cells[2, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells[2, 1].Style.Font.Size = 10;

                // Header
                string[] headers = { "Mã Sách", "Tên Sách", "Thể Loại", "Tác Giả", "Tồn Đầu", "Phát Sinh", "Tồn Cuối" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[4, i + 1].Value = headers[i];
                    worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[4, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Dữ liệu
                int row = 5;
                foreach (DataGridViewRow dgRow in dgvBaoCaoTon.Rows)
                {
                    if (dgRow.IsNewRow) continue;

                    worksheet.Cells[row, 1].Value = dgRow.Cells["MaSach"].Value ?? "";
                    worksheet.Cells[row, 2].Value = dgRow.Cells["TenSach"].Value ?? "";
                    worksheet.Cells[row, 3].Value = dgRow.Cells["TenTheLoai"].Value ?? "";
                    worksheet.Cells[row, 4].Value = dgRow.Cells["TacGia"].Value ?? "";
                    worksheet.Cells[row, 5].Value = dgRow.Cells["TonDau"].Value ?? 0;
                    worksheet.Cells[row, 6].Value = dgRow.Cells["PhatSinh"].Value ?? 0;
                    worksheet.Cells[row, 7].Value = dgRow.Cells["TonCuoi"].Value ?? 0;

                    // Format số
                    worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[row, 6].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[row, 7].Style.Numberformat.Format = "#,##0";

                    row++;
                }

                // Tổng cộng
                row += 1;
                worksheet.Cells[row, 1].Value = "TỔNG CỘNG";
                worksheet.Cells[row, 1].Style.Font.Bold = true;
                worksheet.Cells[row, 5].Value = lblTongTonDau.Text.Replace("📦 Tổng tồn đầu: ", "").Replace(",", "");
                worksheet.Cells[row, 6].Value = lblTongPhatSinh.Text.Replace("📈 Tổng phát sinh: ", "").Replace(",", "");
                worksheet.Cells[row, 7].Value = lblTongTonCuoi.Text.Replace("💰 Tổng tồn cuối: ", "").Replace(",", "");

                worksheet.Cells[row, 5].Style.Font.Bold = true;
                worksheet.Cells[row, 6].Style.Font.Bold = true;
                worksheet.Cells[row, 7].Style.Font.Bold = true;
                worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[row, 6].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[row, 7].Style.Numberformat.Format = "#,##0";

                // Tự động điều chỉnh độ rộng cột
                worksheet.Column(1).Width = 12;
                worksheet.Column(2).Width = 30;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 18;
                worksheet.Column(5).Width = 12;
                worksheet.Column(6).Width = 12;
                worksheet.Column(7).Width = 12;

                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void lbT_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Xóa dữ liệu báo cáo tháng được chọn rồi tính lại từ đầu theo giao dịch thực tế.
        /// </summary>
        public void RefreshReport()
        {
            int thang = cboThang.SelectedIndex + 1;
            int nam = (int)numNam.Value;

            try
            {
                // Khoá nút trong khi cập nhật
                btnLamMoi.Enabled = false;
                btnLamMoi.Text = "⏳ Đang cập nhật...";

                db.ExecuteNonQuery(
                    "DELETE FROM BaoCaoTon WHERE Thang = @Thang AND Nam = @Nam",
                    new SqlParameter[] {
                        new SqlParameter("@Thang", thang),
                        new SqlParameter("@Nam",   nam)
                    });

                TaoBaoCaoTon(thang, nam, showSuccess: false);
                DisplayReport(thang, nam);

                MessageBox.Show($"✅ Báo cáo tồn kho tháng {thang}/{nam} đã được cập nhật!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi cập nhật báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLamMoi.Enabled = true;
                btnLamMoi.Text = "🔄 Làm Mới";
            }
        }
    }
}
