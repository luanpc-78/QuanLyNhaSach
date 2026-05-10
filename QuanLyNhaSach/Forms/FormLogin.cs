using QuanLyNhaSach.DAL;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using QuanLyNhaSach.Models;

// #nullable enable

namespace QuanLyNhaSach
{
    public partial class FormLogin : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            picLogo.Left = (this.ClientSize.Width - picLogo.Width) / 2;

            StyleButton(btnLogin);
            txtPassword.KeyDown += TxtPassword_KeyDown;
            LoadRememberedUser();

            try
            {
                db.InitializeDatabase();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khởi tạo database: " + ex.Message);
            }
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(52, 152, 219);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(41, 128, 185);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT * FROM NguoiDung
                                WHERE TenDangNhap = @TenDangNhap
                                AND MatKhau = @MatKhau
                                AND TrangThai = 1";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", user),
                    new SqlParameter("@MatKhau", pass)  // Nếu DB chưa hash thì dùng pass, nếu đã hash thì dùng HashPassword(pass)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    UserSession.CurrentUser = new NguoiDung
                    {
                        MaND = Convert.ToInt32(row["MaND"]),
                        TenDangNhap = row["TenDangNhap"].ToString(),
                        HoTen = row["HoTen"].ToString(),
                        Email = row["Email"].ToString(),
                        VaiTro = row["VaiTro"].ToString(),
                        TrangThai = Convert.ToBoolean(row["TrangThai"]),
                        NgayTao = Convert.ToDateTime(row["NgayTao"])
                    };

                    if (chkRemember.Checked)
                        SaveRememberedUser(user);
                    else
                        ClearRememberedUser();

                    MessageBox.Show($"Chào mừng {user}!", "Đăng nhập thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form1 mainForm = new Form1();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng hoặc tài khoản đã bị khóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRememberedUser(string username)
        {
            Properties.Settings.Default.LastUsername = username;
            Properties.Settings.Default.Save();
        }

        private void ClearRememberedUser()
        {
            Properties.Settings.Default.LastUsername = "";
            Properties.Settings.Default.Save();
        }

        private void LoadRememberedUser()
        {
            txtUsername.Text = Properties.Settings.Default.LastUsername;
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Liên hệ Admin để reset mật khẩu!\n📧 admin@nhasach.com\n📞 0901234567",
                "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grpLogin_Enter(object sender, EventArgs e) { }
        private void lblFooter_Click(object sender, EventArgs e) { }
    }
}