using Microsoft.Data.SqlClient;
using QuanLyNhaSach.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class FormTraCuuSach : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public FormTraCuuSach()
        {
            InitializeComponent();
        }

        private void FormTraCuuSach_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadDanhSachSach();
            LoadTheLoai();
        }

        private void SetupDataGridView()
        {
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Columns.Clear();

            // Mã sách
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã Sách",
                Name = "colMaSach",
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Tên sách
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên Sách",
                Name = "colTenSach",
                Width = 280,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Thể loại
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenTheLoai",
                HeaderText = "Thể Loại",
                Name = "colTheLoai",
                Width = 150
            });

            // Tác giả
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TacGia",
                HeaderText = "Tác Giả",
                Name = "colTacGia",
                Width = 180
            });

            // Số lượng tồn
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Tồn Kho",
                Name = "colTon",
                Width = 90,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(52, 152, 219),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            });

            // Đơn giá
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn Giá",
                Name = "colGia",
                Width = 130,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(231, 76, 60),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            });

            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.RowHeadersVisible = false;
            dgvSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgvSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSach.GridColor = Color.FromArgb(224, 224, 224);
            dgvSach.ReadOnly = true;
        }

        private void LoadDanhSachSach()
        {
            string query = @"SELECT s.MaSach, s.TenSach, tl.TenTheLoai, s.TacGia, s.SoLuongTon, s.DonGia
                           FROM Sach s JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai";
            dgvSach.DataSource = db.ExecuteQuery(query);
            lblKetQua.Text = $"Tổng số: {dgvSach.Rows.Count} cuốn sách";
        }

        private void LoadTheLoai()
        {
            DataTable dt = db.ExecuteQuery("SELECT * FROM TheLoai");
            DataRow row = dt.NewRow();
            row["MaTheLoai"] = 0;
            row["TenTheLoai"] = "-- Tất cả thể loại --";
            dt.Rows.InsertAt(row, 0);

            cboTheLoai.DataSource = dt;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var parameters = new List<SqlParameter>();
            string query = @"SELECT s.MaSach, s.TenSach, tl.TenTheLoai, s.TacGia, s.SoLuongTon, s.DonGia
                     FROM Sach s JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                query += " AND s.TenSach LIKE @TenSach";
                parameters.Add(new SqlParameter("@TenSach", $"%{txtTenSach.Text}%"));
            }

            if (cboTheLoai.SelectedIndex > 0)
            {
                query += " AND s.MaTheLoai = @MaTheLoai";
                parameters.Add(new SqlParameter("@MaTheLoai", cboTheLoai.SelectedValue));
            }

            if (!string.IsNullOrWhiteSpace(txtTacGia.Text))
            {
                query += " AND s.TacGia LIKE @TacGia";
                parameters.Add(new SqlParameter("@TacGia", $"%{txtTacGia.Text}%"));
            }

            DataTable dt = db.ExecuteQuery(query, parameters.ToArray());
            dgvSach.DataSource = dt;
            lblKetQua.Text = $"Tìm thấy: {dgvSach.Rows.Count} cuốn sách";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            txtTacGia.Clear();
            cboTheLoai.SelectedIndex = 0;
            LoadDanhSachSach();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDanhSachSach();
        }
    }
}