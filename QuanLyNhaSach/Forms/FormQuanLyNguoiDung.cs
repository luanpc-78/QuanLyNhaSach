using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using QuanLyNhaSach.Models;

namespace QuanLyNhaSach
{
    public partial class FormQuanLyNguoiDung : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private DataGridView dgvUsers;
        private Button btnThem;
        private Button btnKhoa;
        private Button btnLamMoi;

        public FormQuanLyNguoiDung()
        {
            this.Text = "Quản Lý Người Dùng";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeControls();
        }

        private void InitializeControls()
        {
            // DataGridView
            dgvUsers = new DataGridView();
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Height = 400;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaND", HeaderText = "Mã ND", Width = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDangNhap", HeaderText = "Tên Đăng Nhập", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ Tên", Width = 200 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 200 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VaiTro", HeaderText = "Vai Trò", Width = 100 });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Hoạt Động", Width = 80 });

            // Buttons Panel
            Panel pnlButtons = new Panel();
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Height = 60;
            pnlButtons.Padding = new Padding(10);

            btnThem = new Button();
            btnThem.Text = "➕ Thêm User";
            btnThem.Size = new System.Drawing.Size(120, 40);
            btnThem.Location = new System.Drawing.Point(10, 10);
            btnThem.Click += (s, e) => MessageBox.Show("Chức năng này sẽ được cập nhật!", "Thông báo");

            btnKhoa = new Button();
            btnKhoa.Text = "🔒 Khóa/Mở";
            btnKhoa.Size = new System.Drawing.Size(120, 40);
            btnKhoa.Location = new System.Drawing.Point(140, 10);
            btnKhoa.Click += BtnKhoa_Click;

            btnLamMoi = new Button();
            btnLamMoi.Text = "🔄 Làm Mới";
            btnLamMoi.Size = new System.Drawing.Size(120, 40);
            btnLamMoi.Location = new System.Drawing.Point(270, 10);
            btnLamMoi.Click += (s, e) => LoadUsers();

            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnKhoa);
            pnlButtons.Controls.Add(btnLamMoi);

            this.Controls.Add(dgvUsers);
            this.Controls.Add(pnlButtons);

            this.Load += FormQuanLyNguoiDung_Load;
        }

        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || UserSession.CurrentUser.VaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataTable dt = db.ExecuteQuery(
                    "SELECT MaND, TenDangNhap, HoTen, Email, VaiTro, TrangThai, NgayTao FROM NguoiDung");
                dgvUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void BtnKhoa_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo");
                return;
            }

            try
            {
                int maND = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["MaND"].Value);
                if (UserSession.CurrentUser != null && maND == UserSession.CurrentUser.MaND)
                {
                    MessageBox.Show("Không thể khóa tài khoản của chính mình!", "Lỗi");
                    return;
                }

                db.ExecuteNonQuery(
                    "UPDATE NguoiDung SET TrangThai = CASE WHEN TrangThai = 1 THEN 0 ELSE 1 END WHERE MaND = @MaND",
                    new SqlParameter[] { new SqlParameter("@MaND", maND) });

                LoadUsers();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}