using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;

namespace QuanLyNhaSach
{
    public partial class FormQuiDinh : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormQuiDinh()
        {
            InitializeComponent();
        }

        private void FormQuiDinh_Load(object sender, EventArgs e)
        {
            LoadQuiDinh();
        }

        private void LoadQuiDinh()
        {
            // SỬA: Thêm MoTa vào query để hiển thị đầy đủ
            DataTable dt = db.ExecuteQuery("SELECT MaQD, TenQD, GiaTri, GiaTriTien, ApDung, MoTa FROM QuiDinh");
            dgvQuiDinh.DataSource = dt;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvQuiDinh.Rows)
                {
                    if (row.Cells["MaQD"].Value != null)
                    {
                        int maQD = Convert.ToInt32(row.Cells["MaQD"].Value);
                        object giaTri = row.Cells["GiaTri"].Value;
                        object giaTriTien = row.Cells["GiaTriTien"].Value;
                        bool apDung = Convert.ToBoolean(row.Cells["ApDung"].Value);

                        // SỬA: Cập nhật đúng theo schema mới (có MoTa nhưng không cập nhật qua grid)
                        db.ExecuteNonQuery(
                            @"UPDATE QuiDinh SET 
                                GiaTri = @GiaTri, 
                                GiaTriTien = @GiaTriTien, 
                                ApDung = @ApDung 
                            WHERE MaQD = @MaQD",
                            new SqlParameter[] {
                                new SqlParameter("@MaQD", maQD),
                                new SqlParameter("@GiaTri", giaTri ?? (object)DBNull.Value),
                                new SqlParameter("@GiaTriTien", giaTriTien ?? (object)DBNull.Value),
                                new SqlParameter("@ApDung", apDung)
                            });
                    }
                }

                MessageBox.Show("Cập nhật qui định thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuiDinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}