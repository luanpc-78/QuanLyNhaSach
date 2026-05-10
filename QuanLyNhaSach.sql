-- ============================================
-- SCRIPT TẠO DATABASE + BẢNG
-- ============================================
CREATE DATABASE QuanLyNhaSach;
GO

USE QuanLyNhaSach;
GO

-- ============================================
-- BẢNG 1: THỂ LOẠI SÁCH
-- ============================================
CREATE TABLE TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL
);
GO

-- ============================================
-- BẢNG 2: SÁCH
-- ============================================
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200) NOT NULL,
    MaTheLoai INT NOT NULL FOREIGN KEY REFERENCES TheLoai(MaTheLoai),
    TacGia NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(10, 2) NOT NULL DEFAULT 0,
    SoLuongTon INT DEFAULT 0,
    NgayNhapCuoi DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- BẢNG 3: KHÁCH HÀNG
-- ============================================
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20),
    Email VARCHAR(100),
    SoTienNo DECIMAL(10, 2) DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- BẢNG 4: NGƯỜI DÙNG
-- ============================================
CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100),
    Email VARCHAR(100),
    VaiTro NVARCHAR(20) DEFAULT N'NhanVien',
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- BẢNG 5: QUI ĐỊNH
-- ============================================
CREATE TABLE QuiDinh (
    MaQD INT PRIMARY KEY,
    TenQD NVARCHAR(200) NOT NULL,
    GiaTri INT,
    GiaTriTien DECIMAL(10, 2),
    ApDung BIT DEFAULT 1,
    MoTa NVARCHAR(500)
);
GO

-- ============================================
-- BẢNG 6: PHIẾU NHẬP SÁCH
-- ============================================
CREATE TABLE PhieuNhap (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongSoLuong INT DEFAULT 0,
    TongTien DECIMAL(10, 2) DEFAULT 0
);
GO

-- ============================================
-- BẢNG 7: CHI TIẾT PHIẾU NHẬP
-- ============================================
CREATE TABLE CT_PhieuNhap (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL FOREIGN KEY REFERENCES PhieuNhap(MaPhieuNhap) ON DELETE CASCADE,
    MaSach INT NOT NULL FOREIGN KEY REFERENCES Sach(MaSach),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(10, 2) NOT NULL DEFAULT 0
);
GO

-- ============================================
-- BẢNG 8: HÓA ĐƠN BÁN SÁCH
-- ============================================
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLapHD DATETIME DEFAULT GETDATE(),
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    TongSoLuong INT DEFAULT 0,
    TongTien DECIMAL(10, 2) DEFAULT 0
);
GO

-- ============================================
-- BẢNG 9: CHI TIẾT HÓA ĐƠN
-- ============================================
CREATE TABLE CT_HoaDon (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaSach INT NOT NULL FOREIGN KEY REFERENCES Sach(MaSach),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(10, 2) NOT NULL
);
GO

-- ============================================
-- BẢNG 10: PHIẾU THU TIỀN
-- ============================================
CREATE TABLE PhieuThu (
    MaPhieuThu INT IDENTITY(1,1) PRIMARY KEY,
    NgayThu DATETIME DEFAULT GETDATE(),
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    SoTienThu DECIMAL(10, 2) NOT NULL,
    GhiChu NVARCHAR(500)
);
GO

-- ============================================
-- BẢNG 11: BÁO CÁO TỒN
-- ============================================
CREATE TABLE BaoCaoTon (
    MaBCT INT IDENTITY(1,1) PRIMARY KEY,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    MaSach INT NOT NULL FOREIGN KEY REFERENCES Sach(MaSach),
    TonDau INT DEFAULT 0,
    PhatSinh INT DEFAULT 0,
    TonCuoi INT DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE(),
    UNIQUE(Thang, Nam, MaSach)
);
GO

-- ============================================
-- BẢNG 12: BÁO CÁO CÔNG NỢ
-- ============================================
CREATE TABLE BaoCaoCongNo (
    MaBCCN INT IDENTITY(1,1) PRIMARY KEY,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    NoDau DECIMAL(10, 2) DEFAULT 0,
    PhatSinh DECIMAL(10, 2) DEFAULT 0,
    NoCuoi DECIMAL(10, 2) DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE(),
    UNIQUE(Thang, Nam, MaKH)
);
GO

