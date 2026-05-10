using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;

namespace QuanLyNhaSach
{
    public partial class FormChonSach : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        public int SelectedMaSach { get; private set; } = -1;

        public FormChonSach(string keyword)
        {
            InitializeComponent();
            LoadSach(keyword);
        }

        private void LoadSach(string keyword)
        {
            try
            {
                DataTable dt = db.ExecuteQuery(
                    "SELECT MaSach, TenSach, TacGia, DonGia, SoLuongTon FROM Sach WHERE TenSach LIKE @Keyword",
                    new SqlParameter[] { new SqlParameter("@Keyword", "%" + keyword + "%") });

                dgvSach.DataSource = dt;
                if (dgvSach.Columns.Count > 0)
                {
                    dgvSach.Columns[0].HeaderText = "Mã Sách";
                    dgvSach.Columns[1].HeaderText = "Tên Sách";
                    dgvSach.Columns[2].HeaderText = "Tác Giả";
                    dgvSach.Columns[3].HeaderText = "Đơn Giá";
                    dgvSach.Columns[4].HeaderText = "Tồn Kho";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                SelectedMaSach = Convert.ToInt32(dgvSach.SelectedRows[0].Cells[0].Value);
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

        private void dgvSach_DoubleClick(object sender, EventArgs e)
        {
            btnChon.PerformClick();
        }
    }
}