namespace QuanLyNhaSach
{
    partial class FormThemSachMoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblStatus = new Label();
            lblMaSach = new Label();
            txtMaSach = new TextBox();
            lblTenSach = new Label();
            txtTenSach = new TextBox();
            lblTheLoai = new Label();
            cboTheLoai = new ComboBox();
            lblTacGia = new Label();
            cboTacGia = new ComboBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblNgayNhap = new Label();
            dtpNgayNhap = new DateTimePicker();
            btnLuu = new Button();
            btnHuy = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblStatus);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(460, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm Sách Vào Phiếu Nhập";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(20, 42);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(300, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "🆕 Sách mới - Nhập thông tin";
            // 
            // lblMaSach
            // 
            lblMaSach.AutoSize = true;
            lblMaSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaSach.Location = new Point(20, 85);
            lblMaSach.Name = "lblMaSach";
            lblMaSach.Size = new Size(69, 19);
            lblMaSach.TabIndex = 1;
            lblMaSach.Text = "Mã sách:";
            // 
            // txtMaSach
            // 
            txtMaSach.Font = new Font("Segoe UI", 10F);
            txtMaSach.Location = new Point(130, 82);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.ReadOnly = true;
            txtMaSach.Size = new Size(300, 25);
            txtMaSach.TabIndex = 0;
            txtMaSach.Text = "(Tự động tạo)";
            // 
            // lblTenSach
            // 
            lblTenSach.AutoSize = true;
            lblTenSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenSach.Location = new Point(20, 120);
            lblTenSach.Name = "lblTenSach";
            lblTenSach.Size = new Size(69, 19);
            lblTenSach.TabIndex = 1;
            lblTenSach.Text = "Tên sách:";
            // 
            // txtTenSach
            // 
            txtTenSach.Font = new Font("Segoe UI", 10F);
            txtTenSach.Location = new Point(130, 117);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.Size = new Size(300, 25);
            txtTenSach.TabIndex = 1;
            txtTenSach.TextChanged += txtTenSach_TextChanged;
            // 
            // lblTheLoai
            // 
            lblTheLoai.AutoSize = true;
            lblTheLoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTheLoai.Location = new Point(20, 155);
            lblTheLoai.Name = "lblTheLoai";
            lblTheLoai.Size = new Size(66, 19);
            lblTheLoai.TabIndex = 1;
            lblTheLoai.Text = "Thể loại:";
            // 
            // cboTheLoai
            // 
            cboTheLoai.Font = new Font("Segoe UI", 10F);
            cboTheLoai.FormattingEnabled = true;
            cboTheLoai.Location = new Point(130, 152);
            cboTheLoai.Name = "cboTheLoai";
            cboTheLoai.Size = new Size(300, 25);
            cboTheLoai.TabIndex = 2;
            // 
            // lblTacGia
            // 
            lblTacGia.AutoSize = true;
            lblTacGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTacGia.Location = new Point(20, 190);
            lblTacGia.Name = "lblTacGia";
            lblTacGia.Size = new Size(60, 19);
            lblTacGia.TabIndex = 1;
            lblTacGia.Text = "Tác giả:";
            // 
            // cboTacGia
            // 
            cboTacGia.Font = new Font("Segoe UI", 10F);
            cboTacGia.FormattingEnabled = true;
            cboTacGia.Location = new Point(130, 187);
            cboTacGia.Name = "cboTacGia";
            cboTacGia.Size = new Size(300, 25);
            cboTacGia.TabIndex = 3;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDonGia.Location = new Point(20, 225);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(109, 19);
            lblDonGia.TabIndex = 1;
            lblDonGia.Text = "Đơn giá (VNĐ):";
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Segoe UI", 10F);
            txtDonGia.Location = new Point(130, 222);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(300, 25);
            txtDonGia.TabIndex = 4;
            txtDonGia.TextChanged += txtDonGia_TextChanged;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSoLuong.Location = new Point(20, 260);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(72, 19);
            lblSoLuong.TabIndex = 1;
            lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(130, 257);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(300, 25);
            txtSoLuong.TabIndex = 5;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNgayNhap.Location = new Point(20, 295);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(84, 19);
            lblNgayNhap.TabIndex = 1;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Location = new Point(130, 292);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 25);
            dtpNgayNhap.TabIndex = 6;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(200, 340);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 35);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(231, 76, 60);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(320, 340);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 35);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // FormThemSachMoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(460, 400);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(dtpNgayNhap);
            Controls.Add(lblNgayNhap);
            Controls.Add(txtSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(txtDonGia);
            Controls.Add(lblDonGia);
            Controls.Add(cboTacGia);
            Controls.Add(lblTacGia);
            Controls.Add(cboTheLoai);
            Controls.Add(lblTheLoai);
            Controls.Add(txtTenSach);
            Controls.Add(lblTenSach);
            Controls.Add(txtMaSach);
            Controls.Add(lblMaSach);
            Controls.Add(pnlHeader);
            // Đảm bảo các thuộc tính này được thiết lập đúng:
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(460, 400);
            Name = "FormThemSachMoi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Sách Vào Phiếu Nhập";
            Load += FormThemSachMoi_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblStatus;
        private Label lblMaSach;
        private TextBox txtMaSach;
        private Label lblTenSach;
        private TextBox txtTenSach;
        private Label lblTheLoai;
        private ComboBox cboTheLoai;
        private Label lblTacGia;
        private ComboBox cboTacGia;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblNgayNhap;
        private DateTimePicker dtpNgayNhap;
        private Button btnLuu;
        private Button btnHuy;

    }
}