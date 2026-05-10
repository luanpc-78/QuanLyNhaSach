#nullable enable
namespace QuanLyNhaSach.Models
{
    public class NguoiDung
    {
        public int MaND { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public string? HoTen { get; set; }
        public string? Email { get; set; }
        public string? VaiTro { get; set; }  // Admin, NhanVien
        public bool TrangThai { get; set; }  // true = Active, false = Locked
        public DateTime NgayTao { get; set; }

        public NguoiDung() { }

        public NguoiDung(int maNd, string tenDangNhap, string hoTen, string email, string vaiTro, bool trangThai)
        {
            MaND = maNd;
            TenDangNhap = tenDangNhap;
            HoTen = hoTen;
            Email = email;
            VaiTro = vaiTro;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{TenDangNhap} - {HoTen} ({VaiTro})";
        }
    }
}
