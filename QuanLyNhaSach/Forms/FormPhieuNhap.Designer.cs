namespace QuanLyNhaSach
{
    partial class FormPhieuNhap
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormDesc = new Label();
            grpThongTin = new GroupBox();
            label2 = new Label();
            dtpNgayNhap = new DateTimePicker();
            lbTvTS = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnThem = new Button();
            grpDanhSach = new GroupBox();
            dgvSachNhap = new DataGridView();
            pnlSummary = new Panel();
            lblTongPhieu = new Label();
            lblSachMoi = new Label();
            lblTongTien = new Label();
            pnlButtons = new Panel();
            btnLuu = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();
            pnlHeader.SuspendLayout();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSachNhap).BeginInit();
            pnlSummary.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormDesc);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1113, 70);
            pnlHeader.TabIndex = 0;
            pnlHeader.AutoSize = true;

            // lblFormTitle
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(212, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "PHIẾU NHẬP SÁCH";

            // lblFormDesc
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.Size = new Size(300, 15);
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Lập phiếu nhập mới | Xem lịch sử nhập kho";

            // grpThongTin (GroupBox thông tin nhập)
            grpThongTin.BackColor = Color.White;
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(dtpNgayNhap);
            grpThongTin.Controls.Add(lbTvTS);
            grpThongTin.Controls.Add(txtTimKiem);
            grpThongTin.Controls.Add(btnTimKiem);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpThongTin.ForeColor = Color.FromArgb(44, 62, 80);
            grpThongTin.Margin = new Padding(20, 10, 20, 10);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1073, 100);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "THÔNG TIN NHẬP SÁCH";

            // label2 - Ngày nhập
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(100, 100, 100);
            label2.Location = new Point(15, 30);
            label2.Name = "label2";
            label2.Size = new Size(71, 17);
            label2.TabIndex = 0;
            label2.Text = "Ngày nhập:";

            // dtpNgayNhap
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Location = new Point(15, 52);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(200, 25);
            dtpNgayNhap.TabIndex = 1;

            // lbTvTS - Tìm kiếm
            lbTvTS.AutoSize = true;
            lbTvTS.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lbTvTS.ForeColor = Color.FromArgb(100, 100, 100);
            lbTvTS.Location = new Point(240, 30);
            lbTvTS.Name = "lbTvTS";
            lbTvTS.Size = new Size(65, 17);
            lbTvTS.TabIndex = 2;
            lbTvTS.Text = "Tìm kiếm:";

            // txtTimKiem
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(240, 52);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên sách, tác giả, mã phiếu...";
            txtTimKiem.Size = new Size(350, 25);
            txtTimKiem.TabIndex = 2;

            // btnTimKiem
            btnTimKiem.BackColor = Color.FromArgb(155, 89, 182);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(600, 52);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 25);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;

            // btnThem
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(710, 52);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 25);
            btnThem.TabIndex = 4;
            btnThem.Text = "➕ Thêm Sách";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;

            // grpDanhSach (GroupBox danh sách)
            grpDanhSach.BackColor = Color.White;
            grpDanhSach.Controls.Add(dgvSachNhap);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDanhSach.ForeColor = Color.FromArgb(44, 62, 80);
            grpDanhSach.Margin = new Padding(20, 10, 20, 10);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "DANH SÁCH NHẬP KHO (Lịch sử + Phiếu hiện tại)";

            // dgvSachNhap
            dgvSachNhap.AllowUserToAddRows = false;
            dgvSachNhap.AllowUserToDeleteRows = false;
            dgvSachNhap.BackgroundColor = Color.White;
            dgvSachNhap.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSachNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSachNhap.ColumnHeadersHeight = 35;
            dgvSachNhap.Dock = DockStyle.Fill;
            dgvSachNhap.EnableHeadersVisualStyles = false;
            dgvSachNhap.Location = new Point(3, 21);
            dgvSachNhap.Name = "dgvSachNhap";
            dgvSachNhap.ReadOnly = true;
            dgvSachNhap.RowHeadersVisible = false;
            dgvSachNhap.RowTemplate.Height = 30;
            dgvSachNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSachNhap.Size = new Size(1067, 316);
            dgvSachNhap.TabIndex = 0;

            // pnlSummary (Panel thông tin tổng kết)
            pnlSummary.BackColor = Color.FromArgb(236, 240, 241);
            pnlSummary.Controls.Add(lblTongPhieu);
            pnlSummary.Controls.Add(lblSachMoi);
            pnlSummary.Controls.Add(lblTongTien);
            pnlSummary.Dock = DockStyle.Bottom;
            pnlSummary.Margin = new Padding(20, 10, 20, 10);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(1073, 60);
            pnlSummary.TabIndex = 3;

            // lblTongPhieu
            lblTongPhieu.AutoSize = true;
            lblTongPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongPhieu.ForeColor = Color.FromArgb(44, 62, 80);
            lblTongPhieu.Location = new Point(15, 15);
            lblTongPhieu.Name = "lblTongPhieu";
            lblTongPhieu.Size = new Size(180, 19);
            lblTongPhieu.TabIndex = 0;
            lblTongPhieu.Text = "📦 Tổng phiếu đã nhập: 0";

            // lblSachMoi
            lblSachMoi.AutoSize = true;
            lblSachMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSachMoi.ForeColor = Color.FromArgb(46, 204, 113);
            lblSachMoi.Location = new Point(300, 15);
            lblSachMoi.Name = "lblSachMoi";
            lblSachMoi.Size = new Size(200, 19);
            lblSachMoi.TabIndex = 1;
            lblSachMoi.Text = "➕ Sách trong phiếu hiện tại: 0";

            // lblTongTien
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongTien.Location = new Point(700, 14);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(260, 20);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "💰 Tổng tiền phiếu hiện tại: 0 VNĐ";

            // pnlButtons (Panel chứa nút)
            pnlButtons.BackColor = Color.White;
            pnlButtons.Controls.Add(btnLuu);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Margin = new Padding(20, 10, 20, 20);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1073, 60);
            pnlButtons.TabIndex = 4;

            // btnLuu
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(700, 8);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(150, 35);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "💾 Lưu Phiếu Nhập";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;

            // btnLamMoi
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(870, 8);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "🔄 Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            // btnHuy
            btnHuy.BackColor = Color.FromArgb(231, 76, 60);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(990, 8);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 35);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;

            // FormPhieuNhap
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 800);
            Controls.Add(pnlButtons);
            Controls.Add(pnlSummary);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = true;
            MinimumSize = new Size(900, 600);
            Name = "FormPhieuNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phiếu Nhập Sách";
            Load += FormPhieuNhap_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSachNhap).EndInit();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private GroupBox grpThongTin;
        private Label label2;
        private DateTimePicker dtpNgayNhap;
        private Label lbTvTS;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnThem;
        private GroupBox grpDanhSach;
        private DataGridView dgvSachNhap;
        private Panel pnlSummary;
        private Label lblTongPhieu;
        private Label lblSachMoi;
        private Label lblTongTien;
        private Panel pnlButtons;
        private Button btnLuu;
        private Button btnLamMoi;
        private Button btnHuy;
    }
}