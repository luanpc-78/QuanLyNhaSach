using System;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class FormNhapSoLuong : Form
    {
        public int SoLuong { get; private set; }
        private string _tenSach;

        public FormNhapSoLuong(string tenSach = "")
        {
            InitializeComponent();
            _tenSach = tenSach;
        }

        private void FormNhapSoLuong_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = $"Nhập số lượng sách: {_tenSach}";
            txtSoLuong.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là một số dương!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.SelectAll();
                txtSoLuong.Focus();
                return;
            }

            SoLuong = soLuong;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnOK.PerformClick();
                e.Handled = true;
            }
        }
    }
}
