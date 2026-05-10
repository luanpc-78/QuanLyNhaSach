# 📚 Hệ Thống Quản Lý Nhà Sách

![License](https://img.shields.io/badge/License-Educational_Use_Only-red)
![.NET](https://img.shields.io/badge/.NET-10.0-blue)
![Language](https://img.shields.io/badge/Language-C%23-green)
![Database](https://img.shields.io/badge/Database-SQL_Server-orange)

## 🎓 Thông Tin Dự Án

**Tên Dự Án:** Hệ Thống Quản Lý Nhà Sách  
**Loại:** Dự Án Học Tập / Khóa Luận Tốt Nghiệp  
**Trường:** NTTU (Trường Đại Học Nguyễn Tất Thành) & NIIE  
**Ngôn Ngữ:** C#  
**Framework:** .NET 10 (Windows Forms)  
**Cơ Sở Dữ Liệu:** Microsoft SQL Server  
**Năm:** 2025-2026

---

## 👥 Thành Viên Nhóm

| STT | Họ Tên | MSSV | Email |
|:---:|:---|:---|:---|
| 1 | Phan Công Luận | 2311559057 | 2311559057@nttu.edu.vn
| 2 | Hồ Lâm Minh Thái | 2311558432 | 2311558432@nttu.edu.vn
| 3 | Nguyễn Quang Hưng | 2311560344 | 2311560344@nttu.edu.vn
| 4 | Nguyễn Ân Phát | 2311558386 | 2311558386@nttu.edu.vn
| 5 | Nguyễn Duy Khiêm | 2311560212 | 2311560212@nttu.edu.vn

---

## 📋 Mô Tả Dự Án

Hệ thống Quản Lý Nhà Sách là một ứng dụng Desktop được phát triển dành cho các cửa hàng nhà sách quy mô nhỏ và vừa để:

✅ **Quản lý kho sách** - Lập phiếu nhập, kiểm kê tồn kho  
✅ **Bán hàng** - Lập hóa đơn bán sách, quản lý khách hàng  
✅ **Thu nợ** - Lập phiếu thu tiền, theo dõi công nợ khách hàng  
✅ **Thống kê báo cáo** - Báo cáo tồn kho, báo cáo công nợ theo tháng  
✅ **Quản lý cấu hình** - Thay đổi quy định, quản lý người dùng

### Quy Định Hệ Thống

- **QĐ1:** Số lượng nhập ≥ 150 cuốn, chỉ nhập sách có tồn < 300 cuốn
- **QĐ2:** Bán cho khách nợ ≤ 20,000 VNĐ, tồn kho sau bán ≥ 20 cuốn
- **QĐ4:** Tiền thu ≤ Tiền nợ hiện tại của khách hàng
- **QĐ6:** Admin có thể thay đổi các quy định trên

---

## 🛠️ Công Nghệ Sử Dụng

```
┌─────────────────────────────────────────┐
│         CÔNG NGHỆ CHÍNH                 │
├─────────────────────────────────────────┤
│ ✓ .NET 10.0 (C# 13)                     │
│ ✓ Windows Forms (WinForms)              │
│ ✓ Microsoft SQL Server 2019+            │
│ ✓ ADO.NET (Microsoft.Data.SqlClient)    │
│ ✓ Visual Studio Community 2026          │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│      KIẾN TRÚC & MỨC ĐÍCH              │
├─────────────────────────────────────────┤
│ ✓ Mô hình 3-Layer Architecture          │
│   - GUI (Presentation Layer)            │
│   - BUS (Business Logic Layer)          │
│   - DAL (Data Access Layer)             │
│ ✓ DTO (Data Transfer Object)            │
│ ✓ Mô hình khóa chính / khóa ngoại       │
│ ✓ Transaction (Giao dịch CSDL)          │
└─────────────────────────────────────────┘
```

---

## 📁 Cấu Trúc Dự Án

```
QuanLyNhaSach/
├── 📂 Forms/                    # Giao diện người dùng (GUI)
│   ├── FormLogin.cs            # Màn hình đăng nhập
│   ├── Form1.cs                # Màn hình chính
│   ├── FormPhieuNhap.cs        # Lập phiếu nhập sách
│   ├── FormHoaDon.cs           # Lập hóa đơn bán
│   ├── FormPhieuThu.cs         # Lập phiếu thu tiền
│   ├── FormTraCuuSach.cs       # Tra cứu thông tin sách
│   ├── FormBaoCaoTon.cs        # Báo cáo tồn kho
│   ├── FormBaoCaoCongNo.cs     # Báo cáo công nợ
│   ├── FormQuiDinh.cs          # Quản lý quy định
│   └── FormQuanLyNguoiDung.cs  # Quản lý người dùng
│
├── 📂 DAL/                     # Tầng truy xuất dữ liệu (Data Access Layer)
│   └── DatabaseConnection.cs   # Kết nối, truy vấn SQL
│
├── 📂 Models/                  # Các lớp dữ liệu (DTO)
│   ├── NguoiDung.cs           # Model Người dùng
│   ├── Sach.cs                # Model Sách
│   ├── KhachHang.cs           # Model Khách hàng
│   ├── QuiDinh.cs             # Model Quy định
│   └── ...
│
├── 📂 Properties/             # Cấu hình ứng dụng
│   ├── Settings.Designer.cs
│   └── Resources.Designer.cs
│
├── UserSession.cs             # Quản lý phiên làm việc người dùng
├── Program.cs                 # Entry point ứng dụng
├── README.md                  # File hướng dẫn này
└── QuanLyNhaSach.csproj      # File cấu hình dự án
```

---

## 🚀 Hướng Dẫn Cài Đặt

### Yêu Cầu Hệ Thống

- **OS:** Windows 10 / Windows 11
- **.NET Runtime:** .NET 10.0 trở lên
- **Database:** Microsoft SQL Server 2019 hoặc mới hơn
- **RAM:** Tối thiểu 4GB
- **Ổ đĩa:** 500MB trống

### Bước 1: Clone / Tải Dự Án

```bash
# Clone từ GitHub (nếu có)
git clone https://github.com/yourusername/QuanLyNhaSach.git
cd QuanLyNhaSach

# Hoặc tải file ZIP và giải nén
```

### Bước 2: Cài Đặt SQL Server Database

1. Mở **SQL Server Management Studio (SSMS)**
2. Chạy file script SQL:
   ```bash
   # File: Database/QuanLyNhaSach_Script.sql
   ```
3. Script sẽ tự động:
   - Tạo Database `QuanLyNhaSach`
   - Tạo 12 bảng dữ liệu
   - Insert dữ liệu mẫu

### Bước 3: Cấu Hình Kết Nối Database

Mở file `QuanLyNhaSach/DAL/DatabaseConnection.cs` và cập nhật connection string:

```csharp
private string connectionString = 
    "Server=YOUR_SERVER_NAME;Database=QuanLyNhaSach;Integrated Security=true;";
```

**Ví dụ:**
```csharp
// Nếu dùng SQL Server local
private string connectionString = 
    "Server=(local);Database=QuanLyNhaSach;Integrated Security=true;";

// Nếu dùng SQL Server với mật khẩu
private string connectionString = 
    "Server=DESKTOP-ABC123;Database=QuanLyNhaSach;User Id=sa;Password=YourPassword;";
```

### Bước 4: Mở & Build Dự Án

```bash
# Mở Visual Studio
# File → Open → QuanLyNhaSach.sln

# Build dự án
Build → Build Solution (Ctrl + Shift + B)

# Chạy chương trình
Debug → Start Debugging (F5)
```

---

## 📖 Hướng Dẫn Sử Dụng

### Đăng Nhập

**Tài khoản mặc định:**

| Tài Khoản | Mật Khẩu | Vai Trò | Ghi Chú |
|:---|:---|:---|:---|
| `admin` | `12` | Admin | Toàn quyền hệ thống |
| `nhanvien1` | `12` | Nhân viên | Quyền bán hàng, lập phiếu |
| `nhanvien2` | `12` | Nhân viên | Quyền bán hàng, lập phiếu |

### Chức Năng Chính

#### 1️⃣ Lập Phiếu Nhập (FormPhieuNhap)
- Chọn sách từ danh sách
- Nhập số lượng & đơn giá nhập
- Hệ thống tự động kiểm tra Quy Định 1 & 2
- Click "Lưu Phiếu Nhập"

#### 2️⃣ Lập Hóa Đơn Bán (FormHoaDon)
- Chọn khách hàng (hoặc thêm mới)
- Thêm sách vào giỏ hàng
- Hệ thống kiểm tra Quy Định 2 (Nợ tối đa, Tồn tối thiểu)
- Click "Lưu Hóa Đơn"

#### 3️⃣ Lập Phiếu Thu Tiền (FormPhieuThu)
- Chọn khách hàng
- Nhập số tiền thu
- Hệ thống kiểm tra Quy Định 4 (Thu ≤ Nợ)
- Click "Lưu Phiếu Thu"

#### 4️⃣ Xem Báo Cáo (FormBaoCaoTon, FormBaoCaoCongNo)
- Chọn tháng & năm
- Xem biểu đồ thống kê
- Xuất file Excel

#### 5️⃣ Quản Lý Quy Định (FormQuiDinh) - **Chỉ Admin**
- Thay đổi QĐ1, QĐ2, QĐ4
- Bật/Tắt áp dụng quy định

---

## 🔐 Bảo Mật & Phân Quyền

### Xác Thực

✅ Sử dụng **SHA256 Hashing** để mã hóa mật khẩu  
✅ Session lưu thông tin người dùng hiện tại  
✅ Tự động đăng xuất khi đóng ứng dụng

### Phân Quyền

- **Admin:** Toàn quyền (Quản lý người dùng, Quy định, Báo cáo)
- **Nhân Viên:** Chỉ được lập phiếu, bán hàng, lập báo cáo xem

### Chống SQL Injection

✅ Sử dụng **SqlParameter** thay vì String Concatenation  
✅ Validate dữ liệu đầu vào trên form  
✅ Transaction & Rollback để đảm bảo toàn vẹn dữ liệu

---

## 📊 Cấu Trúc Cơ Sở Dữ Liệu

### 12 Bảng Chính

```
TheLoai ─────────┐
                 ├─→ Sach
                 │    ├─→ CT_PhieuNhap
                 │    └─→ CT_HoaDon
                 │
NguoiDung ──────┬┴─→ PhieuNhap
                ├──→ HoaDon
                └──→ PhieuThu

KhachHang ──────┬──→ HoaDon
                ├──→ PhieuThu
                └──→ BaoCaoCongNo

QuiDinh ─────── (Lưu các tham số quy định)
BaoCaoTon ────── (Báo cáo tồn kho tháng)
BaoCaoCongNo ─── (Báo cáo công nợ tháng)
```

---

## 🎯 Tính Năng Chính

| Tính Năng | Mô Tả | Quy Định |
|:---|:---|:---|
| **Quản Lý Kho** | Nhập sách, kiểm kê tồn | QĐ1 |
| **Bán Hàng** | Lập hóa đơn, quản lý khách hàng | QĐ2 |
| **Thu Tiền** | Lập phiếu thu nợ | QĐ4 |
| **Thống Kê** | Báo cáo tồn & nợ + Chart | - |
| **Quản Trị** | Quản lý người dùng, quy định | QĐ6 |

---

## ⚠️ THÔNG BÁO QUAN TRỌNG - LƯU Ý BẢN QUYỀN

### 🚫 KHÔNG ĐƯỢC REUPLOAD

```
⛔ KHÔNG ĐƯỢC:
   ├─ Reupload toàn bộ hoặc một phần code lên GitHub công khai
   ├─ Chia sẻ file cho sinh viên khác
   ├─ Sử dụng trong dự án cá nhân khác
   └─ Chỉnh sửa rồi nộp cho trường khác

⚠️  NẾU VI PHẠM:
   ├─ Sẽ bị trừ điểm / 0 điểm
   ├─ Có thể bị kỷ luật từ nhà trường
   ├─ Tư pháp có thể can thiệp về vi phạm bản quyền
   └─ Ảnh hưởng đến kết quả học tập
```

### ✅ ĐƯỢC PHÉP:
- ✓ Sử dụng code trong dự án cá nhân của mình
- ✓ Fork riêng tư (Private Repository) trên GitHub
- ✓ Nộp cho giáo viên theo quy định của nhà trường
- ✓ Tham khảo code để học tập cá nhân

---

## 📞 Liên Hệ & Hỗ Trợ

### Giáo Viên Hướng Dẫn
- **Họ Tên:** [Tên Giáo Viên]
- **Email:** [Email Giáo Viên]
- **Phòng:** [Phòng Văn Phòng]

### Liên Hệ Nhóm
Nếu có vấn đề hoặc muốn trao đổi:
- 📧 Email: phancongluan@student.nttu.edu.vn
- 💬 Zalo: [Số Zalo Nhóm]
- 📱 Điện Thoại: [Số Điện Thoại]

---

## 📝 Các File Tài Liệu

```
📦 QuanLyNhaSach/
├── 📄 README.md                           (File này)
├── 📄 BAOCAO_QuanLyNhaSach.docx          (Báo cáo học thuật)
├── 📄 THUYETRINH_QuanLyNhaSach.pptx      (Slide thuyết trình)
├── 📄 DATABASE_Script.sql                 (Script tạo CSDL)
├── 📄 HUONG_DAN_SU_DUNG.md               (Hướng dẫn chi tiết)
└── 📹 Demo_Video.mp4                     (Video demo 10-15 phút)
```

---

## 🏆 Thông Tin Đồ Án

**Mục Đích:** Khóa Luận Tốt Nghiệp / Dự Án Học Tập  
**Thời Gian:** 2025-2026  
**Trạng Thái:** ✅ Hoàn Thành & Đã Nộp  
**Điểm Dự Kiến:** 8.5 - 9.0 / 10

---

## 📜 License

```
⚖️ EDUCATIONAL LICENSE - HỌC TẬP VÀ GIÁO DỤC

Dự án này được phát triển cho mục đích học tập tại:
- Trường Đại Học Nông Lâm TP.HCM (NTTU)
- Viện Công Nghệ Thông Tin (NIIE)

✅ ĐƯỢC PHÉP:
   - Sử dụng code để học tập cá nhân
   - Nộp cho nhà trường theo quy định
   - Fork/Clone riêng tư (Private)

❌ KHÔNG ĐƯỢC PHÉP:
   - Reupload công khai (Public)
   - Sử dụng thương mại
   - Chia sẻ không xin phép

© 2025 Nhóm Phát Triển | Bảo Lưu Mọi Quyền
```

---

## 🎓 Người Viết Tài Liệu

**File README.md:**  
Được viết bởi nhóm phát triển dự án vào tháng 1 năm 2025

**Cập Nhật Lần Cuối:** 2025-01-15  
**Phiên Bản:** 1.0

---

> 💡 **Mẹo:** Nếu gặp lỗi, hãy kiểm tra:
> 1. Connection String đúng chưa?
> 2. Database đã được tạo chưa?
> 3. SQL Server đang chạy chưa?
> 4. .NET 10 đã cài chưa?

---

**Cảm ơn đã sử dụng Hệ Thống Quản Lý Nhà Sách! 📚**
