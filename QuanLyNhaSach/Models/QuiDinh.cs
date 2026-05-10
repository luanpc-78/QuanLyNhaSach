namespace QuanLyNhaSach.Models
{
    public class QuiDinh
    {
        public int MaQD { get; set; }
        public string TenQD { get; set; }
        public int? GiaTri { get; set; }
        public decimal? GiaTriTien { get; set; }
        public bool ApDung { get; set; }
    }
}