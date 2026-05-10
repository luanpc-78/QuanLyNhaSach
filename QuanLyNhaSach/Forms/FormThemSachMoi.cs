using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;

namespace QuanLyNhaSach
{
    public partial class FormThemSachMoi : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        // Public properties de FormPhieuNhap lay du lieu
        public int NewBookId = -1;
        public string TenSach { get; private set; } = string.Empty;
        public string TacGia { get; private set; } = string.Empty;
        public decimal DonGia { get; private set; }
        public int SoLuong { get; private set; }
        public DateTime NgayNhap { get; private set; }

        // true = sach da co trong kho, false = sach moi
        private bool isExistingBook = false;
        private int existingMaSach = -1;

        public FormThemSachMoi()
        {
            InitializeComponent();
        }

        private void FormThemSachMoi_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Them Sach Vao Phieu Nhap";
            LoadTheLoai();
            LoadTacGiaHistory();
            SetNewBookMode();
            txtTenSach.Focus();
        }

        private void LoadTheLoai()
        {
            try
            {
                DataTable dt = db.ExecuteQuery("SELECT MaTheLoai, TenTheLoai FROM TheLoai ORDER BY TenTheLoai");
                cboTheLoai.DataSource = dt;
                cboTheLoai.DisplayMember = "TenTheLoai";
                cboTheLoai.ValueMember = "MaTheLoai";
                cboTheLoai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai the loai: " + ex.Message, "Loi");
            }
        }

        private void LoadTacGiaHistory()
        {
            try
            {
                cboTacGia.Items.Clear();
                DataTable dt = db.ExecuteQuery(
                    "SELECT DISTINCT TacGia FROM Sach WHERE TacGia IS NOT NULL AND TacGia <> '' ORDER BY TacGia");
                foreach (DataRow row in dt.Rows)
                {
                    var tacGia = row["TacGia"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(tacGia))
                        cboTacGia.Items.Add(tacGia);
                }
                cboTacGia.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch { }
        }

        private void SetNewBookMode()
        {
            isExistingBook = false;
            existingMaSach = -1;

            txtMaSach.Text = "(Tu dong tao)";
            txtMaSach.ReadOnly = true;
            txtMaSach.BackColor = Color.FromArgb(236, 240, 241);

            txtTenSach.ReadOnly = false;
            txtTenSach.BackColor = SystemColors.Window;
            txtTenSach.Text = "";

            cboTacGia.Enabled = true;
            cboTacGia.BackColor = SystemColors.Window;
            cboTacGia.Text = "";

            cboTheLoai.Enabled = true;
            cboTheLoai.BackColor = SystemColors.Window;
            cboTheLoai.SelectedIndex = -1;

            txtDonGia.ReadOnly = false;
            txtDonGia.BackColor = SystemColors.Window;
            txtDonGia.Text = "";

            txtSoLuong.Text = "";
            dtpNgayNhap.Value = DateTime.Now;

            lblStatus.Text = "Sach moi - Nhap thong tin";
            lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private void SetExistingBookMode(int maSach, string tenSach, string tacGia, decimal donGia, int maTheLoai)
        {
            isExistingBook = true;
            existingMaSach = maSach;

            txtMaSach.Text = maSach.ToString();
            txtMaSach.ReadOnly = true;
            txtMaSach.BackColor = Color.FromArgb(236, 240, 241);

            txtTenSach.Text = tenSach;
            txtTenSach.ReadOnly = true;
            txtTenSach.BackColor = Color.FromArgb(236, 240, 241);

            cboTacGia.Text = tacGia;
            cboTacGia.Enabled = false;
            cboTacGia.BackColor = Color.FromArgb(236, 240, 241);

            cboTheLoai.SelectedValue = maTheLoai;
            cboTheLoai.Enabled = false;
            cboTheLoai.BackColor = Color.FromArgb(236, 240, 241);

            txtDonGia.Text = donGia.ToString("N0");
            txtDonGia.ReadOnly = true;
            txtDonGia.BackColor = Color.FromArgb(236, 240, 241);

            txtSoLuong.Text = "";
            txtSoLuong.Focus();

            dtpNgayNhap.Value = DateTime.Now;

            lblStatus.Text = "Sach da co trong kho - Chi nhap so luong";
            lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (isExistingBook) return;

            string keyword = txtTenSach.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword) || keyword.Length < 2) return;

            var dt = db.ExecuteQuery(
                "SELECT TOP 5 MaSach, TenSach, TacGia, DonGia, MaTheLoai FROM Sach WHERE TenSach LIKE @Keyword",
                new SqlParameter[]
                {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                });

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];
                string tenSach = row["TenSach"]?.ToString() ?? "";
                string tacGia = row["TacGia"]?.ToString() ?? "";
                decimal donGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0;
                int maSach = Convert.ToInt32(row["MaSach"]);
                int maTheLoai = row["MaTheLoai"] != DBNull.Value ? Convert.ToInt32(row["MaTheLoai"]) : 0;

                txtTenSach.TextChanged -= txtTenSach_TextChanged;

                string message = "Tim thay sach da co trong kho:\n\n" +
                    "Ten: " + tenSach + "\n" +
                    "Tac gia: " + tacGia + "\n" +
                    "Don gia: " + donGia.ToString("N0") + " VND\n\n" +
                    "Day co phai sach ban muon nhap them khong?";

                DialogResult result = MessageBox.Show(
                    message,
                    "Sach da co trong kho",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetExistingBookMode(maSach, tenSach, tacGia, donGia, maTheLoai);
                }

                txtTenSach.TextChanged += txtTenSach_TextChanged;
            }
            else if (dt.Rows.Count > 1)
            {
                txtTenSach.TextChanged -= txtTenSach_TextChanged;
                using (FormChonSach frmChon = new FormChonSach(keyword))
                {
                    if (frmChon.ShowDialog(this) == DialogResult.OK && frmChon.SelectedMaSach > 0)
                    {
                        DataTable dtSach = db.ExecuteQuery(
                            "SELECT MaSach, TenSach, TacGia, DonGia, MaTheLoai FROM Sach WHERE MaSach = @MaSach",
                            new SqlParameter[] { new SqlParameter("@MaSach", frmChon.SelectedMaSach) });
                        if (dtSach.Rows.Count > 0)
                        {
                            var row = dtSach.Rows[0];
                            SetExistingBookMode(
                                Convert.ToInt32(row["MaSach"]),
                                row["TenSach"]?.ToString() ?? "",
                                row["TacGia"]?.ToString() ?? "",
                                row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0,
                                row["MaTheLoai"] != DBNull.Value ? Convert.ToInt32(row["MaTheLoai"]) : 0);
                        }
                    }
                }
                txtTenSach.TextChanged += txtTenSach_TextChanged;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Vui long nhap ten sach!", "Loi");
                txtTenSach.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("So luong phai la so nguyen duong!", "Loi");
                txtSoLuong.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                !decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Don gia phai la so duong!", "Loi");
                txtDonGia.Focus();
                return;
            }

            object qd1 = db.ExecuteScalar("SELECT GiaTri FROM QuiDinh WHERE MaQD = 1");
            int slToiThieu = qd1 != null ? Convert.ToInt32(qd1) : 150;
            if (soLuong < slToiThieu)
            {
                MessageBox.Show("So luong nhap toi thieu la " + slToiThieu + "!", "Loi qui dinh");
                txtSoLuong.Focus();
                return;
            }

            try
            {
                string tenSach = txtTenSach.Text.Trim();
                string tacGia = cboTacGia.Text.Trim();
                DateTime ngayNhap = dtpNgayNhap.Value;

                if (isExistingBook && existingMaSach > 0)
                {
                    object qd2 = db.ExecuteScalar("SELECT GiaTri FROM QuiDinh WHERE MaQD = 2");
                    int slTonToiThieu = qd2 != null ? Convert.ToInt32(qd2) : 300;

                    object slTonObj = db.ExecuteScalar(
                        "SELECT SoLuongTon FROM Sach WHERE MaSach = @MaSach",
                        new SqlParameter[] { new SqlParameter("@MaSach", existingMaSach) });
                    int slTon = slTonObj != null ? Convert.ToInt32(slTonObj) : 0;

                    if (slTon >= slTonToiThieu)
                    {
                        string msg = "Sach nay con " + slTon + " cuon (>= " + slTonToiThieu + ").\nKhong can nhap them theo qui dinh!";
                        MessageBox.Show(msg, "Loi qui dinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    NewBookId = existingMaSach;
                    TenSach = tenSach;
                    TacGia = tacGia;
                    DonGia = donGia;
                    SoLuong = soLuong;
                    NgayNhap = ngayNhap;
                }
                else
                {
                    if (cboTheLoai.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui long chon the loai!", "Loi");
                        cboTheLoai.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(tacGia))
                    {
                        MessageBox.Show("Vui long nhap ten tac gia!", "Loi");
                        cboTacGia.Focus();
                        return;
                    }

                    var dtCheck = db.ExecuteQuery(
                        "SELECT MaSach FROM Sach WHERE TenSach = @TenSach",
                        new SqlParameter[] { new SqlParameter("@TenSach", tenSach) });

                    if (dtCheck.Rows.Count > 0)
                    {
                        int maSachCu = Convert.ToInt32(dtCheck.Rows[0]["MaSach"]);
                        string msg = "Sach '" + tenSach + "' da co trong kho (Ma: " + maSachCu + ")!\n\nVui long nhap lai ten khac hoac chon sach da co.";
                        MessageBox.Show(msg, "Sach da ton tai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenSach.Focus();
                        return;
                    }

                    int maTheLoai = Convert.ToInt32(cboTheLoai.SelectedValue);

                    db.ExecuteNonQuery(
                        "INSERT INTO Sach (TenSach, MaTheLoai, TacGia, SoLuongTon, DonGia) VALUES (@TenSach, @MaTheLoai, @TacGia, 0, @DonGia)",
                        new SqlParameter[]
                        {
                            new SqlParameter("@TenSach", tenSach),
                            new SqlParameter("@MaTheLoai", maTheLoai),
                            new SqlParameter("@TacGia", tacGia),
                            new SqlParameter("@DonGia", donGia)
                        });

                    object result = db.ExecuteScalar("SELECT IDENT_CURRENT('Sach') AS MaSach");
                    NewBookId = result != null ? Convert.ToInt32(result) : -1;

                    TenSach = tenSach;
                    TacGia = tacGia;
                    DonGia = donGia;
                    SoLuong = soLuong;
                    NgayNhap = ngayNhap;
                }

                MessageBox.Show("Sach '" + TenSach + "' duoc them vao phieu thanh cong!", "Thanh cong",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi luu sach: " + ex.Message, "Loi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
        }
    }
}