-- ============================================
-- TẠO INDEX
-- ============================================
CREATE INDEX IX_Sach_MaTheLoai ON Sach(MaTheLoai);
CREATE INDEX IX_HoaDon_MaKH ON HoaDon(MaKH);
CREATE INDEX IX_PhieuThu_MaKH ON PhieuThu(MaKH);
CREATE INDEX IX_CT_PhieuNhap_MaPhieuNhap ON CT_PhieuNhap(MaPhieuNhap);
CREATE INDEX IX_CT_HoaDon_MaHD ON CT_HoaDon(MaHD);
GO

PRINT '✅ Đã tạo xong tất cả bảng';
GO

-- ============================================
-- NHẬP DỮ LIỆU
-- ============================================

-- 1. THỂ LOẠI
INSERT INTO TheLoai (TenTheLoai) VALUES 
    (N'Văn học'),
    (N'Khoa học - Kỹ thuật'),
    (N'Kinh tế'),
    (N'Giáo dục'),
    (N'Tâm lý - Kỹ năng sống'),
    (N'Lịch sử - Địa lý'),
    (N'Thiếu nhi'),
    (N'Ngoại ngữ'),
    (N'Y học - Sức khỏe'),
    (N'Tôn giáo - Triết học');
GO

-- 2. SÁCH (19 đầu sách)
INSERT INTO Sach (TenSach, MaTheLoai, TacGia, DonGia, SoLuongTon, NgayNhapCuoi) VALUES 
    (N'Truyện Kiều', 1, N'Nguyễn Du', 85000, 200, '2026-01-15'),
    (N'Những người khốn khổ', 1, N'Victor Hugo', 180000, 150, '2026-02-20'),
    (N'Chiếc thuyền ngoài xa', 1, N'Nguyễn Minh Châu', 65000, 300, '2026-03-10'),
    (N'1984', 1, N'George Orwell', 120000, 180, '2026-01-25'),
    (N'Vật lý đại cương', 2, N'Lương Duyên Bình', 95000, 250, '2026-01-10'),
    (N'Giải thuật và lập trình', 2, N'Đỗ Xuân Lôi', 145000, 120, '2026-02-15'),
    (N'Clean Code', 2, N'Robert C. Martin', 220000, 80, '2026-03-05'),
    (N'Kinh tế vi mô', 3, N'Paul Samuelson', 135000, 160, '2026-01-20'),
    (N'Đắc nhân tâm', 3, N'Dale Carnegie', 85000, 400, '2026-02-28'),
    (N'Nhà đầu tư thông minh', 3, N'Benjamin Graham', 195000, 100, '2026-03-15'),
    (N'Toán cao cấp tập 1', 4, N'Nguyễn Đình Trí', 78000, 350, '2026-01-05'),
    (N'Ngữ pháp tiếng Anh', 4, N'Mai Lan Hương', 92000, 280, '2026-02-10'),
    (N'Sức mạnh của thói quen', 5, N'Charles Duhigg', 110000, 220, '2026-01-30'),
    (N'Tư duy nhanh và chậm', 5, N'Daniel Kahneman', 165000, 140, '2026-03-20'),
    (N'Lịch sử Việt Nam', 6, N'Trần Trọng Kim', 195000, 90, '2026-02-05'),
    (N'Dế Mèn phiêu lưu ký', 7, N'Tô Hoài', 55000, 500, '2026-01-08'),
    (N'Harry Potter và Hòn đá phù thủy', 7, N'J.K. Rowling', 145000, 200, '2026-03-01'),
    (N'3000 từ vựng tiếng Anh', 8, N'Oxford', 75000, 450, '2026-02-18'),
    (N'Ăn sạch sống khỏe', 9, N'Michael Pollan', 105000, 170, '2026-03-12');
GO

