using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class frmHaiNguoiChoi : Form
    {
        public frmHaiNguoiChoi()
        {
            InitializeComponent();
        }
        static CaRo QuanLyGameCaRo = new CaRo();
        static Button[,] arrButton = null;
        private void lblLuotDi_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn quay lại màn hình chính?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                DialogResult = DialogResult.OK;
        }

        private void frmHaiNguoiChoi_Load(object sender, EventArgs e)
        {
            QuanLyGameCaRo.ResetGame();
            HienThiGameCaro();
        }
        private void HienThiGameCaro()
        {
            arrButton = new Button[30, 30];
            pnButton.Controls.Clear();
            for (int i = 0; i < arrButton.GetLength(0); i++)
            {
                for (int j = 0; j < arrButton.GetLength(1); j++)
                {
                    Button btn = new Button();
                    btn.Height = btn.Width = 25;
                    btn.Text = "";
                    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.Location = new Point(j * btn.Width, i * btn.Height);
                    pnButton.Controls.Add(btn);
                    arrButton[i, j] = btn;
                    btn.BackColor = Color.WhiteSmoke;
                    btn.Tag = i + ";" + j;
                    btn.Click += Btn_Click;
                }
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string s = btn.Tag.ToString();
            string[] arr = s.Split(';');
            int dong = int.Parse(arr[0]);
            int cot = int.Parse(arr[1]);
            if (btn.Text != "")
            {

            }
            else
            {
                if (QuanLyGameCaRo.LuotDiHienTai == false)
                {
                    QuanLyGameCaRo.ThemQuanX(dong, cot);
                    btn.ForeColor = Color.Red;
                    btn.Text = "X";
                    QuanLyGameCaRo.ThemQuanX(dong, cot);
                    if (QuanLyGameCaRo.KiemTraWin(dong, cot, 'X'))
                    {
                        MessageBox.Show("Player [X] chiến thắng!");
                    }
                    lblNguoiChoi.ForeColor = Color.Blue;
                    lblNguoiChoi.Text = "Player [O] đi...";
                    QuanLyGameCaRo.LuotDiHienTai = true;
                }
                else
                {
                    QuanLyGameCaRo.ThemQuanO(dong, cot);
                    btn.ForeColor = Color.Blue;
                    btn.Text = "O";
                    QuanLyGameCaRo.LuotDiHienTai = false;
                    QuanLyGameCaRo.ThemQuanO(dong, cot);
                    if (QuanLyGameCaRo.KiemTraWin(dong, cot, 'O'))
                    {
                        MessageBox.Show("Player [O] chiến thắng!", "Thông báo");
                    }
                    lblNguoiChoi.ForeColor = Color.Red;
                    lblNguoiChoi.Text = "Player [X] đi...";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            QuanLyGameCaRo.ResetGame();
            HienThiGameCaro();
        }
    }
}
