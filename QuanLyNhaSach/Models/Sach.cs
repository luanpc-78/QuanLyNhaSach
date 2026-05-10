namespace QuanLyNhaSach.Models
{
    public class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; } = string.Empty;
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; } = string.Empty;
        public string? TacGia { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGia { get; set; }
    }
}