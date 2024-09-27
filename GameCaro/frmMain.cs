using System;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnHaiNguoiChoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHaiNguoiChoi frm = new frmHaiNguoiChoi();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }

        private void btnChoiVoiMay_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChoiVoiMay frm = new frmChoiVoiMay();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }
        private void btnDanhOnline_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChoiOnline frm = new frmChoiOnline();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }
        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game caro 2 người chơi.\nĐi 5 quân cờ liên tục thì thắng. Nhưng nếu bị chặn 2 đầu thì không tính.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Close();
        }

     
        
    }
}
