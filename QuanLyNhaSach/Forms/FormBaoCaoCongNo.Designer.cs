namespace QuanLyNhaSach
{
    partial class FormBaoCaoCongNo
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormDesc = new Label();
            grpThoiGian = new GroupBox();
            lbTg = new Label();
            cboThang = new ComboBox();
            lbNz = new Label();
            numNam = new NumericUpDown();
            btnXemBaoCao = new Button();
            btnLamMoi = new Button();          // ← NÚT MỚI
            dgvBaoCaoCongNo = new DataGridView();
            pnlSummary = new Panel();
            lblTongNoDau = new Label();
            lblTongPhatSinh = new Label();
            lblTongNoCuoi = new Label();
            btnXuat = new Button();
            pnlHeader.SuspendLayout();
            grpThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoCongNo).BeginInit();
            pnlSummary.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────────
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormDesc);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 60);
            pnlHeader.TabIndex = 0;

            // lblFormTitle
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "BÁO CÁO CÔNG NỢ";

            // lblFormDesc
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Báo cáo công nợ khách hàng theo tháng";

            // ── grpThoiGian ───────────────────────────────────────────
            grpThoiGian.BackColor = Color.White;
            grpThoiGian.Controls.Add(lbTg);
            grpThoiGian.Controls.Add(cboThang);
            grpThoiGian.Controls.Add(lbNz);
            grpThoiGian.Controls.Add(numNam);
            grpThoiGian.Controls.Add(btnXemBaoCao);
            grpThoiGian.Controls.Add(btnLamMoi);    // ← thêm vào group
            grpThoiGian.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpThoiGian.ForeColor = Color.FromArgb(44, 62, 80);
            grpThoiGian.Location = new Point(20, 70);
            grpThoiGian.Name = "grpThoiGian";
            grpThoiGian.Size = new Size(960, 80);
            grpThoiGian.TabIndex = 1;
            grpThoiGian.TabStop = false;
            grpThoiGian.Text = "CHỌN THỜI GIAN";

            // lbTg
            lbTg.AutoSize = true;
            lbTg.Font = new Font("Segoe UI", 9.75F);
            lbTg.ForeColor = Color.FromArgb(100, 100, 100);
            lbTg.Location = new Point(15, 30);
            lbTg.Name = "lbTg";
            lbTg.TabIndex = 0;
            lbTg.Text = "Tháng:";

            // cboThang
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.Font = new Font("Segoe UI", 10F);
            cboThang.FormattingEnabled = true;
            cboThang.Items.AddRange(new object[] {
                "Tháng 1","Tháng 2","Tháng 3","Tháng 4","Tháng 5","Tháng 6",
                "Tháng 7","Tháng 8","Tháng 9","Tháng 10","Tháng 11","Tháng 12"
            });
            cboThang.Location = new Point(15, 52);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(120, 25);
            cboThang.TabIndex = 1;

            // lbNz
            lbNz.AutoSize = true;
            lbNz.Font = new Font("Segoe UI", 9.75F);
            lbNz.ForeColor = Color.FromArgb(100, 100, 100);
            lbNz.Location = new Point(155, 30);
            lbNz.Name = "lbNz";
            lbNz.TabIndex = 2;
            lbNz.Text = "Năm:";

            // numNam
            numNam.Font = new Font("Segoe UI", 10F);
            numNam.Location = new Point(155, 52);
            numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numNam.Name = "numNam";
            numNam.Size = new Size(80, 25);
            numNam.TabIndex = 3;
            numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });

            // btnXemBaoCao
            btnXemBaoCao.BackColor = Color.FromArgb(52, 152, 219);
            btnXemBaoCao.FlatAppearance.BorderSize = 0;
            btnXemBaoCao.FlatStyle = FlatStyle.Flat;
            btnXemBaoCao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(260, 52);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(130, 25);
            btnXemBaoCao.TabIndex = 4;
            btnXemBaoCao.Text = "📊 Xem Báo Cáo";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;

            // ── btnLamMoi ─────────────────────────────────────────────
            btnLamMoi.BackColor = Color.FromArgb(230, 126, 34);   // cam
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(410, 52);             // ngay bên phải btnXemBaoCao
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 25);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "🔄 Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            // ── dgvBaoCaoCongNo ───────────────────────────────────────
            dgvBaoCaoCongNo.AllowUserToAddRows = false;
            dgvBaoCaoCongNo.AllowUserToDeleteRows = false;
            dgvBaoCaoCongNo.BackgroundColor = Color.White;
            dgvBaoCaoCongNo.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBaoCaoCongNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBaoCaoCongNo.ColumnHeadersHeight = 35;
            dgvBaoCaoCongNo.EnableHeadersVisualStyles = false;
            dgvBaoCaoCongNo.Location = new Point(20, 160);
            dgvBaoCaoCongNo.Name = "dgvBaoCaoCongNo";
            dgvBaoCaoCongNo.ReadOnly = true;
            dgvBaoCaoCongNo.RowHeadersVisible = false;
            dgvBaoCaoCongNo.RowTemplate.Height = 30;
            dgvBaoCaoCongNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCaoCongNo.Size = new Size(960, 320);
            dgvBaoCaoCongNo.TabIndex = 2;

            // ── pnlSummary ────────────────────────────────────────────
            pnlSummary.BackColor = Color.FromArgb(236, 240, 241);
            pnlSummary.Controls.Add(lblTongNoDau);
            pnlSummary.Controls.Add(lblTongPhatSinh);
            pnlSummary.Controls.Add(lblTongNoCuoi);
            pnlSummary.Controls.Add(btnXuat);
            pnlSummary.Location = new Point(20, 490);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(960, 80);
            pnlSummary.TabIndex = 3;

            // lblTongNoDau
            lblTongNoDau.AutoSize = true;
            lblTongNoDau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongNoDau.ForeColor = Color.FromArgb(44, 62, 80);
            lblTongNoDau.Location = new Point(15, 15);
            lblTongNoDau.Name = "lblTongNoDau";
            lblTongNoDau.TabIndex = 0;
            lblTongNoDau.Text = "📊 Tổng nợ đầu: 0 VNĐ";

            // lblTongPhatSinh
            lblTongPhatSinh.AutoSize = true;
            lblTongPhatSinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongPhatSinh.ForeColor = Color.FromArgb(52, 152, 219);
            lblTongPhatSinh.Location = new Point(300, 15);
            lblTongPhatSinh.Name = "lblTongPhatSinh";
            lblTongPhatSinh.TabIndex = 1;
            lblTongPhatSinh.Text = "📈 Tổng phát sinh: 0 VNĐ";

            // lblTongNoCuoi
            lblTongNoCuoi.AutoSize = true;
            lblTongNoCuoi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongNoCuoi.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongNoCuoi.Location = new Point(15, 45);
            lblTongNoCuoi.Name = "lblTongNoCuoi";
            lblTongNoCuoi.TabIndex = 2;
            lblTongNoCuoi.Text = "💰 Tổng nợ cuối: 0 VNĐ";

            // btnXuat
            btnXuat.BackColor = Color.FromArgb(46, 204, 113);
            btnXuat.FlatAppearance.BorderSize = 0;
            btnXuat.FlatStyle = FlatStyle.Flat;
            btnXuat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXuat.ForeColor = Color.White;
            btnXuat.Location = new Point(820, 20);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(120, 35);
            btnXuat.TabIndex = 3;
            btnXuat.Text = "📥 Xuất Excel";
            btnXuat.UseVisualStyleBackColor = false;
            btnXuat.Click += btnXuat_Click;

            // ── FormBaoCaoCongNo ──────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 580);
            Controls.Add(pnlSummary);
            Controls.Add(dgvBaoCaoCongNo);
            Controls.Add(grpThoiGian);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBaoCaoCongNo";
            StartPosition = FormStartPosition.Manual;
            Text = "Báo Cáo Công Nợ";
            Load += FormBaoCaoCongNo_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpThoiGian.ResumeLayout(false);
            grpThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoCongNo).EndInit();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private GroupBox grpThoiGian;
        private Label lbTg;
        private ComboBox cboThang;
        private Label lbNz;
        private NumericUpDown numNam;
        private Button btnXemBaoCao;
        private Button btnLamMoi;          // ← khai báo field
        private DataGridView dgvBaoCaoCongNo;
        private Panel pnlSummary;
        private Label lblTongNoDau;
        private Label lblTongPhatSinh;
        private Label lblTongNoCuoi;
        private Button btnXuat;
    }
}