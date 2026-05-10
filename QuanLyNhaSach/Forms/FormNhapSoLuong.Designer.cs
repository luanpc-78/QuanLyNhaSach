namespace QuanLyNhaSach
{
    partial class FormNhapSoLuong
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
            lblThongBao = new Label();
            txtSoLuong = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblThongBao
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThongBao.Location = new Point(20, 20);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(250, 19);
            lblThongBao.TabIndex = 0;
            lblThongBao.Text = "Nhập số lượng sách:";

            // txtSoLuong
            txtSoLuong.Font = new Font("Segoe UI", 11F);
            txtSoLuong.Location = new Point(20, 50);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(340, 27);
            txtSoLuong.TabIndex = 1;
            txtSoLuong.KeyDown += txtSoLuong_KeyDown;

            // btnOK
            btnOK.BackColor = Color.FromArgb(46, 204, 113);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 10F);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(125, 100);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;

            // btnCancel
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(235, 100);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // FormNhapSoLuong
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(380, 160);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtSoLuong);
            Controls.Add(lblThongBao);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNhapSoLuong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập Số Lượng";
            Load += FormNhapSoLuong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblThongBao;
        private TextBox txtSoLuong;
        private Button btnOK;
        private Button btnCancel;
    }
}
