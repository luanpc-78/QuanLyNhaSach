using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaSach.Models;

// #nullable enable

namespace QuanLyNhaSach
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Form currentChildForm;
        private bool sidebarExpanded = true;

        public Form1()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = $"Quản Lý Nhà Sách - {UserSession.CurrentUser?.HoTen} ({UserSession.CurrentUser?.VaiTro})";
            this.WindowState = FormWindowState.Maximized;
            ApplyPermissions();
            lblTitle.Text = "QUẢN LÝ NHÀ SÁCH";
        }

        private void ApplyPermissions()
        {
            // Hiển thị tất cả cho admin
            if (UserSession.CurrentUser != null && UserSession.CurrentUser.VaiTro == "Admin")
            {
                btnNhapSach.Visible = true;
                btnBaoCaoTon.Visible = true;
                btnBaoCaoNo.Visible = true;
                btnQuiDinh.Visible = true;
                lblTitle.Text = "QUẢN LÝ NHÀ SÁCH - ADMIN";
            }
            // Nhân viên được nhập sách, không được xem báo cáo và quy định
            else if (UserSession.CurrentUser != null && UserSession.CurrentUser.VaiTro == "NhanVien")
            {
                btnNhapSach.Visible = true;
                btnBaoCaoTon.Visible = false;
                btnBaoCaoNo.Visible = false;
                btnQuiDinh.Visible = false;
                lblTitle.Text = "QUẢN LÝ NHÀ SÁCH - NHÂN VIÊN";
            }
            // Nếu không đăng nhập hoặc vai trò khác
            else
            {
                btnNhapSach.Visible = false;
                btnBaoCaoTon.Visible = false;
                btnBaoCaoNo.Visible = false;
                btnQuiDinh.Visible = false;
                lblTitle.Text = "QUẢN LÝ NHÀ SÁCH";
            }
        }

        private void CustomizeDesign()
        {
            pnlSidebar.Width = 220;
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnMenu)
                {
                    btn.MouseEnter += (s, e) => {
                        if (currentButton != btn)
                            btn.BackColor = Color.FromArgb(52, 73, 94);
                    };
                    btn.MouseLeave += (s, e) => {
                        if (currentButton != btn)
                            btn.BackColor = Color.FromArgb(44, 62, 80);
                    };
                }
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(52, 152, 219);
                    currentButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    lblTitle.Text = CleanButtonText(currentButton.Text);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnMenu)
                {
                    btn.BackColor = Color.FromArgb(44, 62, 80);
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            }
        }

        private string CleanButtonText(string text)
        {
            return text.Trim()
                .Replace("  📥 ", "")
                .Replace("  🛒 ", "")
                .Replace("  🔍 ", "")
                .Replace("  💰 ", "")
                .Replace("  📊 ", "")
                .Replace("  📈 ", "")
                .Replace("  ⚙️ ", "")
                .Replace("  🚪 ", "");
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || (UserSession.CurrentUser.VaiTro != "Admin" && UserSession.CurrentUser.VaiTro != "NhanVien"))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivateButton(sender);
            OpenChildForm(new FormPhieuNhap());
        }

        private void btnBanSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormHoaDon());
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormTraCuuSach());
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormPhieuThu());
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || UserSession.CurrentUser.VaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivateButton(sender);
            OpenChildForm(new FormBaoCaoTon());
        }

        private void btnBaoCaoNo_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || UserSession.CurrentUser.VaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivateButton(sender);
            OpenChildForm(new FormBaoCaoCongNo());
        }

        private void btnQuiDinh_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || UserSession.CurrentUser.VaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivateButton(sender);
            OpenChildForm(new FormQuiDinh());
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null || UserSession.CurrentUser.VaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivateButton(sender);
            OpenChildForm(new FormQuanLyNguoiDung());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.CurrentUser = null;
                this.Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                pnlSidebar.Width = 60;
                sidebarExpanded = false;
                foreach (Control ctrl in pnlSidebar.Controls)
                {
                    if (ctrl is Button btn && btn != btnMenu)
                    {
                        btn.Text = btn.Text.Substring(0, 2);
                    }
                }
            }
            else
            {
                pnlSidebar.Width = 220;
                sidebarExpanded = true;
                btnNhapSach.Text = "  📥 Phiếu Nhập Sách";
                btnBanSach.Text = "  🛒 Hóa Đơn Bán Sách";
                btnTraCuu.Text = "  🔍 Tra Cứu Sách";
                btnThuTien.Text = "  💰 Phiếu Thu Tiền";
                btnBaoCaoTon.Text = "  📊 Báo Cáo Tồn";
                btnBaoCaoNo.Text = "  📈 Báo Cáo Công Nợ";
                btnQuiDinh.Text = "  ⚙️ Thay Đổi Qui Định";
                btnDangXuat.Text = "  🚪 Đăng Xuất";
            }
        }
    }
}