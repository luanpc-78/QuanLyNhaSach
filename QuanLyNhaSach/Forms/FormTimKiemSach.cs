using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;

namespace QuanLyNhaSach
{
    public partial class FormTimKiemSach : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        public int SelectedBookId { get; private set; }

        public FormTimKiemSach()
        {
            InitializeComponent();
        }

        private void FormTimKiemSach_Load(object? sender, EventArgs e)
        {
            LoadAllBooks();
            txtTimKiem.Focus();
        }

        private void LoadAllBooks()
        {
            string query = @"SELECT s.MaSach, s.TenSach, s.TacGia, tl.TenTheLoai, s.SoLuongTon 
                           FROM Sach s 
                           JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai 
                           ORDER BY s.TenSach";
            try
            {
                DataTable dt = db.ExecuteQuery(query);
                dgvKetQua.DataSource = dt;
                dgvKetQua.Columns[0].HeaderText = "Mã Sách";
                dgvKetQua.Columns[1].HeaderText = "Tên Sách";
                dgvKetQua.Columns[2].HeaderText = "Tác Giả";
                dgvKetQua.Columns[3].HeaderText = "Thể Loại";
                dgvKetQua.Columns[4].HeaderText = "Tồn Kho";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadAllBooks();
                return;
            }

            string query = @"SELECT s.MaSach, s.TenSach, s.TacGia, tl.TenTheLoai, s.SoLuongTon 
                           FROM Sach s 
                           JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai 
                           WHERE s.TenSach LIKE @Keyword 
                              OR s.TacGia LIKE @Keyword 
                              OR tl.TenTheLoai LIKE @Keyword
                           ORDER BY s.TenSach";
            try
            {
                Microsoft.Data.SqlClient.SqlParameter[] parameters = new Microsoft.Data.SqlClient.SqlParameter[]
                {
                    new Microsoft.Data.SqlClient.SqlParameter("@Keyword", "%" + keyword + "%")
                };
                DataTable dt = db.ExecuteQuery(query, parameters);
                dgvKetQua.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKetQua_DoubleClick(object? sender, EventArgs e)
        {
            if (dgvKetQua.SelectedRows.Count > 0)
            {
                SelectedBookId = Convert.ToInt32(dgvKetQua.SelectedRows[0].Cells[0].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnChon_Click(object? sender, EventArgs e)
        {
            if (dgvKetQua.SelectedRows.Count > 0)
            {
                SelectedBookId = Convert.ToInt32(dgvKetQua.SelectedRows[0].Cells[0].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách!", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
