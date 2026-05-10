namespace QuanLyNhaSach
{
    partial class FormHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormDesc = new Label();
            dtpNgayLap = new DateTimePicker();
            cboKhachHang = new ComboBox();
            cboSach = new ComboBox();
            txtSoLuong = new TextBox();
            btnThem = new Button();
            dgvChiTietHD = new DataGridView();
            lblTongTien = new Label();
            btnLuu = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();
            grpHDBS = new GroupBox();
            lbKH = new Label();
            lbNL = new Label();
            groupBox1 = new GroupBox();
            lbS = new Label();
            lbSL = new Label();
            btnInBill = new Button();
            grpDSMDC = new GroupBox();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).BeginInit();
            grpHDBS.SuspendLayout();
            groupBox1.SuspendLayout();
            grpDSMDC.SuspendLayout();
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
            lblFormTitle.Size = new Size(234, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "HÓA ĐƠN BÁN SÁCH";
            // 
            // lblFormDesc
            // 
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.Size = new Size(147, 15);
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Lập hóa đơn bán sách mới";
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.Font = new Font("Segoe UI", 10F);
            dtpNgayLap.Format = DateTimePickerFormat.Short;
            dtpNgayLap.Location = new Point(706, 32);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(187, 25);
            dtpNgayLap.TabIndex = 1;
            // 
            // cboKhachHang
            // 
            cboKhachHang.Font = new Font("Segoe UI", 10F);
            cboKhachHang.Location = new Point(96, 34);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(342, 25);
            cboKhachHang.TabIndex = 2;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            // 
            // cboSach
            // 
            cboSach.Font = new Font("Segoe UI", 10F);
            cboSach.Location = new Point(85, 32);
            cboSach.Name = "cboSach";
            cboSach.Size = new Size(342, 25);
            cboSach.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(600, 32);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(100, 25);
            txtSoLuong.TabIndex = 4;
            txtSoLuong.TextAlign = HorizontalAlignment.Center;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(814, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 25);
            btnThem.TabIndex = 5;
            btnThem.Text = "+ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvChiTietHD
            // 
            dgvChiTietHD.BackgroundColor = Color.White;
            dgvChiTietHD.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChiTietHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChiTietHD.ColumnHeadersHeight = 35;
            dgvChiTietHD.Location = new Point(6, 32);
            dgvChiTietHD.Name = "dgvChiTietHD";
            dgvChiTietHD.RowTemplate.Height = 30;
            dgvChiTietHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHD.Size = new Size(887, 279);
            dgvChiTietHD.TabIndex = 6;
            dgvChiTietHD.CellClick += dgvChiTietHD_CellClick;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongTien.Location = new Point(16, 323);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(165, 25);
            lblTongTien.TabIndex = 7;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(531, 317);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(150, 35);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "💾 Lưu Hóa Đơn";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(687, 317);
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
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(793, 317);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 35);
            btnHuy.TabIndex = 10;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // grpHDBS
            // 
            grpHDBS.Controls.Add(lbNL);
            grpHDBS.Controls.Add(lbKH);
            grpHDBS.Controls.Add(cboKhachHang);
            grpHDBS.Controls.Add(dtpNgayLap);
            grpHDBS.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpHDBS.Location = new Point(50, 69);
            grpHDBS.Name = "grpHDBS";
            grpHDBS.Size = new Size(900, 74);
            grpHDBS.TabIndex = 11;
            grpHDBS.TabStop = false;
            grpHDBS.Text = "THÔNG TIN HOÁ ĐƠN";
            // 
            // lbKH
            // 
            lbKH.AutoSize = true;
            lbKH.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbKH.Location = new Point(6, 37);
            lbKH.Name = "lbKH";
            lbKH.Size = new Size(84, 17);
            lbKH.TabIndex = 3;
            lbKH.Text = "Khách hàng:";
            // 
            // lbNL
            // 
            lbNL.AutoSize = true;
            lbNL.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lbNL.Location = new Point(629, 35);
            lbNL.Name = "lbNL";
            lbNL.Size = new Size(71, 17);
            lbNL.TabIndex = 4;
            lbNL.Text = "Ngày  lập:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbSL);
            groupBox1.Controls.Add(lbS);
            groupBox1.Controls.Add(cboSach);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(50, 149);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(900, 75);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÊM SÁCH";
            // 
            // lbS
            // 
            lbS.AutoSize = true;
            lbS.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lbS.Location = new Point(6, 37);
            lbS.Name = "lbS";
            lbS.Size = new Size(40, 17);
            lbS.TabIndex = 6;
            lbS.Text = "Sách:";
            // 
            // lbSL
            // 
            lbSL.AutoSize = true;
            lbSL.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lbSL.Location = new Point(526, 37);
            lbSL.Name = "lbSL";
            lbSL.Size = new Size(68, 17);
            lbSL.TabIndex = 7;
            lbSL.Text = "Số lượng:";
            lbSL.Click += lbSL_Click;
            // 
            btnInBill.Text = "🖨 In Bill";
            btnInBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInBill.BackColor = Color.FromArgb(52, 152, 219);
            btnInBill.ForeColor = Color.White;
            btnInBill.FlatStyle = FlatStyle.Flat;
            btnInBill.FlatAppearance.BorderSize = 0;
            btnInBill.Size = new Size(120, 35);
            btnInBill.Location = new Point(375, 317);   // Đặt trước btnLuu
            btnInBill.Enabled = false;                 // Chỉ bật sau khi lưu
            btnInBill.Click += btnInBill_Click;
            // grpDSMDC
            // 
            grpDSMDC.Controls.Add(dgvChiTietHD);
            grpDSMDC.Controls.Add(lblTongTien);
            grpDSMDC.Controls.Add(btnHuy);
            grpDSMDC.Controls.Add(btnLuu);
            grpDSMDC.Controls.Add(btnLamMoi);
            grpDSMDC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDSMDC.Location = new Point(50, 230);
            grpDSMDC.Name = "grpDSMDC";
            grpDSMDC.Size = new Size(900, 358);
            grpDSMDC.TabIndex = 13;
            grpDSMDC.TabStop = false;
            grpDSMDC.Text = "DANH SÁCH MẶT HÀNG ĐÃ CHỌN";
            grpDSMDC.Controls.Add(btnInBill);
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(grpDSMDC);
            Controls.Add(groupBox1);
            Controls.Add(grpHDBS);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHoaDon";
            StartPosition = FormStartPosition.Manual;
            Text = "Hóa Đơn Bán Sách";
            Load += FormHoaDon_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).EndInit();
            grpHDBS.ResumeLayout(false);
            grpHDBS.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpDSMDC.ResumeLayout(false);
            grpDSMDC.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private DateTimePicker dtpNgayLap;
        private ComboBox cboKhachHang;
        private ComboBox cboSach;
        private TextBox txtSoLuong;
        private Button btnThem;
        private DataGridView dgvChiTietHD;
        private Label lblTongTien;
        private Button btnLuu;
        private Button btnLamMoi;
        private Button btnHuy;
        private GroupBox grpHDBS;
        private Label lbKH;
        private Label lbNL;
        private GroupBox groupBox1;
        private Label lbS;
        private Label lbSL;
        private GroupBox grpDSMDC;
        private Button btnInBill;
    }
}