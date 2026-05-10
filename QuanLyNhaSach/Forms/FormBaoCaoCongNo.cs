using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using System.IO;

namespace QuanLyNhaSach
{
    public partial class FormBaoCaoCongNo : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormBaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void FormBaoCaoCongNo_Load(object sender, EventArgs e)
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
                string checkQuery = "SELECT COUNT(*) FROM BaoCaoCongNo WHERE Thang = @Thang AND Nam = @Nam";
                int count = Convert.ToInt32(db.ExecuteScalar(checkQuery,
                    new SqlParameter[] {
                        new SqlParameter("@Thang", thang),
                        new SqlParameter("@Nam",   nam)
                    }));

                if (count == 0)
                {
                    DialogResult result = MessageBox.Show(
                        $"Chưa có báo cáo công nợ tháng {thang}/{nam}.\nBạn có muốn tạo báo cáo mới không?",
                        "Tạo báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        TaoBaoCaoCongNo(thang, nam, showSuccess: true);
                    }
                    else
                    {
                        dgvBaoCaoCongNo.DataSource = null;
                        lblTongNoDau.Text = "📊 Tổng nợ đầu: 0 VNĐ";
                        lblTongPhatSinh.Text = "📈 Tổng phát sinh: 0 VNĐ";
                        lblTongNoCuoi.Text = "💰 Tổng nợ cuối: 0 VNĐ";
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
                                kh.MaKH,
                                kh.HoTen,
                                kh.DiaChi,
                                bccn.NoDau,
                                bccn.PhatSinh,
                                bccn.NoCuoi
                             FROM BaoCaoCongNo bccn 
                             JOIN KhachHang kh ON bccn.MaKH = kh.MaKH
                             WHERE bccn.Thang = @Thang AND bccn.Nam = @Nam
                             ORDER BY bccn.NoCuoi DESC";

            DataTable dt = db.ExecuteQuery(query,
                new SqlParameter[] {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam",   nam)
                });

            dgvBaoCaoCongNo.DataSource = dt;
            FormatDataGridView();
            UpdateSummary(dt);
        }

        /// <summary>
        /// Tạo báo cáo công nợ bằng cách tính từ dữ liệu thực tế (HoaDon, PhieuThu).
        /// </summary>
        /// <param name="showSuccess">True = hiện MessageBox thành công; False = im lặng (dùng khi gọi từ RefreshReport).</param>
        private void TaoBaoCaoCongNo(int thang, int nam, bool showSuccess = true)
        {
            try
            {
                DataTable dtKH = db.ExecuteQuery("SELECT MaKH, SoTienNo FROM KhachHang");

                foreach (DataRow row in dtKH.Rows)
                {
                    int maKH = Convert.ToInt32(row["MaKH"]);

                    // Nợ cuối tháng trước → nợ đầu tháng này
                    object noDauObj = db.ExecuteScalar(
                        @"SELECT NoCuoi FROM BaoCaoCongNo 
                          WHERE MaKH = @MaKH AND Thang = @ThangTruoc AND Nam = @NamTruoc",
                        new SqlParameter[] {
                            new SqlParameter("@MaKH",       maKH),
                            new SqlParameter("@ThangTruoc", thang == 1 ? 12 : thang - 1),
                            new SqlParameter("@NamTruoc",   thang == 1 ? nam - 1 : nam)
                        });

                    decimal noDau = noDauObj != null ? Convert.ToDecimal(noDauObj) : Convert.ToDecimal(row["SoTienNo"]);

                    // Tổng tiền mua hàng trong tháng
                    object phatSinhMua = db.ExecuteScalar(
                        @"SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon 
                          WHERE MaKH = @MaKH AND MONTH(NgayLapHD) = @Thang AND YEAR(NgayLapHD) = @Nam",
                        new SqlParameter[] {
                            new SqlParameter("@MaKH",  maKH),
                            new SqlParameter("@Thang", thang),
                            new SqlParameter("@Nam",   nam)
                        });

                    // Tổng tiền đã thu trong tháng
                    object phatSinhThu = db.ExecuteScalar(
                        @"SELECT ISNULL(SUM(SoTienThu), 0) FROM PhieuThu 
                          WHERE MaKH = @MaKH AND MONTH(NgayThu) = @Thang AND YEAR(NgayThu) = @Nam",
                        new SqlParameter[] {
                            new SqlParameter("@MaKH",  maKH),
                            new SqlParameter("@Thang", thang),
                            new SqlParameter("@Nam",   nam)
                        });

                    decimal phatSinh = Convert.ToDecimal(phatSinhMua) - Convert.ToDecimal(phatSinhThu);
                    decimal noCuoi = noDau + phatSinh;

                    db.ExecuteNonQuery(
                        @"INSERT INTO BaoCaoCongNo (Thang, Nam, MaKH, NoDau, PhatSinh, NoCuoi) 
                          VALUES (@Thang, @Nam, @MaKH, @NoDau, @PhatSinh, @NoCuoi)",
                        new SqlParameter[] {
                            new SqlParameter("@Thang",    thang),
                            new SqlParameter("@Nam",      nam),
                            new SqlParameter("@MaKH",     maKH),
                            new SqlParameter("@NoDau",    noDau),
                            new SqlParameter("@PhatSinh", phatSinh),
                            new SqlParameter("@NoCuoi",   noCuoi)
                        });
                }

                if (showSuccess)
                    MessageBox.Show($"✅ Đã tạo báo cáo công nợ tháng {thang}/{nam} thành công!", "Thành công",
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
            if (dgvBaoCaoCongNo.Columns.Count == 0) return;

            dgvBaoCaoCongNo.Columns["MaKH"].HeaderText = "Mã KH";
            dgvBaoCaoCongNo.Columns["HoTen"].HeaderText = "Khách Hàng";
            dgvBaoCaoCongNo.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvBaoCaoCongNo.Columns["NoDau"].HeaderText = "Nợ Đầu";
            dgvBaoCaoCongNo.Columns["PhatSinh"].HeaderText = "Phát Sinh";
            dgvBaoCaoCongNo.Columns["NoCuoi"].HeaderText = "Nợ Cuối";

            dgvBaoCaoCongNo.Columns["NoDau"].DefaultCellStyle.Format = "N0";
            dgvBaoCaoCongNo.Columns["PhatSinh"].DefaultCellStyle.Format = "N0";
            dgvBaoCaoCongNo.Columns["NoCuoi"].DefaultCellStyle.Format = "N0";

            dgvBaoCaoCongNo.Columns["NoDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoCongNo.Columns["PhatSinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoCongNo.Columns["NoCuoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBaoCaoCongNo.Columns["MaKH"].Width = 70;
            dgvBaoCaoCongNo.Columns["HoTen"].Width = 200;
            dgvBaoCaoCongNo.Columns["DiaChi"].Width = 250;
            dgvBaoCaoCongNo.Columns["NoDau"].Width = 120;
            dgvBaoCaoCongNo.Columns["PhatSinh"].Width = 120;
            dgvBaoCaoCongNo.Columns["NoCuoi"].Width = 120;

            // Tô màu nợ cuối (đăng ký 1 lần)
            dgvBaoCaoCongNo.RowPrePaint -= DgvBaoCaoCongNo_RowPrePaint;
            dgvBaoCaoCongNo.RowPrePaint += DgvBaoCaoCongNo_RowPrePaint;
        }

        private void DgvBaoCaoCongNo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvBaoCaoCongNo.Rows[e.RowIndex];

            object noCuoiObj = row.Cells["NoCuoi"].Value;
            decimal noCuoi = noCuoiObj != null && noCuoiObj != DBNull.Value ? Convert.ToDecimal(noCuoiObj) : 0;

            row.Cells["NoCuoi"].Style.ForeColor = noCuoi > 0
                ? Color.FromArgb(231, 76, 60)   // đỏ – còn nợ
                : Color.FromArgb(46, 204, 113);  // xanh lá – đã trả hết
        }

        private void UpdateSummary(DataTable dt)
        {
            decimal tongNoDau = 0, tongPhatSinh = 0, tongNoCuoi = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongNoDau += row["NoDau"] != DBNull.Value ? Convert.ToDecimal(row["NoDau"]) : 0;
                tongPhatSinh += row["PhatSinh"] != DBNull.Value ? Convert.ToDecimal(row["PhatSinh"]) : 0;
                tongNoCuoi += row["NoCuoi"] != DBNull.Value ? Convert.ToDecimal(row["NoCuoi"]) : 0;
            }

            lblTongNoDau.Text = $"📊 Tổng nợ đầu: {tongNoDau:N0} VNĐ";
            lblTongPhatSinh.Text = $"📈 Tổng phát sinh: {tongPhatSinh:N0} VNĐ";
            lblTongNoCuoi.Text = $"💰 Tổng nợ cuối: {tongNoCuoi:N0} VNĐ";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoCongNo.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"BaoCaoCongNo_{cboThang.SelectedIndex + 1}_{numNam.Value}.xlsx"
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
            using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                int thang = cboThang.SelectedIndex + 1;
                int nam = (int)numNam.Value;

                writer.WriteLine($"BÁO CÁO CÔNG NỢ - THÁNG {thang}/{nam}");
                writer.WriteLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}");
                writer.WriteLine();
                writer.WriteLine("Mã KH\tKhách Hàng\tĐịa Chỉ\tNợ Đầu\tPhát Sinh\tNợ Cuối");

                foreach (DataGridViewRow row in dgvBaoCaoCongNo.Rows)
                {
                    if (row.IsNewRow) continue;
                    writer.WriteLine(string.Join("\t",
                        row.Cells["MaKH"].Value ?? "",
                        row.Cells["HoTen"].Value ?? "",
                        row.Cells["DiaChi"].Value ?? "",
                        row.Cells["NoDau"].Value ?? "",
                        row.Cells["PhatSinh"].Value ?? "",
                        row.Cells["NoCuoi"].Value ?? ""));
                }

                writer.WriteLine();
                writer.WriteLine(lblTongNoDau.Text);
                writer.WriteLine(lblTongPhatSinh.Text);
                writer.WriteLine(lblTongNoCuoi.Text);
            }
        }

        private void lbNz_Click(object sender, EventArgs e) { }

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
                    "DELETE FROM BaoCaoCongNo WHERE Thang = @Thang AND Nam = @Nam",
                    new SqlParameter[] {
                        new SqlParameter("@Thang", thang),
                        new SqlParameter("@Nam",   nam)
                    });

                TaoBaoCaoCongNo(thang, nam, showSuccess: false);
                DisplayReport(thang, nam);

                MessageBox.Show($"✅ Báo cáo công nợ tháng {thang}/{nam} đã được cập nhật!", "Thành công",
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