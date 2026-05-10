using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public class BillItem
    {
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }

    public partial class FormInBill : Form
    {
        // ── Dữ liệu hóa đơn ──────────────────────────────────────────
        private int _maHD;
        private string _tenKhachHang;
        private DateTime _ngayLap;
        private List<BillItem> _items;
        private decimal _tongTien;

        // ── In ───────────────────────────────────────────────────────
        private PrintDocument _printDoc;

        // Bill nhiệt 80mm ≈ 302 pixel ở 96dpi; dùng điểm (points) khi in
        private const float BILL_WIDTH_MM = 80f;

        public FormInBill(int maHD, string tenKhachHang, DateTime ngayLap,
                          List<BillItem> items, decimal tongTien)
        {
            _maHD = maHD;
            _tenKhachHang = tenKhachHang;
            _ngayLap = ngayLap;
            _items = items;
            _tongTien = tongTien;

            InitializeComponent();
            SetupPrintDocument();
            RenderPreview();
        }

        // ═══════════════════════════════════════════════════════════════
        // 1. CẤU HÌNH PRINTDOCUMENT
        // ═══════════════════════════════════════════════════════════════
        private void SetupPrintDocument()
        {
            _printDoc = new PrintDocument();
            _printDoc.PrintPage += PrintDoc_PrintPage;

            // Đặt khổ giấy 80mm × 200mm (tối thiểu; máy nhiệt tự cắt)
            PaperSize thermalSize = new PaperSize("Thermal80mm",
                mmToHundredthInch(80), mmToHundredthInch(200));
            _printDoc.DefaultPageSettings.PaperSize = thermalSize;
            _printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
        }

        private static int mmToHundredthInch(float mm) =>
            (int)Math.Round(mm / 25.4f * 100);

        // ═══════════════════════════════════════════════════════════════
        // 2. VẼ BILL (dùng chung cho Print & Preview)
        // ═══════════════════════════════════════════════════════════════
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DrawBill(e.Graphics, e.MarginBounds);
            e.HasMorePages = false;
        }

        private void DrawBill(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float x = bounds.Left;
            float w = bounds.Width;
            float y = bounds.Top;

            // ── Fonts ──
            Font fShop   = new Font("Courier New", 11, FontStyle.Bold);
            Font fTitle  = new Font("Courier New", 9, FontStyle.Bold);
            Font fNormal = new Font("Courier New", 8, FontStyle.Regular);
            Font fSmall  = new Font("Courier New", 7, FontStyle.Regular);
            Font fTotal  = new Font("Courier New", 10, FontStyle.Bold);

            StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat sfRight  = new StringFormat { Alignment = StringAlignment.Far };
            StringFormat sfLeft   = new StringFormat { Alignment = StringAlignment.Near };

            float lineH = 14f;

            // ── Header ──
            g.DrawString("NHÀ SÁCH ABC", fShop, Brushes.Black,
                new RectangleF(x, y, w, 20), sfCenter);
            y += 18;
            g.DrawString("123 Đường Sách, Q.1, TP.HCM", fSmall, Brushes.Black,
                new RectangleF(x, y, w, 14), sfCenter);
            y += 13;
            g.DrawString("ĐT: 028 1234 5678", fSmall, Brushes.Black,
                new RectangleF(x, y, w, 14), sfCenter);
            y += 16;

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 6;

            g.DrawString("HÓA ĐƠN BÁN HÀNG", fTitle, Brushes.Black,
                new RectangleF(x, y, w, 16), sfCenter);
            y += 16;

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 6;

            // ── Thông tin ──
            g.DrawString($"Mã HD  : #{_maHD:D5}", fNormal, Brushes.Black, x, y); y += lineH;
            g.DrawString($"Ngày   : {_ngayLap:dd/MM/yyyy HH:mm}", fNormal, Brushes.Black, x, y); y += lineH;
            g.DrawString($"KH     : {_tenKhachHang}", fNormal, Brushes.Black, x, y); y += lineH + 2;

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 4;

            // ── Header cột ──
            g.DrawString("Tên sách", fTitle, Brushes.Black, x, y);
            g.DrawString("SL", fTitle, Brushes.Black, new RectangleF(x, y, w - 100, 14), sfRight);
            g.DrawString("T.Tiền", fTitle, Brushes.Black, new RectangleF(x, y, w, 14), sfRight);
            y += lineH;

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 4;

            // ── Chi tiết ──
            foreach (var item in _items)
            {
                // Tên sách (wrap nếu dài)
                string name = item.TenSach.Length > 22
                    ? item.TenSach.Substring(0, 22) + "..." : item.TenSach;
                g.DrawString(name, fNormal, Brushes.Black, x, y);
                y += lineH;

                // Đơn giá × SL = Thành tiền
                string detail = $"  {item.DonGia:N0} x {item.SoLuong}";
                g.DrawString(detail, fSmall, Brushes.Black, x, y);
                g.DrawString($"{item.ThanhTien:N0}", fNormal, Brushes.Black,
                    new RectangleF(x, y, w, 14), sfRight);
                y += lineH + 2;
            }

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 6;

            // ── Tổng tiền ──
            g.DrawString("TỔNG CỘNG:", fTotal, Brushes.Black, x, y);
            g.DrawString($"{_tongTien:N0} VND", fTotal, Brushes.Black,
                new RectangleF(x, y, w, 18), sfRight);
            y += 22;

            DrawDashedLine(g, x, y, x + w, Pens.Black); y += 8;

            // ── Footer ──
            g.DrawString("Cảm ơn quý khách!", fTitle, Brushes.Black,
                new RectangleF(x, y, w, 16), sfCenter);
            y += 15;
            g.DrawString("Hẹn gặp lại!", fSmall, Brushes.Black,
                new RectangleF(x, y, w, 14), sfCenter);
            y += 13;
            g.DrawString($"In lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fSmall, Brushes.Gray,
                new RectangleF(x, y, w, 14), sfCenter);

            // Cleanup
            fShop.Dispose(); fTitle.Dispose(); fNormal.Dispose();
            fSmall.Dispose(); fTotal.Dispose();
        }

        private void DrawDashedLine(Graphics g, float x1, float y, float x2, Pen pen)
        {
            using Pen dashed = new Pen(Color.Black, 0.5f);
            dashed.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(dashed, x1, y, x2, y);
        }

        // ═══════════════════════════════════════════════════════════════
        // 3. RENDER PREVIEW VÀO PICTUREBOX
        // ═══════════════════════════════════════════════════════════════
        private void RenderPreview()
        {
            // Preview width ~302px (80mm @ 96dpi), height tự tính
            int pw = 302;
            int ph = 600;
            Bitmap bmp = new Bitmap(pw, ph);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            DrawBill(g, new Rectangle(10, 10, pw - 20, ph - 20));

            picPreview.Image?.Dispose();
            picPreview.Image = bmp;
            picPreview.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        // ═══════════════════════════════════════════════════════════════
        // 4. NÚT IN TRỰC TIẾP
        // ═══════════════════════════════════════════════════════════════
        private void btnIn_Click(object sender, EventArgs e)
        {
            using PrintDialog pd = new PrintDialog { Document = _printDoc };
            if (pd.ShowDialog() == DialogResult.OK)
                _printDoc.Print();
        }

        // ═══════════════════════════════════════════════════════════════
        // 5. NÚT XUẤT PDF  (dùng PrintDocument → Microsoft Print to PDF)
        // ═══════════════════════════════════════════════════════════════
        private void btnPDF_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Lưu hóa đơn PDF",
                Filter = "PDF file|*.pdf",
                FileName = $"HoaDon_{_maHD:D5}_{_ngayLap:yyyyMMdd}"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Dùng printer "Microsoft Print to PDF" nếu có
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = "Microsoft Print to PDF";
                ps.PrintToFile = true;
                ps.PrintFileName = sfd.FileName;

                _printDoc.PrinterSettings = ps;
                _printDoc.Print();

                MessageBox.Show($"✅ Đã xuất PDF:\n{sfd.FileName}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset lại printer mặc định
                _printDoc.PrinterSettings = new PrinterSettings();
            }
        }

        // ═══════════════════════════════════════════════════════════════
        // 6. NÚT ĐÓNG
        // ═══════════════════════════════════════════════════════════════
        private void btnDong_Click(object sender, EventArgs e) => this.Close();
    }
}