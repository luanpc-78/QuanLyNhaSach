using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using QuanLyNhaSach.Models;

namespace QuanLyNhaSach
{
    public partial class FormHoaDon : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private DataTable dtChiTiet = new DataTable();
        private DataTable _snapshotChiTiet = new DataTable();
        private int _lastMaHD = 0;

        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgayLap.Value = DateTime.Now;
            LoadKhachHang();
            LoadSach();
            SetupDataGridView();

            dtChiTiet.Columns.Add("MaSach", typeof(int));
            dtChiTiet.Columns.Add("TenSach", typeof(string));
            dtChiTiet.Columns.Add("TenTheLoai", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTietHD.DataSource = dtChiTiet;
        }

        private void SetupDataGridView()
        {
            dgvChiTietHD.AutoGenerateColumns = false;
            dgvChiTietHD.Columns.Clear();

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã Sách",
                Name = "colMaSach",
                Width = 80,
                Visible = false
            });

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên Sách",
                Name = "colTenSach",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenTheLoai",
                HeaderText = "Thể Loại",
                Name = "colTheLoai",
                Width = 150
            });

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "SL",
                Name = "colSL",
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn Giá",
                Name = "colDonGia",
                Width = 120,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành Tiền",
                Name = "colThanhTien",
                Width = 140,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(231, 76, 60),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            });

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 40,
                Name = "colXoa",
                FlatStyle = FlatStyle.Flat
            };
            dgvChiTietHD.Columns.Add(btnXoa);

            dgvChiTietHD.AllowUserToAddRows = false;
            dgvChiTietHD.AllowUserToDeleteRows = false;
            dgvChiTietHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHD.RowHeadersVisible = false;
            dgvChiTietHD.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgvChiTietHD.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTietHD.GridColor = Color.FromArgb(224, 224, 224);
        }

        private void LoadKhachHang()
        {
            DataTable dt = db.ExecuteQuery("SELECT MaKH, HoTen, SoTienNo FROM KhachHang");
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void LoadSach()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT s.MaSach, s.TenSach, tl.TenTheLoai, s.DonGia, s.SoLuongTon 
                    FROM Sach s 
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai 
                    WHERE s.SoLuongTon > 0 
                    ORDER BY s.TenSach");
                cboSach.DataSource = dt;
                cboSach.DisplayMember = "TenSach";
                cboSach.ValueMember = "MaSach";
                cboSach.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sách: " + ex.Message, "Lỗi");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSach.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sách để bán!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuongBan) || soLuongBan <= 0)
            {
                MessageBox.Show("Số lượng phải là một số dương!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                object qd3 = db.ExecuteScalar("SELECT GiaTriTien FROM QuiDinh WHERE MaQD = 3");
                object qd4 = db.ExecuteScalar("SELECT GiaTri FROM QuiDinh WHERE MaQD = 4");

                decimal tienNoToiDa = qd3 != null ? Convert.ToDecimal(qd3) : 20000;
                int slTonToiThieu = qd4 != null ? Convert.ToInt32(qd4) : 20;

                int maKH = Convert.ToInt32(cboKhachHang.SelectedValue);
                object soTienNoObj = db.ExecuteScalar(
                    "SELECT SoTienNo FROM KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter[] { new SqlParameter("@MaKH", maKH) });

                decimal soTienNo = soTienNoObj != null ? Convert.ToDecimal(soTienNoObj) : 0;

                if (soTienNo > tienNoToiDa)
                {
                    MessageBox.Show($"Khách hàng nợ {soTienNo:N0} VNĐ, vượt quá mức cho phép ({tienNoToiDa:N0} VNĐ)!",
                        "Lỗi qui định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maSach = Convert.ToInt32(cboSach.SelectedValue);
                DataRowView sachData = (DataRowView)cboSach.SelectedItem;
                decimal donGia = Convert.ToDecimal(sachData["DonGia"] ?? 0);
                int slTon = Convert.ToInt32(sachData["SoLuongTon"] ?? 0);

                if (slTon < soLuongBan)
                {
                    MessageBox.Show($"Số lượng tồn không đủ! Hiện tại chỉ có {slTon} cuốn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (slTon - soLuongBan < slTonToiThieu)
                {
                    MessageBox.Show($"Số lượng tồn sau khi bán phải >= {slTonToiThieu}! Hiện tại chỉ có {slTon} cuốn.",
                        "Lỗi qui định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataRow r in dtChiTiet.Rows)
                {
                    if (Convert.ToInt32(r["MaSach"]) == maSach)
                    {
                        MessageBox.Show("Sách này đã có trong hóa đơn! Vui lòng xóa và thêm lại nếu muốn thay đổi số lượng.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                DataRow row = dtChiTiet.NewRow();
                row["MaSach"] = maSach;
                row["TenSach"] = sachData["TenSach"] ?? "";
                row["TenTheLoai"] = sachData["TenTheLoai"] ?? "";
                row["SoLuong"] = soLuongBan;
                row["DonGia"] = donGia;
                row["ThanhTien"] = soLuongBan * donGia;
                dtChiTiet.Rows.Add(row);

                MessageBox.Show("Thêm sách vào hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TinhTongTien();
                txtSoLuong.Clear();
                cboSach.SelectedIndex = -1;
                cboSach.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvChiTietHD.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Xóa sách này khỏi hóa đơn?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtChiTiet.Rows.RemoveAt(e.RowIndex);
                    TinhTongTien();
                }
            }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in dtChiTiet.Rows)
                tong += Convert.ToDecimal(row["ThanhTien"]);
            lblTongTien.Text = $"Tổng tiền: {tong:N0} VNĐ";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Xác nhận lập hóa đơn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int maKH = Convert.ToInt32(cboKhachHang.SelectedValue);
                decimal tongTien = 0;
                foreach (DataRow row in dtChiTiet.Rows)
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);

                int maHD = Convert.ToInt32(db.ExecuteScalar(
                    "INSERT INTO HoaDon (MaKH, NgayLapHD, TongTien, MaND) OUTPUT INSERTED.MaHD VALUES (@MaKH, @NgayLap, @TongTien, @MaND)",
                    new SqlParameter[] {
                        new SqlParameter("@MaKH", maKH),
                        new SqlParameter("@NgayLap", dtpNgayLap.Value),
                        new SqlParameter("@TongTien", tongTien),
                        new SqlParameter("@MaND", UserSession.CurrentUser != null ? UserSession.CurrentUser.MaND : 0)
                    }));

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    int maSach = Convert.ToInt32(row["MaSach"]);
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    decimal donGia = Convert.ToDecimal(row["DonGia"]);

                    db.ExecuteNonQuery(
                        "INSERT INTO CT_HoaDon (MaHD, MaSach, SoLuong, DonGia) VALUES (@MaHD, @MaSach, @SL, @DG)",
                        new SqlParameter[] {
                            new SqlParameter("@MaHD", maHD),
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@SL", soLuong),
                            new SqlParameter("@DG", donGia)
                        });

                    db.ExecuteNonQuery(
                        "UPDATE Sach SET SoLuongTon = SoLuongTon - @SL WHERE MaSach = @MaSach",
                        new SqlParameter[] {
                            new SqlParameter("@SL", soLuong),
                            new SqlParameter("@MaSach", maSach)
                        });
                }

                db.ExecuteNonQuery(
                    "UPDATE KhachHang SET SoTienNo = SoTienNo + @TienNo WHERE MaKH = @MaKH",
                    new SqlParameter[] {
                        new SqlParameter("@TienNo", tongTien),
                        new SqlParameter("@MaKH", maKH)
                    });

                MessageBox.Show("Lập hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _lastMaHD = maHD;
                btnInBill.Enabled = true;
                _snapshotChiTiet = dtChiTiet.Copy();
                dtChiTiet.Clear();
                LoadSach();
                LoadKhachHang();
                cboKhachHang.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtChiTiet.Clear();
            TinhTongTien();
            cboKhachHang.SelectedIndex = -1;
            cboSach.SelectedIndex = -1;
            txtSoLuong.Clear();
            dtpNgayLap.Value = DateTime.Now;
            LoadSach();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count > 0)
            {
                if (MessageBox.Show("Hủy hóa đơn hiện tại?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)cboKhachHang.SelectedItem;
                decimal no = Convert.ToDecimal(drv["SoTienNo"] ?? 0);
            }
        }

        private void lbSL_Click(object sender, EventArgs e)
        {
        }

        private void btnInBill_Click(object sender, EventArgs e)
        {
            string tenKH = "";
            if (cboKhachHang.SelectedItem is DataRowView drv)
                tenKH = drv["HoTen"].ToString();

            var items = new List<BillItem>();
            foreach (DataRow row in _snapshotChiTiet.Rows)
            {
                items.Add(new BillItem
                {
                    TenSach = row["TenSach"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }

            decimal tongTien = 0;
            foreach (var it in items)
                tongTien += it.ThanhTien;

            var frmBill = new FormInBill(_lastMaHD, tenKH, DateTime.Now, items, tongTien);
            frmBill.ShowDialog(this);
        }

        private void btnThemSachMoi_Click(object sender, EventArgs e)
        {
            LoadSach();
        }
    }
}
