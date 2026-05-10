namespace QuanLyNhaSach
{
    partial class FormTimKiemSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            txtTimKiem = new TextBox();
            dgvKetQua = new DataGridView();
            btnChon = new Button();
            btnHuy = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(txtTimKiem);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 80);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔍 Tìm Kiếm Sách";

            // txtTimKiem
            txtTimKiem.Font = new Font("Segoe UI", 11F);
            txtTimKiem.Location = new Point(20, 45);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên sách, tác giả, hoặc thể loại...";
            txtTimKiem.Size = new Size(860, 27);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // dgvKetQua
            dgvKetQua.BackgroundColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKetQua.Location = new Point(20, 100);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.Size = new Size(860, 400);
            dgvKetQua.TabIndex = 1;
            dgvKetQua.DoubleClick += dgvKetQua_DoubleClick;

            // btnChon
            btnChon.BackColor = Color.FromArgb(46, 204, 113);
            btnChon.FlatAppearance.BorderSize = 0;
            btnChon.FlatStyle = FlatStyle.Flat;
            btnChon.Font = new Font("Segoe UI", 10F);
            btnChon.ForeColor = Color.White;
            btnChon.Location = new Point(670, 520);
            btnChon.Name = "btnChon";
            btnChon.Size = new Size(100, 35);
            btnChon.TabIndex = 2;
            btnChon.Text = "✓ Chọn";
            btnChon.UseVisualStyleBackColor = false;
            btnChon.Click += btnChon_Click;

            // btnHuy
            btnHuy.BackColor = Color.FromArgb(231, 76, 60);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(780, 520);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 35);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "✕ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;

            // FormTimKiemSach
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(900, 575);
            Controls.Add(btnHuy);
            Controls.Add(btnChon);
            Controls.Add(dgvKetQua);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTimKiemSach";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tìm Kiếm Sách";
            Load += FormTimKiemSach_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private TextBox txtTimKiem;
        private DataGridView dgvKetQua;
        private Button btnChon;
        private Button btnHuy;
    }
}