-- 3. KHÁCH HÀNG (10 người)
INSERT INTO KhachHang (HoTen, DiaChi, DienThoai, Email, SoTienNo, NgayTao) VALUES 
    (N'Phan Công Luận', N'An Giang', '0911111111', 'phancongluan@email.com', 0, '2026-01-10'),
    (N'Nguyễn Quang Hưng', N'TP.HCM', '0922222222', 'nguyenquanghung@email.com', 475000, '2026-01-15'),
    (N'Hồ Lâm Minh Thái', N'Long An', '0933333333', 'holamminhthai@email.com', 75000, '2026-02-01'),
    (N'Nguyễn Tấn Tài', N'TP.HCM', '0944444444', 'nguyentantai@email.com', 895000, '2026-02-10'),
    (N'Ngũ Bảo Khang', N'TP.HCM', '0955555555', 'ngubaokhang@email.com', 1020000, '2026-02-20'),
    (N'Phạm Tuấn Anh', N'Hải Phòng', '0966666666', 'phamtuananh@email.com', 515000, '2026-03-01'),
    (N'Nguyễn Duy Khiêm', N'Long An', '0977777777', 'nguyenduykhiem@email.com', 50000, '2026-03-05'),
    (N'Nguyễn Thị Ngọc Linh', N'TP.HCM', '0988888888', 'nguyenngoclinh@email.com', 585000, '2026-03-10'),
    (N'Nguyễn Văn Hải', N'TP.HCM', '0999999999', 'nguyenvanhai@email.com', 420000, '2026-03-15'),
    (N'Nguyễn Ân Phát', N'TP.HCM', '0900000000', 'nguyenanphat@email.com', 120000, '2026-03-20');
GO

-- 4. NGƯỜI DÙNG (3 người - Mật khẩu: 12)
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro, TrangThai, NgayTao) VALUES 
    ('admin', '12', N'Quản trị viên', 'admin@nhasach.com', N'Admin', 1, '2026-01-01'),
    ('nhanvien1', '12', N'Nguyễn Quang Hưng', 'nguyenquanghung@nhasach.com', N'NhanVien', 1, '2026-01-05'),
    ('nhanvien2', '12', N'Hồ Lâm Minh Thái', 'holamminhthai@nhasach.com', N'NhanVien', 1, '2026-01-05');
GO

-- 5. QUI ĐỊNH
INSERT INTO QuiDinh (MaQD, TenQD, GiaTri, GiaTriTien, ApDung, MoTa) VALUES 
    (1, N'QĐ1: Số lượng nhập tối thiểu', 150, NULL, 1, N'Số lượng nhập ít nhất là 150'),
    (2, N'QĐ2: Lượng tồn tối thiểu trước khi nhập', 300, NULL, 1, N'Chỉ nhập khi lượng tồn < 300'),
    (3, N'QĐ3: Tiền nợ tối đa', NULL, 200000, 1, N'Khách hàng nợ không quá 200,000 VNĐ'),
    (4, N'QĐ4: Lượng tồn tối thiểu sau khi bán', 20, NULL, 1, N'Tồn kho sau bán >= 20 cuốn'),
    (5, N'QĐ5: Qui định thu tiền', NULL, NULL, 1, N'Số tiền thu không vượt quá số tiền khách hàng đang nợ');
GO

-- 6. PHIẾU NHẬP (5 phiếu)
INSERT INTO PhieuNhap (NgayNhap, TongSoLuong, TongTien) VALUES 
    ('2026-01-10', 500, 42500000),
    ('2026-01-25', 350, 33250000),
    ('2026-02-15', 400, 48000000),
    ('2026-03-05', 280, 36400000),
    ('2026-03-18', 450, 47250000);
GO

-- 7. CHI TIẾT PHIẾU NHẬP
INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaSach, SoLuong, DonGia) VALUES 
    (1, 1, 200, 85000),
    (1, 5, 150, 95000),
    (1, 11, 150, 78000),
    (2, 2, 100, 180000),
    (2, 4, 120, 120000),
    (2, 8, 130, 135000),
    (3, 3, 150, 65000),
    (3, 6, 100, 145000),
    (3, 9, 150, 85000),
    (4, 7, 80, 220000),
    (4, 10, 100, 195000),
    (4, 14, 100, 165000),
    (5, 12, 150, 92000),
    (5, 13, 150, 110000),
    (5, 16, 150, 55000);
GO

-- 8. HÓA ĐƠN (8 hóa đơn)
INSERT INTO HoaDon (NgayLapHD, MaKH, TongSoLuong, TongTien) VALUES 
    ('2026-01-15', 2, 5, 445000),
    ('2026-01-20', 1, 3, 285000),
    ('2026-02-05', 4, 8, 920000),
    ('2026-02-14', 2, 4, 380000),
    ('2026-02-25', 6, 6, 615000),
    ('2026-03-08', 5, 10, 1020000),
    ('2026-03-15', 8, 7, 785000),
    ('2026-03-22', 4, 5, 525000);
GO

