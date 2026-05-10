using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.DAL
{
    public class DatabaseConnection
    {
        // Chuỗi kết nối cho LocalDB (của bạn)
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyNhaSach;Integrated Security=True;";

        // Hàm thực thi query và trả về DataTable
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi thực thi query: " + ex.Message);
            }
            return dt;
        }

        // Hàm thực thi query với tham số và trả về DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi query: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Hàm thực thi query và trả về giá trị vô hướng (scalar)
        public object ExecuteScalar(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi query: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Hàm thực thi query scalar với tham số
        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi query: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Hàm thực thi câu lệnh không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public void ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi thực thi câu lệnh: " + ex.Message);
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm thực thi câu lệnh không trả về dữ liệu với tham số
        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm kiểm tra kết nối
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Hàm khởi tạo database (tạo bảng NguoiDung nếu chưa tồn tại)
        public bool InitializeDatabase()
        {
            try
            {
                // Kiểm tra xem bảng NguoiDung đã tồn tại chưa
                string checkTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NguoiDung')
                    BEGIN
                        CREATE TABLE NguoiDung (
                            MaND INT IDENTITY(1,1) PRIMARY KEY,
                            TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
                            MatKhau VARCHAR(255) NOT NULL,
                            HoTen NVARCHAR(100),
                            Email VARCHAR(100),
                            VaiTro NVARCHAR(20) DEFAULT N'NhanVien',
                            TrangThai BIT DEFAULT 1,
                            NgayTao DATETIME DEFAULT GETDATE()
                        );

                        -- Thêm tài khoản demo
                        INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro, TrangThai) VALUES 
                            ('admin', '123456', N'Quản trị viên', 'admin@nhasach.com', N'Admin', 1),
                            ('nhanvien1', '123456', N'Nhân viên A', 'nv1@nhasach.com', N'NhanVien', 1),
                            ('nhanvien2', '123456', N'Nhân viên B', 'nv2@nhasach.com', N'NhanVien', 1);
                    END";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(checkTableQuery, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, log lại nhưng không làm gián đoạn ứng dụng
                System.Diagnostics.Debug.WriteLine("Lỗi khởi tạo database: " + ex.Message);
                return false;
            }
        }
    }
}