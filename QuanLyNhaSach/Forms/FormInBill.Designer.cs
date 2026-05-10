namespace QuanLyNhaSach
{
    partial class FormInBill
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlLeft        = new Panel();
            picPreview     = new PictureBox();
            pnlRight       = new Panel();
            pnlHeader      = new Panel();
            lblTitle       = new Label();
            lblSubtitle    = new Label();
            grpPreview     = new GroupBox();
            pnlScroll      = new Panel();
            grpActions     = new GroupBox();
            btnIn          = new Button();
            btnPDF         = new Button();
            btnDong        = new Button();
            lblInfo        = new Label();

            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            pnlRight.SuspendLayout();
            pnlHeader.SuspendLayout();
            grpPreview.SuspendLayout();
            pnlScroll.SuspendLayout();
            grpActions.SuspendLayout();
            SuspendLayout();

            // ── pnlLeft (preview bên trái) ───────────────────────────
            pnlLeft.BackColor   = Color.FromArgb(236, 240, 241);
            pnlLeft.Dock        = DockStyle.Left;
            pnlLeft.Width       = 400;
            pnlLeft.Controls.Add(grpPreview);

            // ── grpPreview ───────────────────────────────────────────
            grpPreview.Text      = "👁 XEM TRƯỚC HÓA ĐƠN";
            grpPreview.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPreview.ForeColor = Color.FromArgb(44, 62, 80);
            grpPreview.BackColor = Color.FromArgb(236, 240, 241);
            grpPreview.Location  = new Point(15, 15);
            grpPreview.Size      = new Size(370, 560);
            grpPreview.Controls.Add(pnlScroll);

            // ── pnlScroll (cuộn được) ────────────────────────────────
            pnlScroll.AutoScroll  = true;
            pnlScroll.BackColor   = Color.FromArgb(200, 200, 200);
            pnlScroll.Dock        = DockStyle.Fill;
            pnlScroll.Padding     = new Padding(30, 15, 30, 15);
            pnlScroll.Controls.Add(picPreview);

            // ── picPreview ───────────────────────────────────────────
            picPreview.BackColor  = Color.White;
            picPreview.Location   = new Point(30, 15);
            picPreview.BorderStyle = BorderStyle.FixedSingle;

            // ── pnlRight (nút bên phải) ──────────────────────────────
            pnlRight.BackColor = Color.White;
            pnlRight.Dock      = DockStyle.Fill;
            pnlRight.Controls.Add(pnlHeader);
            pnlRight.Controls.Add(grpActions);

            // ── pnlHeader ────────────────────────────────────────────
            pnlHeader.BackColor = Color.White;
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 70;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // ── lblTitle ─────────────────────────────────────────────
            lblTitle.Text      = "IN HÓA ĐƠN";
            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 12);

            // ── lblSubtitle ──────────────────────────────────────────
            lblSubtitle.Text      = "Bill nhiệt 80mm | Preview · In máy · Xuất PDF";
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.AutoSize  = true;
            lblSubtitle.Location  = new Point(22, 42);

            // ── grpActions ───────────────────────────────────────────
            grpActions.Text      = "THAO TÁC";
            grpActions.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpActions.ForeColor = Color.FromArgb(44, 62, 80);
            grpActions.Location  = new Point(20, 90);
            grpActions.Size      = new Size(340, 260);
            grpActions.Controls.Add(btnIn);
            grpActions.Controls.Add(btnPDF);
            grpActions.Controls.Add(lblInfo);
            grpActions.Controls.Add(btnDong);

            // ── btnIn ────────────────────────────────────────────────
            btnIn.Text             = "🖨  In Trực Tiếp";
            btnIn.Font             = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIn.BackColor        = Color.FromArgb(52, 152, 219);
            btnIn.ForeColor        = Color.White;
            btnIn.FlatStyle        = FlatStyle.Flat;
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.Size             = new Size(300, 50);
            btnIn.Location         = new Point(20, 30);
            btnIn.Cursor           = Cursors.Hand;
            btnIn.Click           += btnIn_Click;

            // ── btnPDF ───────────────────────────────────────────────
            btnPDF.Text            = "📄  Xuất PDF";
            btnPDF.Font            = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPDF.BackColor       = Color.FromArgb(231, 76, 60);
            btnPDF.ForeColor       = Color.White;
            btnPDF.FlatStyle       = FlatStyle.Flat;
            btnPDF.FlatAppearance.BorderSize = 0;
            btnPDF.Size            = new Size(300, 50);
            btnPDF.Location        = new Point(20, 95);
            btnPDF.Cursor          = Cursors.Hand;
            btnPDF.Click          += btnPDF_Click;

            // ── lblInfo ──────────────────────────────────────────────
            lblInfo.Text      = "💡 Để in ra máy nhiệt, chọn đúng\n    máy in trong hộp thoại Print.\n\n" +
                                "💡 Xuất PDF dùng 'Microsoft Print\n    to PDF' (có sẵn trên Windows 10+).";
            lblInfo.Font      = new Font("Segoe UI", 8.5F);
            lblInfo.ForeColor = Color.FromArgb(100, 100, 100);
            lblInfo.Location  = new Point(20, 160);
            lblInfo.Size      = new Size(300, 70);

            // ── btnDong ──────────────────────────────────────────────
            btnDong.Text           = "✖  Đóng";
            btnDong.Font           = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDong.BackColor      = Color.FromArgb(149, 165, 166);
            btnDong.ForeColor      = Color.White;
            btnDong.FlatStyle      = FlatStyle.Flat;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Size           = new Size(300, 38);
            btnDong.Location       = new Point(20, 210);
            btnDong.Cursor         = Cursors.Hand;
            btnDong.Click         += btnDong_Click;

            // ── Form ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.White;
            ClientSize          = new Size(800, 600);
            FormBorderStyle     = FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            StartPosition       = FormStartPosition.CenterParent;
            Text                = "In Hóa Đơn";
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);

            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            pnlRight.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpPreview.ResumeLayout(false);
            pnlScroll.ResumeLayout(false);
            pnlScroll.PerformLayout();
            grpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Controls
        private Panel      pnlLeft, pnlRight, pnlHeader, pnlScroll;
        private PictureBox picPreview;
        private GroupBox   grpPreview, grpActions;
        private Label      lblTitle, lblSubtitle, lblInfo;
        private Button     btnIn, btnPDF, btnDong;
    }
}