-- 9. CHI TIẾT HÓA ĐƠN
INSERT INTO CT_HoaDon (MaHD, MaSach, SoLuong, DonGia) VALUES 
    (1, 1, 2, 85000),
    (1, 5, 1, 95000),
    (1, 11, 2, 78000),
    (2, 2, 1, 180000),
    (2, 4, 1, 120000),
    (2, 9, 1, 85000),
    (3, 3, 3, 65000),
    (3, 6, 2, 145000),
    (3, 8, 2, 135000),
    (3, 11, 1, 78000),
    (4, 2, 1, 180000),
    (4, 4, 2, 120000),
    (4, 13, 1, 110000),
    (5, 5, 2, 95000),
    (5, 7, 1, 220000),
    (5, 10, 1, 195000),
    (5, 12, 2, 92000),
    (6, 1, 3, 85000),
    (6, 3, 2, 65000),
    (6, 9, 3, 85000),
    (6, 16, 2, 55000),
    (7, 6, 2, 145000),
    (7, 8, 1, 135000),
    (7, 10, 1, 195000),
    (7, 14, 2, 165000),
    (7, 15, 1, 195000),
    (8, 7, 1, 220000),
    (8, 9, 2, 85000),
    (8, 13, 2, 110000);
GO

-- 10. PHIẾU THU (6 phiếu)
INSERT INTO PhieuThu (NgayThu, MaKH, SoTienThu, GhiChu) VALUES 
    ('2026-01-25', 2, 200000, N'Thu nợ đợt 1 - Hưng'),
    ('2026-02-10', 4, 300000, N'Thu một phần nợ - Tài'),
    ('2026-02-20', 2, 150000, N'Thu hết nợ tháng 1 - Hưng'),
    ('2026-03-05', 6, 100000, N'Thu nợ đợt 1 - Tuấn Anh'),
    ('2026-03-15', 8, 200000, N'Thu một phần - Ngọc Linh'),
    ('2026-03-25', 4, 250000, N'Thu nợ còn lại - Tài');
GO

-- 11. BÁO CÁO TỒN
INSERT INTO BaoCaoTon (Thang, Nam, MaSach, TonDau, PhatSinh, TonCuoi, NgayTao) VALUES 
    (1, 2026, 1, 0, 200, 200, '2026-02-01'),
    (1, 2026, 2, 0, 100, 100, '2026-02-01'),
    (1, 2026, 5, 0, 150, 150, '2026-02-01'),
    (1, 2026, 11, 0, 150, 150, '2026-02-01'),
    (2, 2026, 1, 200, -2, 198, '2026-03-01'),
    (2, 2026, 2, 100, 0, 100, '2026-03-01'),
    (2, 2026, 3, 0, 150, 150, '2026-03-01'),
    (2, 2026, 4, 0, 120, 120, '2026-03-01'),
    (2, 2026, 5, 150, -1, 149, '2026-03-01'),
    (2, 2026, 6, 0, 100, 100, '2026-03-01'),
    (2, 2026, 8, 0, 130, 130, '2026-03-01'),
    (2, 2026, 9, 0, 150, 150, '2026-03-01'),
    (2, 2026, 11, 150, -1, 149, '2026-03-01'),
    (3, 2026, 1, 198, -3, 195, '2026-04-01'),
    (3, 2026, 2, 100, -1, 99, '2026-04-01'),
    (3, 2026, 3, 150, -2, 148, '2026-04-01'),
    (3, 2026, 4, 120, -2, 118, '2026-04-01'),
    (3, 2026, 5, 149, -2, 147, '2026-04-01'),
    (3, 2026, 6, 100, -2, 98, '2026-04-01'),
    (3, 2026, 7, 0, 80, 80, '2026-04-01'),
    (3, 2026, 8, 130, -1, 129, '2026-04-01'),
    (3, 2026, 9, 150, -5, 145, '2026-04-01'),
    (3, 2026, 10, 0, 100, 100, '2026-04-01'),
    (3, 2026, 11, 149, 0, 149, '2026-04-01'),
    (3, 2026, 12, 0, 150, 150, '2026-04-01'),
    (3, 2026, 13, 0, 150, 150, '2026-04-01'),
    (3, 2026, 14, 0, 100, 100, '2026-04-01'),
    (3, 2026, 16, 0, 150, 150, '2026-04-01');
GO

