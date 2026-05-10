namespace QuanLyNhaSach
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            lblTitle = new Label();
            picLogo = new PictureBox();
            grpLogin = new GroupBox();
            lblFooter = new Label();
            btnLogin = new Button();
            lnkForgot = new LinkLabel();
            chkRemember = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            grpLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Blue;
            lblTitle.Location = new Point(85, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 32);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "QUẢN LÝ NHÀ SÁCH";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(140, 60);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(120, 100);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 3;
            picLogo.TabStop = false;
            // 
            // grpLogin
            // 
            grpLogin.Controls.Add(lblFooter);
            grpLogin.Controls.Add(btnLogin);
            grpLogin.Controls.Add(lnkForgot);
            grpLogin.Controls.Add(chkRemember);
            grpLogin.Controls.Add(txtPassword);
            grpLogin.Controls.Add(lblPassword);
            grpLogin.Controls.Add(txtUsername);
            grpLogin.Controls.Add(lblUsername);
            grpLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpLogin.ForeColor = Color.SlateGray;
            grpLogin.Location = new Point(30, 180);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(340, 231);
            grpLogin.TabIndex = 4;
            grpLogin.TabStop = false;
            grpLogin.Text = "THÔNG TIN ĐĂNG NHẬP";
            grpLogin.Enter += grpLogin_Enter;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Location = new Point(6, 213);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(124, 15);
            lblFooter.TabIndex = 5;
            lblFooter.Text = "© 2026 Nhà Sách ABC";
            lblFooter.Click += lblFooter_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightSlateGray;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(94, 152);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 40);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkForgot
            // 
            lnkForgot.AutoSize = true;
            lnkForgot.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnkForgot.Location = new Point(220, 120);
            lnkForgot.Name = "lnkForgot";
            lnkForgot.Size = new Size(97, 15);
            lnkForgot.TabIndex = 5;
            lnkForgot.TabStop = true;
            lnkForgot.Text = "Quên mật khẩu?";
            lnkForgot.LinkClicked += lnkForgot_LinkClicked;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkRemember.Location = new Point(20, 120);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(131, 19);
            chkRemember.TabIndex = 4;
            chkRemember.Text = "Ghi nhớ đăng nhập";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(110, 72);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(200, 25);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 75);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 17);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(110, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 25);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 35);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(72, 17);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 433);
            Controls.Add(grpLogin);
            Controls.Add(picLogo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            grpLogin.ResumeLayout(false);
            grpLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private PictureBox picLogo;
        private GroupBox grpLogin;
        private Label lblFooter;
        private Button btnLogin;
        private LinkLabel lnkForgot;
        private CheckBox chkRemember;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
    }
}