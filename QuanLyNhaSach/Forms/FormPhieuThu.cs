using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using QuanLyNhaSach.Models;

namespace QuanLyNhaSach
{
    public partial class FormPhieuThu : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormPhieuThu()
        {
            InitializeComponent();
        }

        private void FormPhieuThu_Load(object sender, EventArgs e)
        {
            dtpNgayThu.Value = DateTime.Now;
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            DataTable dt = db.ExecuteQuery("SELECT MaKH, HoTen, DiaChi, DienThoai, Email, SoTienNo FROM KhachHang WHERE SoTienNo > 0");
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)cboKhachHang.SelectedItem;
                txtDiaChi.Text = drv["DiaChi"].ToString();
                txtDienThoai.Text = drv["DienThoai"].ToString();
                txtEmail.Text = drv["Email"].ToString();
                lblSoTienNo.Text = $"Số tiền đang nợ: {Convert.ToDecimal(drv["SoTienNo"]):N0} VNĐ";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoTienThu.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền thu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoTienThu.Text, out decimal soTienThu) || soTienThu <= 0)
            {
                MessageBox.Show("Số tiền phải là một số dương!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                object qd5Obj = db.ExecuteScalar("SELECT ApDung FROM QuiDinh WHERE TenQD LIKE N'%QĐ4%' OR TenQD LIKE N'%thu tiền%'");
                bool apDungQD5 = qd5Obj != null ? Convert.ToBoolean(qd5Obj) : false;

                int maKH = Convert.ToInt32(cboKhachHang.SelectedValue);
                object soTienNoObj = db.ExecuteScalar(
                    "SELECT SoTienNo FROM KhachHang WHERE MaKH = @MaKH",
                    new SqlParameter[] { new SqlParameter("@MaKH", maKH) });

                decimal soTienNo = soTienNoObj != null ? Convert.ToDecimal(soTienNoObj) : 0;

                if (apDungQD5)
                {
                    if (soTienThu > soTienNo)
                    {
                        MessageBox.Show($"Số tiền thu ({soTienThu:N0} VNĐ) không được vượt quá số tiền nợ ({soTienNo:N0} VNĐ)!",
                            "Lỗi qui định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // === SỬA: Thêm MaND để biết ai lập phiếu thu ===
                db.ExecuteNonQuery(
                    "INSERT INTO PhieuThu (MaKH, NgayThu, SoTienThu, MaND) VALUES (@MaKH, @NgayThu, @SoTienThu, @MaND)",
                    new SqlParameter[] {
                        new SqlParameter("@MaKH", maKH),
                        new SqlParameter("@NgayThu", dtpNgayThu.Value),
                        new SqlParameter("@SoTienThu", soTienThu),
                        new SqlParameter("@MaND", UserSession.CurrentUser != null ? UserSession.CurrentUser.MaND : 0)
                    });

                db.ExecuteNonQuery(
                    "UPDATE KhachHang SET SoTienNo = SoTienNo - @SoTienThu WHERE MaKH = @MaKH",
                    new SqlParameter[] {
                        new SqlParameter("@SoTienThu", soTienThu),
                        new SqlParameter("@MaKH", maKH)
                    });

                MessageBox.Show("Lập phiếu thu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKhachHang();
                txtSoTienThu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboKhachHang.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtSoTienThu.Clear();
            lblSoTienNo.Text = "Số tiền đang nợ: 0 VNĐ";
            dtpNgayThu.Value = DateTime.Now;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpNgayThu_ValueChanged(object sender, EventArgs e) { }
        private void txtDienThoai_TextChanged(object sender, EventArgs e) { }
        private void txtSoTienThu_TextChanged(object sender, EventArgs e) { }
    }
}