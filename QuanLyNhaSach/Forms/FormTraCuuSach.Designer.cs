namespace QuanLyNhaSach
{
    partial class FormTraCuuSach
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
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormDesc = new Label();
            txtTenSach = new TextBox();
            cboTheLoai = new ComboBox();
            txtTacGia = new TextBox();
            btnTim = new Button();
            btnLamMoi = new Button();
            btnTaiLai = new Button();
            dgvSach = new DataGridView();
            grpTCS = new GroupBox();
            lblKetQua = new Label();
            label1 = new Label();
            lbTL = new Label();
            lbSz = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            grpTCS.SuspendLayout();
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
            lblFormTitle.Size = new Size(172, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "TRA CỨU SÁCH";
            // 
            // lblFormDesc
            // 
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.Size = new Size(152, 15);
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Tìm kiếm sách theo tiêu chí";
            // 
            // txtTenSach
            // 
            txtTenSach.Font = new Font("Segoe UI", 10F);
            txtTenSach.Location = new Point(6, 50);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.PlaceholderText = "Nhập tên sách...";
            txtTenSach.Size = new Size(250, 25);
            txtTenSach.TabIndex = 1;
            // 
            // cboTheLoai
            // 
            cboTheLoai.Font = new Font("Segoe UI", 10F);
            cboTheLoai.Location = new Point(302, 50);
            cboTheLoai.Name = "cboTheLoai";
            cboTheLoai.Size = new Size(200, 25);
            cboTheLoai.TabIndex = 2;
            // 
            // txtTacGia
            // 
            txtTacGia.Font = new Font("Segoe UI", 10F);
            txtTacGia.Location = new Point(545, 50);
            txtTacGia.Name = "txtTacGia";
            txtTacGia.PlaceholderText = "Nhập tên tác giả...";
            txtTacGia.Size = new Size(200, 25);
            txtTacGia.TabIndex = 3;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(52, 152, 219);
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(816, 32);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(80, 25);
            btnTim.TabIndex = 4;
            btnTim.Text = "🔍 Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTimKiem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(816, 63);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 25);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "🔄 Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.BackColor = Color.FromArgb(46, 204, 113);
            btnTaiLai.FlatAppearance.BorderSize = 0;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaiLai.ForeColor = Color.White;
            btnTaiLai.Location = new Point(816, 94);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(80, 25);
            btnTaiLai.TabIndex = 6;
            btnTaiLai.Text = "🔁 Tải Lại";
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // dgvSach
            // 
            dgvSach.BackgroundColor = Color.White;
            dgvSach.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSach.ColumnHeadersHeight = 35;
            dgvSach.Location = new Point(46, 200);
            dgvSach.Name = "dgvSach";
            dgvSach.RowTemplate.Height = 30;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.Size = new Size(908, 388);
            dgvSach.TabIndex = 6;
            // 
            // grpTCS
            // 
            grpTCS.BackColor = Color.White;
            grpTCS.Controls.Add(lblKetQua);
            grpTCS.Controls.Add(label1);
            grpTCS.Controls.Add(lbTL);
            grpTCS.Controls.Add(lbSz);
            grpTCS.Controls.Add(txtTenSach);
            grpTCS.Controls.Add(cboTheLoai);
            grpTCS.Controls.Add(btnTim);
            grpTCS.Controls.Add(btnLamMoi);
            grpTCS.Controls.Add(btnTaiLai);
            grpTCS.Controls.Add(txtTacGia);
            grpTCS.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpTCS.Location = new Point(46, 74);
            grpTCS.Name = "grpTCS";
            grpTCS.Size = new Size(908, 120);
            grpTCS.TabIndex = 7;
            grpTCS.TabStop = false;
            grpTCS.Text = "THÔNG TIN TRA CỨU";
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblKetQua.ForeColor = Color.Gray;
            lblKetQua.Location = new Point(6, 95);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(108, 15);
            lblKetQua.TabIndex = 9;
            lblKetQua.Text = "Tổng số: 0 cuốn sách";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(545, 30);
            label1.Name = "label1";
            label1.Size = new Size(51, 17);
            label1.TabIndex = 8;
            label1.Text = "Tác giả";
            // 
            // lbTL
            // 
            lbTL.AutoSize = true;
            lbTL.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTL.Location = new Point(302, 30);
            lbTL.Name = "lbTL";
            lbTL.Size = new Size(58, 17);
            lbTL.TabIndex = 7;
            lbTL.Text = "Thể loại";
            // 
            // lbSz
            // 
            lbSz.AutoSize = true;
            lbSz.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSz.Location = new Point(6, 30);
            lbSz.Name = "lbSz";
            lbSz.Size = new Size(61, 17);
            lbSz.TabIndex = 6;
            lbSz.Text = "Tên sách";
            // 
            // FormTraCuuSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(grpTCS);
            Controls.Add(dgvSach);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTraCuuSach";
            StartPosition = FormStartPosition.Manual;
            Text = "Tra Cứu Sách";
            Load += FormTraCuuSach_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            grpTCS.ResumeLayout(false);
            grpTCS.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private TextBox txtTenSach;
        private ComboBox cboTheLoai;
        private TextBox txtTacGia;
        private Button btnTim;
        private Button btnLamMoi;
        private Button btnTaiLai;
        private DataGridView dgvSach;
        private GroupBox grpTCS;
        private Label lbTL;
        private Label lbSz;
        private Label label1;
        private Label lblKetQua;
    }
}