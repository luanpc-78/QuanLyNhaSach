namespace QuanLyNhaSach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlSidebar = new Panel();
            btnDangXuat = new Button();
            btnQuiDinh = new Button();
            btnBaoCaoNo = new Button();
            btnBaoCaoTon = new Button();
            btnThuTien = new Button();
            btnTraCuu = new Button();
            btnBanSach = new Button();
            btnNhapSach = new Button();
            btnMenu = new Button();
            pnlTopBar = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            pictureBox1 = new PictureBox();
            pnlSidebar.SuspendLayout();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(44, 62, 80);
            pnlSidebar.Controls.Add(btnDangXuat);
            pnlSidebar.Controls.Add(btnQuiDinh);
            pnlSidebar.Controls.Add(btnBaoCaoNo);
            pnlSidebar.Controls.Add(btnBaoCaoTon);
            pnlSidebar.Controls.Add(btnThuTien);
            pnlSidebar.Controls.Add(btnTraCuu);
            pnlSidebar.Controls.Add(btnBanSach);
            pnlSidebar.Controls.Add(btnNhapSach);
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 450);
            pnlSidebar.TabIndex = 3;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(44, 62, 80);
            btnDangXuat.Cursor = Cursors.Hand;
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10F);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(0, 400);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(15, 0, 0, 0);
            btnDangXuat.Size = new Size(220, 50);
            btnDangXuat.TabIndex = 8;
            btnDangXuat.Text = "  🚪 Đăng Xuất";
            btnDangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnQuiDinh
            // 
            btnQuiDinh.BackColor = Color.FromArgb(44, 62, 80);
            btnQuiDinh.Cursor = Cursors.Hand;
            btnQuiDinh.Dock = DockStyle.Top;
            btnQuiDinh.FlatAppearance.BorderSize = 0;
            btnQuiDinh.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnQuiDinh.FlatStyle = FlatStyle.Flat;
            btnQuiDinh.Font = new Font("Segoe UI", 10F);
            btnQuiDinh.ForeColor = Color.White;
            btnQuiDinh.Location = new Point(0, 300);
            btnQuiDinh.Name = "btnQuiDinh";
            btnQuiDinh.Padding = new Padding(15, 0, 0, 0);
            btnQuiDinh.Size = new Size(220, 50);
            btnQuiDinh.TabIndex = 7;
            btnQuiDinh.Text = "  ⚙️ Thay Đổi Qui Định";
            btnQuiDinh.TextAlign = ContentAlignment.MiddleLeft;
            btnQuiDinh.UseVisualStyleBackColor = false;
            btnQuiDinh.Click += btnQuiDinh_Click;
            // 
            // btnBaoCaoNo
            // 
            btnBaoCaoNo.BackColor = Color.FromArgb(44, 62, 80);
            btnBaoCaoNo.Cursor = Cursors.Hand;
            btnBaoCaoNo.Dock = DockStyle.Top;
            btnBaoCaoNo.FlatAppearance.BorderSize = 0;
            btnBaoCaoNo.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnBaoCaoNo.FlatStyle = FlatStyle.Flat;
            btnBaoCaoNo.Font = new Font("Segoe UI", 10F);
            btnBaoCaoNo.ForeColor = Color.White;
            btnBaoCaoNo.Location = new Point(0, 250);
            btnBaoCaoNo.Name = "btnBaoCaoNo";
            btnBaoCaoNo.Padding = new Padding(15, 0, 0, 0);
            btnBaoCaoNo.Size = new Size(220, 50);
            btnBaoCaoNo.TabIndex = 6;
            btnBaoCaoNo.Text = "  📈 Báo Cáo Công Nợ";
            btnBaoCaoNo.TextAlign = ContentAlignment.MiddleLeft;
            btnBaoCaoNo.UseVisualStyleBackColor = false;
            btnBaoCaoNo.Click += btnBaoCaoNo_Click;
            // 
            // btnBaoCaoTon
            // 
            btnBaoCaoTon.BackColor = Color.FromArgb(44, 62, 80);
            btnBaoCaoTon.Cursor = Cursors.Hand;
            btnBaoCaoTon.Dock = DockStyle.Top;
            btnBaoCaoTon.FlatAppearance.BorderSize = 0;
            btnBaoCaoTon.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnBaoCaoTon.FlatStyle = FlatStyle.Flat;
            btnBaoCaoTon.Font = new Font("Segoe UI", 10F);
            btnBaoCaoTon.ForeColor = Color.White;
            btnBaoCaoTon.Location = new Point(0, 200);
            btnBaoCaoTon.Name = "btnBaoCaoTon";
            btnBaoCaoTon.Padding = new Padding(15, 0, 0, 0);
            btnBaoCaoTon.Size = new Size(220, 50);
            btnBaoCaoTon.TabIndex = 5;
            btnBaoCaoTon.Text = "  📊 Báo Cáo Tồn";
            btnBaoCaoTon.TextAlign = ContentAlignment.MiddleLeft;
            btnBaoCaoTon.UseVisualStyleBackColor = false;
            btnBaoCaoTon.Click += btnBaoCaoTon_Click;
            // 
            // btnThuTien
            // 
            btnThuTien.BackColor = Color.FromArgb(44, 62, 80);
            btnThuTien.Cursor = Cursors.Hand;
            btnThuTien.Dock = DockStyle.Top;
            btnThuTien.FlatAppearance.BorderSize = 0;
            btnThuTien.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnThuTien.FlatStyle = FlatStyle.Flat;
            btnThuTien.Font = new Font("Segoe UI", 10F);
            btnThuTien.ForeColor = Color.White;
            btnThuTien.Location = new Point(0, 150);
            btnThuTien.Name = "btnThuTien";
            btnThuTien.Padding = new Padding(15, 0, 0, 0);
            btnThuTien.Size = new Size(220, 50);
            btnThuTien.TabIndex = 4;
            btnThuTien.Text = "  💰 Phiếu Thu Tiền";
            btnThuTien.TextAlign = ContentAlignment.MiddleLeft;
            btnThuTien.UseVisualStyleBackColor = false;
            btnThuTien.Click += btnThuTien_Click;
            // 
            // btnTraCuu
            // 
            btnTraCuu.BackColor = Color.FromArgb(44, 62, 80);
            btnTraCuu.Cursor = Cursors.Hand;
            btnTraCuu.Dock = DockStyle.Top;
            btnTraCuu.FlatAppearance.BorderSize = 0;
            btnTraCuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnTraCuu.FlatStyle = FlatStyle.Flat;
            btnTraCuu.Font = new Font("Segoe UI", 10F);
            btnTraCuu.ForeColor = Color.White;
            btnTraCuu.Location = new Point(0, 100);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Padding = new Padding(15, 0, 0, 0);
            btnTraCuu.Size = new Size(220, 50);
            btnTraCuu.TabIndex = 3;
            btnTraCuu.Text = "  🔍 Tra Cứu Sách";
            btnTraCuu.TextAlign = ContentAlignment.MiddleLeft;
            btnTraCuu.UseVisualStyleBackColor = false;
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // btnBanSach
            // 
            btnBanSach.BackColor = Color.FromArgb(44, 62, 80);
            btnBanSach.Cursor = Cursors.Hand;
            btnBanSach.Dock = DockStyle.Top;
            btnBanSach.FlatAppearance.BorderSize = 0;
            btnBanSach.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnBanSach.FlatStyle = FlatStyle.Flat;
            btnBanSach.Font = new Font("Segoe UI", 10F);
            btnBanSach.ForeColor = Color.White;
            btnBanSach.Location = new Point(0, 50);
            btnBanSach.Name = "btnBanSach";
            btnBanSach.Padding = new Padding(15, 0, 0, 0);
            btnBanSach.Size = new Size(220, 50);
            btnBanSach.TabIndex = 2;
            btnBanSach.Text = "  \U0001f6d2 Hóa Đơn Bán Sách";
            btnBanSach.TextAlign = ContentAlignment.MiddleLeft;
            btnBanSach.UseVisualStyleBackColor = false;
            btnBanSach.Click += btnBanSach_Click;
            // 
            // btnNhapSach
            // 
            btnNhapSach.BackColor = Color.FromArgb(44, 62, 80);
            btnNhapSach.Cursor = Cursors.Hand;
            btnNhapSach.Dock = DockStyle.Top;
            btnNhapSach.FlatAppearance.BorderSize = 0;
            btnNhapSach.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnNhapSach.FlatStyle = FlatStyle.Flat;
            btnNhapSach.Font = new Font("Segoe UI", 10F);
            btnNhapSach.ForeColor = Color.White;
            btnNhapSach.Location = new Point(0, 0);
            btnNhapSach.Name = "btnNhapSach";
            btnNhapSach.Padding = new Padding(15, 0, 0, 0);
            btnNhapSach.Size = new Size(220, 50);
            btnNhapSach.TabIndex = 1;
            btnNhapSach.Text = "  📥 Phiếu Nhập Sách";
            btnNhapSach.TextAlign = ContentAlignment.MiddleLeft;
            btnNhapSach.UseVisualStyleBackColor = false;
            btnNhapSach.Click += btnNhapSach_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(0, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(50, 50);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(52, 73, 94);
            pnlTopBar.Controls.Add(lblTitle);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(220, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(580, 50);
            pnlTopBar.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÀ SÁCH";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(236, 240, 241);
            pnlContent.Controls.Add(pictureBox1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 50);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(580, 400);
            pnlContent.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(580, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlSidebar);
            IsMdiContainer = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Nhà Sách";
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlTopBar;
        private Panel pnlContent;
        private Button btnMenu;
        private Button btnNhapSach;
        private Button btnBanSach;
        private Button btnTraCuu;
        private Button btnThuTien;
        private Button btnBaoCaoTon;
        private Button btnBaoCaoNo;
        private Button btnQuiDinh;
        private Button btnDangXuat;
        private Label lblTitle;
        private PictureBox pictureBox1;
    }
}
