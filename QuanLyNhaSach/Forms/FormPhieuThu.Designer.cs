namespace QuanLyNhaSach
{
    partial class FormPhieuThu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormDesc = new Label();
            dtpNgayThu = new DateTimePicker();
            cboKhachHang = new ComboBox();
            txtDiaChi = new TextBox();
            txtDienThoai = new TextBox();
            txtEmail = new TextBox();
            lblSoTienNo = new Label();
            txtSoTienThu = new TextBox();
            btnThu = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();
            grpPTT = new GroupBox();
            lbNTT = new Label();
            groupBox1 = new GroupBox();
            pnlHeader.SuspendLayout();
            grpPTT.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormDesc);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(186, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "PHIẾU THU TIỀN";
            // 
            // lblFormDesc
            // 
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.Size = new Size(129, 15);
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Thu tiền từ khách hàng";
            // 
            // dtpNgayThu
            // 
            dtpNgayThu.Font = new Font("Segoe UI", 10F);
            dtpNgayThu.Location = new Point(632, 41);
            dtpNgayThu.Name = "dtpNgayThu";
            dtpNgayThu.Size = new Size(250, 25);
            dtpNgayThu.TabIndex = 1;
            dtpNgayThu.ValueChanged += dtpNgayThu_ValueChanged;
            // 
            // cboKhachHang
            // 
            cboKhachHang.Font = new Font("Segoe UI", 10F);
            cboKhachHang.Location = new Point(6, 41);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(300, 25);
            cboKhachHang.TabIndex = 2;
            cboKhachHang.Text = "🔍 Chọn khách hàng";
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(6, 187);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.Size = new Size(300, 25);
            txtDiaChi.TabIndex = 3;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Font = new Font("Segoe UI", 10F);
            txtDienThoai.Location = new Point(6, 90);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.ReadOnly = true;
            txtDienThoai.Size = new Size(200, 25);
            txtDienThoai.TabIndex = 4;
            txtDienThoai.TextChanged += txtDienThoai_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(6, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(300, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblSoTienNo
            // 
            lblSoTienNo.AutoSize = true;
            lblSoTienNo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoTienNo.ForeColor = Color.FromArgb(231, 76, 60);
            lblSoTienNo.Location = new Point(568, 78);
            lblSoTienNo.Name = "lblSoTienNo";
            lblSoTienNo.Size = new Size(246, 30);
            lblSoTienNo.TabIndex = 6;
            lblSoTienNo.Text = "Số tiền đang nợ: 0 VNĐ";
            // 
            // txtSoTienThu
            // 
            txtSoTienThu.Font = new Font("Segoe UI", 10F);
            txtSoTienThu.Location = new Point(6, 45);
            txtSoTienThu.Name = "txtSoTienThu";
            txtSoTienThu.Size = new Size(300, 25);
            txtSoTienThu.TabIndex = 7;
            txtSoTienThu.TextChanged += txtSoTienThu_TextChanged;
            // 
            // btnThu
            // 
            btnThu.BackColor = Color.FromArgb(46, 204, 113);
            btnThu.FlatAppearance.BorderSize = 0;
            btnThu.FlatStyle = FlatStyle.Flat;
            btnThu.Font = new Font("Segoe UI", 10F);
            btnThu.ForeColor = Color.White;
            btnThu.Location = new Point(626, 553);
            btnThu.Name = "btnThu";
            btnThu.Size = new Size(150, 35);
            btnThu.TabIndex = 8;
            btnThu.Text = "💰 Thu Tiền";
            btnThu.UseVisualStyleBackColor = false;
            btnThu.Click += btnLuu_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(782, 553);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "🔄 Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(231, 76, 60);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(888, 553);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 35);
            btnHuy.TabIndex = 10;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // grpPTT
            // 
            grpPTT.Controls.Add(lbNTT);
            grpPTT.Controls.Add(txtDiaChi);
            grpPTT.Controls.Add(cboKhachHang);
            grpPTT.Controls.Add(txtEmail);
            grpPTT.Controls.Add(txtDienThoai);
            grpPTT.Controls.Add(dtpNgayThu);
            grpPTT.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPTT.Location = new Point(58, 96);
            grpPTT.Name = "grpPTT";
            grpPTT.Size = new Size(888, 237);
            grpPTT.TabIndex = 11;
            grpPTT.TabStop = false;
            grpPTT.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // lbNTT
            // 
            lbNTT.AutoSize = true;
            lbNTT.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNTT.Location = new Point(632, 21);
            lbNTT.Name = "lbNTT";
            lbNTT.Size = new Size(93, 17);
            lbNTT.TabIndex = 6;
            lbNTT.Text = "Ngày thu tiền";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSoTienThu);
            groupBox1.Controls.Add(lblSoTienNo);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(58, 366);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(888, 168);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "CHI TIẾT THANH TOÁN";
            // 
            // FormPhieuThu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(groupBox1);
            Controls.Add(grpPTT);
            Controls.Add(btnHuy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThu);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPhieuThu";
            StartPosition = FormStartPosition.Manual;
            Text = "Phiếu Thu Tiền";
            Load += FormPhieuThu_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpPTT.ResumeLayout(false);
            grpPTT.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private DateTimePicker dtpNgayThu;
        private ComboBox cboKhachHang;
        private TextBox txtDiaChi;
        private TextBox txtDienThoai;
        private TextBox txtEmail;
        private Label lblSoTienNo;
        private TextBox txtSoTienThu;
        private Button btnThu;
        private Button btnLamMoi;
        private Button btnHuy;
        private GroupBox grpPTT;
        private GroupBox groupBox1;
        private Label lbNTT;
    }
}