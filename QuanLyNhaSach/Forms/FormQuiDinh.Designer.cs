namespace QuanLyNhaSach
{
    partial class FormQuiDinh
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
            btnLuu = new Button();
            dgvQuiDinh = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuiDinh).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormDesc);
            pnlHeader.Controls.Add(btnLuu);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
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
            lblFormTitle.Size = new Size(300, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "THAY ĐỔI QUI ĐỊNH";

            // lblFormDesc
            lblFormDesc.AutoSize = true;
            lblFormDesc.Font = new Font("Segoe UI", 9F);
            lblFormDesc.ForeColor = Color.Gray;
            lblFormDesc.Location = new Point(20, 38);
            lblFormDesc.Name = "lblFormDesc";
            lblFormDesc.Size = new Size(250, 15);
            lblFormDesc.TabIndex = 1;
            lblFormDesc.Text = "Quản lý các qui định của hệ thống";

            // btnLuu
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(880, 20);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 30);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;

            // dgvQuiDinh
            dgvQuiDinh.BackgroundColor = Color.FromArgb(236, 240, 241);
            dgvQuiDinh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvQuiDinh.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvQuiDinh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvQuiDinh.Dock = DockStyle.Fill;
            dgvQuiDinh.Location = new Point(0, 60);
            dgvQuiDinh.Name = "dgvQuiDinh";
            dgvQuiDinh.Size = new Size(1000, 540);
            dgvQuiDinh.TabIndex = 3;

            // FormQuiDinh
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvQuiDinh);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormQuiDinh";
            StartPosition = FormStartPosition.Manual;
            Text = "Qui Định";
            Load += FormQuiDinh_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuiDinh).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Label lblFormDesc;
        private Button btnLuu;
        private DataGridView dgvQuiDinh;
    }
}