-- 12. BÁO CÁO CÔNG NỢ
INSERT INTO BaoCaoCongNo (Thang, Nam, MaKH, NoDau, PhatSinh, NoCuoi, NgayTao) VALUES 
    (1, 2026, 1, 0, 0, 0, '2026-02-01'),
    (1, 2026, 2, 0, 445000, 445000, '2026-02-01'),
    (1, 2026, 3, 0, 0, 0, '2026-02-01'),
    (1, 2026, 4, 0, 0, 0, '2026-02-01'),
    (1, 2026, 5, 0, 0, 0, '2026-02-01'),
    (1, 2026, 6, 0, 0, 0, '2026-02-01'),
    (1, 2026, 7, 0, 0, 0, '2026-02-01'),
    (1, 2026, 8, 0, 0, 0, '2026-02-01'),
    (1, 2026, 9, 0, 0, 0, '2026-02-01'),
    (1, 2026, 10, 0, 0, 0, '2026-02-01'),
    (2, 2026, 1, 0, 0, 0, '2026-03-01'),
    (2, 2026, 2, 445000, 180000, 475000, '2026-03-01'),
    (2, 2026, 3, 0, 0, 75000, '2026-03-01'),
    (2, 2026, 4, 0, 920000, 920000, '2026-03-01'),
    (2, 2026, 5, 0, 0, 0, '2026-03-01'),
    (2, 2026, 6, 0, 615000, 615000, '2026-03-01'),
    (2, 2026, 7, 0, 0, 50000, '2026-03-01'),
    (2, 2026, 8, 0, 0, 0, '2026-03-01'),
    (2, 2026, 9, 0, 0, 420000, '2026-03-01'),
    (2, 2026, 10, 0, 0, 120000, '2026-03-01'),
    (3, 2026, 1, 0, 0, 0, '2026-04-01'),
    (3, 2026, 2, 475000, 0, 475000, '2026-04-01'),
    (3, 2026, 3, 75000, 0, 75000, '2026-04-01'),
    (3, 2026, 4, 920000, 5000, 895000, '2026-04-01'),
    (3, 2026, 5, 0, 1020000, 1020000, '2026-04-01'),
    (3, 2026, 6, 615000, 0, 515000, '2026-04-01'),
    (3, 2026, 7, 50000, 0, 50000, '2026-04-01'),
    (3, 2026, 8, 0, 585000, 585000, '2026-04-01'),
    (3, 2026, 9, 420000, 0, 420000, '2026-04-01'),
    (3, 2026, 10, 120000, 0, 120000, '2026-04-01');
GO

-- ============================================
-- KIỂM TRA
-- ============================================
PRINT '';
PRINT '========================================';
PRINT '✅ DATABASE ĐÃ TẠO VÀ NHẬP DỮ LIỆU XONG!';
PRINT '========================================';
PRINT '';
SELECT 'TheLoai' AS Bang, COUNT(*) AS SoLuong FROM TheLoai
UNION ALL SELECT 'Sach', COUNT(*) FROM Sach
UNION ALL SELECT 'KhachHang', COUNT(*) FROM KhachHang
UNION ALL SELECT 'NguoiDung', COUNT(*) FROM NguoiDung
UNION ALL SELECT 'QuiDinh', COUNT(*) FROM QuiDinh
UNION ALL SELECT 'PhieuNhap', COUNT(*) FROM PhieuNhap
UNION ALL SELECT 'CT_PhieuNhap', COUNT(*) FROM CT_PhieuNhap
UNION ALL SELECT 'HoaDon', COUNT(*) FROM HoaDon
UNION ALL SELECT 'CT_HoaDon', COUNT(*) FROM CT_HoaDon
UNION ALL SELECT 'PhieuThu', COUNT(*) FROM PhieuThu
UNION ALL SELECT 'BaoCaoTon', COUNT(*) FROM BaoCaoTon
UNION ALL SELECT 'BaoCaoCongNo', COUNT(*) FROM BaoCaoCongNo;
GO

-- Thêm cột MaND vào bảng PhieuNhap
ALTER TABLE PhieuNhap 
ADD MaND INT NULL FOREIGN KEY REFERENCES NguoiDung(MaND);

-- Thêm cột MaND vào bảng PhieuThu
ALTER TABLE PhieuThu 
ADD MaND INT NULL FOREIGN KEY REFERENCES NguoiDung(MaND);

ALTER TABLE HoaDon 
ADD MaND INT NULL FOREIGN KEY REFERENCES NguoiDung(MaND);