using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.DAL;
using QuanLyNhaSach.Models;

namespace QuanLyNhaSach
{
    public partial class FormPhieuNhap : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        private DataTable dtSachNhap = new DataTable();
        private DataTable dtLichSuNhap = new DataTable();

        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            dtpNgayNhap.Value = DateTime.Now;
            dtSachNhap.Columns.Add("MaPhieuNhap", typeof(int));
            dtSachNhap.Columns.Add("NgayNhap", typeof(DateTime));
            dtSachNhap.Columns.Add("MaSach", typeof(int));
            dtSachNhap.Columns.Add("TenSach", typeof(string));
            dtSachNhap.Columns.Add("TacGia", typeof(string));
            dtSachNhap.Columns.Add("TenTheLoai", typeof(string));
            dtSachNhap.Columns.Add("SoLuong", typeof(int));
            dtSachNhap.Columns.Add("DonGia", typeof(decimal));
            dtSachNhap.Columns.Add("ThanhTien", typeof(decimal));
            dtSachNhap.Columns.Add("IsNew", typeof(bool));
            LoadLichSuNhapKho();
        }

        private void LoadLichSuNhapKho()
        {
            try
            {
                string query = @"
                    SELECT 
                        pn.MaPhieuNhap,
                        pn.NgayNhap,
                        s.MaSach,
                        s.TenSach,
                        s.TacGia,
                        tl.TenTheLoai,
                        ct.SoLuong,
                        ct.DonGia,
                        (ct.SoLuong * ct.DonGia) as ThanhTien,
                        CAST(0 AS BIT) as IsNew
                    FROM PhieuNhap pn
                    JOIN CT_PhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    ORDER BY pn.NgayNhap DESC, pn.MaPhieuNhap DESC";

                dtLichSuNhap = db.ExecuteQuery(query);
                RefreshDataGridView();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử nhập kho: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            DataTable dtDisplay = dtLichSuNhap.Clone();
            foreach (DataRow row in dtLichSuNhap.Rows)
                dtDisplay.ImportRow(row);

            foreach (DataRow row in dtSachNhap.Rows)
            {
                DataRow newRow = dtDisplay.NewRow();
                newRow["MaPhieuNhap"] = row["MaPhieuNhap"];
                newRow["NgayNhap"] = row["NgayNhap"];
                newRow["MaSach"] = row["MaSach"];
                newRow["TenSach"] = row["TenSach"];
                newRow["TacGia"] = row["TacGia"];
                newRow["TenTheLoai"] = row["TenTheLoai"];
                newRow["SoLuong"] = row["SoLuong"];
                newRow["DonGia"] = row["DonGia"];
                newRow["ThanhTien"] = row["ThanhTien"];
                newRow["IsNew"] = true;
                dtDisplay.Rows.Add(newRow);
            }

            dgvSachNhap.DataSource = dtDisplay;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvSachNhap.Columns.Count == 0) return;
            if (dgvSachNhap.Columns["IsNew"] != null)
                dgvSachNhap.Columns["IsNew"].Visible = false;

            dgvSachNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu";
            dgvSachNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvSachNhap.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvSachNhap.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvSachNhap.Columns["TacGia"].HeaderText = "Tác Giả";
            dgvSachNhap.Columns["TenTheLoai"].HeaderText = "Thể Loại";
            dgvSachNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvSachNhap.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvSachNhap.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            dgvSachNhap.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvSachNhap.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvSachNhap.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
            dgvSachNhap.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSachNhap.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSachNhap.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSachNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvSachNhap.Columns["MaPhieuNhap"].Width = 80;
            dgvSachNhap.Columns["NgayNhap"].Width = 100;
            dgvSachNhap.Columns["MaSach"].Width = 80;
            dgvSachNhap.Columns["TenSach"].Width = 250;
            dgvSachNhap.Columns["TacGia"].Width = 150;
            dgvSachNhap.Columns["TenTheLoai"].Width = 120;
            dgvSachNhap.Columns["SoLuong"].Width = 90;
            dgvSachNhap.Columns["DonGia"].Width = 100;
            dgvSachNhap.Columns["ThanhTien"].Width = 120;

            dgvSachNhap.RowPrePaint += DgvSachNhap_RowPrePaint;
        }

        private void DgvSachNhap_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSachNhap.Rows[e.RowIndex];
            if (row.DataBoundItem is DataRowView drv)
            {
                bool isNew = drv["IsNew"] != DBNull.Value && Convert.ToBoolean(drv["IsNew"]);
                if (isNew)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                }
            }
        }

        private void UpdateSummary()
        {
            int tongPhieu = dtLichSuNhap.Rows.Count;
            int tongSachMoi = dtSachNhap.Rows.Count;
            decimal tongTienMoi = 0;
            foreach (DataRow row in dtSachNhap.Rows)
                tongTienMoi += Convert.ToDecimal(row["ThanhTien"]);

            lblTongPhieu.Text = $"📦 Tổng phiếu đã nhập: {tongPhieu}";
            lblSachMoi.Text = $"➕ Sách trong phiếu hiện tại: {tongSachMoi}";
            lblTongTien.Text = $"💰 Tổng tiền phiếu hiện tại: {tongTienMoi:N0} VNĐ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormThemSachMoi frmThemSach = new FormThemSachMoi())
                {
                    if (frmThemSach.ShowDialog(this) == DialogResult.OK)
                    {
                        DataRow row = dtSachNhap.NewRow();
                        row["MaPhieuNhap"] = 0;
                        row["NgayNhap"] = dtpNgayNhap.Value;
                        row["MaSach"] = frmThemSach.NewBookId;
                        row["TenSach"] = frmThemSach.TenSach;
                        row["TacGia"] = frmThemSach.TacGia;

                        string tenTheLoai = "";
                        try
                        {
                            var dtTL = db.ExecuteQuery("SELECT TenTheLoai FROM TheLoai WHERE MaTheLoai = (SELECT MaTheLoai FROM Sach WHERE MaSach = @MaSach)",
                                new SqlParameter[] { new SqlParameter("@MaSach", frmThemSach.NewBookId) });
                            if (dtTL.Rows.Count > 0) tenTheLoai = dtTL.Rows[0]["TenTheLoai"].ToString();
                        }
                        catch { }

                        row["TenTheLoai"] = tenTheLoai;
                        row["SoLuong"] = frmThemSach.SoLuong;
                        row["DonGia"] = frmThemSach.DonGia;
                        row["ThanhTien"] = frmThemSach.SoLuong * frmThemSach.DonGia;
                        row["IsNew"] = true;
                        dtSachNhap.Rows.Add(row);

                        RefreshDataGridView();
                        UpdateSummary();

                        if (dgvSachNhap.Rows.Count > 0)
                        {
                            dgvSachNhap.FirstDisplayedScrollingRowIndex = dgvSachNhap.Rows.Count - 1;
                            dgvSachNhap.Rows[dgvSachNhap.Rows.Count - 1].Selected = true;
                        }

                        MessageBox.Show($"✅ Đã thêm '{frmThemSach.TenSach}' vào phiếu!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtSachNhap.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào để nhập!", "Thông báo");
                return;
            }

            try
            {
                object qd1Obj = db.ExecuteScalar("SELECT GiaTri FROM QuiDinh WHERE MaQD = 1");
                object qd2Obj = db.ExecuteScalar("SELECT GiaTri FROM QuiDinh WHERE MaQD = 2");
                int slNhapToiThieu = (qd1Obj != null && qd1Obj != DBNull.Value) ? Convert.ToInt32(qd1Obj) : 150;
                int slTonToiThieu = (qd2Obj != null && qd2Obj != DBNull.Value) ? Convert.ToInt32(qd2Obj) : 300;

                int tongSoLuongNhap = 0;
                foreach (DataRow row in dtSachNhap.Rows)
                    tongSoLuongNhap += Convert.ToInt32(row["SoLuong"]);

                if (tongSoLuongNhap < slNhapToiThieu)
                {
                    MessageBox.Show(
                        $"Số lượng nhập phải ≥ {slNhapToiThieu} cuốn (hiện tại: {tongSoLuongNhap} cuốn)!\n\n(Qui Định 1)",
                        "Lỗi qui định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataRow row in dtSachNhap.Rows)
                {
                    int maSach = Convert.ToInt32(row["MaSach"]);
                    object slTonObj = db.ExecuteScalar(
                        "SELECT SoLuongTon FROM Sach WHERE MaSach = @MaSach",
                        new SqlParameter[] { new SqlParameter("@MaSach", maSach) });
                    int slTon = slTonObj != null ? Convert.ToInt32(slTonObj) : 0;

                    if (slTon >= slTonToiThieu)
                    {
                        string tenSach = row["TenSach"].ToString();
                        MessageBox.Show(
                            $"Sách '{tenSach}' có tồn kho {slTon} ≥ {slTonToiThieu}, không được nhập!\n\n(Qui Định 1)",
                            "Lỗi qui định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // === SỬA: Thêm MaND để biết ai lập phiếu ===
                int maPhieuNhap = Convert.ToInt32(db.ExecuteScalar(
                    "INSERT INTO PhieuNhap (NgayNhap, MaND) OUTPUT INSERTED.MaPhieuNhap VALUES (@NgayNhap, @MaND)",
                    new SqlParameter[] {
                        new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                        new SqlParameter("@MaND", UserSession.CurrentUser != null ? UserSession.CurrentUser.MaND : 0)
                    }));

                foreach (DataRow row in dtSachNhap.Rows)
                {
                    int maSach = Convert.ToInt32(row["MaSach"]);
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    decimal donGia = Convert.ToDecimal(row["DonGia"]);

                    db.ExecuteNonQuery(
                        @"INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaSach, SoLuong, DonGia) 
                          VALUES (@MaPN, @MaSach, @SL, @DonGia)",
                        new SqlParameter[] {
                            new SqlParameter("@MaPN", maPhieuNhap),
                            new SqlParameter("@MaSach", maSach),
                            new SqlParameter("@SL", soLuong),
                            new SqlParameter("@DonGia", donGia)
                        });

                    db.ExecuteNonQuery(
                        "UPDATE Sach SET SoLuongTon = SoLuongTon + @SL WHERE MaSach = @MaSach",
                        new SqlParameter[] {
                            new SqlParameter("@SL", soLuong),
                            new SqlParameter("@MaSach", maSach)
                        });
                }

                MessageBox.Show($"🎉 Lập phiếu nhập #{maPhieuNhap} thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtSachNhap.Clear();
                LoadLichSuNhapKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    RefreshDataGridView();
                    return;
                }

                DataTable dtDisplay = ((DataTable)dgvSachNhap.DataSource).Clone();
                foreach (DataRow row in dtLichSuNhap.Rows)
                {
                    if (row["TenSach"].ToString().ToLower().Contains(keyword) ||
                        row["TacGia"].ToString().ToLower().Contains(keyword) ||
                        row["MaPhieuNhap"].ToString().Contains(keyword))
                    {
                        dtDisplay.ImportRow(row);
                    }
                }

                foreach (DataRow row in dtSachNhap.Rows)
                {
                    if (row["TenSach"].ToString().ToLower().Contains(keyword) ||
                        row["TacGia"].ToString().ToLower().Contains(keyword))
                    {
                        DataRow newRow = dtDisplay.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        dtDisplay.Rows.Add(newRow);
                    }
                }

                dgvSachNhap.DataSource = dtDisplay;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtSachNhap.Clear();
            txtTimKiem.Clear();
            LoadLichSuNhapKho();
            dtpNgayNhap.Value = DateTime.Now;
            MessageBox.Show("Đã làm mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void cboSach_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}