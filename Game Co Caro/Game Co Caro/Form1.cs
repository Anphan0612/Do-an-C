using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Co_Caro
{
    public partial class Form1 : Form
    {
        private Label[,] BanDo; 
        private static int soCot, soHang;  

        private int nguoiChoi; 
        private bool ketThucTroChoi;  
        private bool choiVoiMay;  
        private int[,] vtBanDo;  
        private Stack<QuanCo> cacQuanCo;  
        private QuanCo quanCo; 

        public Form1()
        {
            soCot = 20;
            soHang = 17;

            choiVoiMay = false;
            ketThucTroChoi = false;
            nguoiChoi = 1;
            BanDo = new Label[soHang + 2, soCot + 2];
            vtBanDo = new int[soHang + 2, soCot + 2];
            cacQuanCo = new Stack<QuanCo>();
            InitializeComponent();
           
            XayDungBanCo();  
        }

        private void XayDungBanCo()  
        {
            for (int i = 2; i <= soHang; i++)
                for (int j = 1; j <= soCot; j++)
                {
                    BanDo[i, j] = new Label();
                    BanDo[i, j].Parent = pnTableChess;
                    BanDo[i, j].Top = i * Contain.edgeChess;
                    BanDo[i, j].Left = j * Contain.edgeChess;
                    BanDo[i, j].Size = new Size(Contain.edgeChess - 1, Contain.edgeChess - 1);
                    BanDo[i, j].BackColor = Color.Snow;

                    BanDo[i, j].MouseLeave += Form1_MouseLeave;
                    BanDo[i, j].MouseEnter += Form1_MouseEnter;
                    BanDo[i, j].Click += Form1_Click;
                }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (ketThucTroChoi)
                return;
            Label lb = (Label)sender;
            int x = lb.Top / Contain.edgeChess - 1, y = lb.Left / Contain.edgeChess;
            if (vtBanDo[x, y] != 0)
                return;
            if (choiVoiMay)
            {
                nguoiChoi = 1;
                psbCooldownTime.Value = 0;
                tmCooldown.Start();
                lb.Image = Properties.Resources.o;
                vtBanDo[x, y] = 1;
                KiemTra(x, y);
                MayTimQuanCo();
            }
            else
            {
                if (nguoiChoi == 1)
                {
                    psbCooldownTime.Value = 0;
                    tmCooldown.Start();
                    lb.Image = Properties.Resources.o;
                    vtBanDo[x, y] = 1;
                    KiemTra(x, y);

                    nguoiChoi = 2;
                    ptbPayer.Image = Properties.Resources.x_copy;
                    txtNamePlayer.Text = "Người Chơi 2";
                }
                else
                {
                    psbCooldownTime.Value = 0;
                    lb.Image = Properties.Resources.x;
                    vtBanDo[x, y] = 2;
                    KiemTra(x, y);

                    nguoiChoi = 1;
                    ptbPayer.Image = Properties.Resources.onnnn;
                    txtNamePlayer.Text = "Người Chơi 1";
                }
            }
            quanCo = new QuanCo(lb, x, y);
            cacQuanCo.Push(quanCo);
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (ketThucTroChoi)
                return;
            Label lb = (Label)sender;
            lb.BackColor = Color.AliceBlue;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (ketThucTroChoi)
                return;
            Label lb = (Label)sender;
            lb.BackColor = Color.Snow;
        }

        private void tmCooldown_Tick(object sender, EventArgs e)
        {
            psbCooldownTime.PerformStep();
            if (psbCooldownTime.Value >= psbCooldownTime.Maximum)
            {
                KetThucTroChoi();
            }
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            if (!choiVoiMay)
            {
                QuanCo temp = new QuanCo();
                temp = cacQuanCo.Pop();
                temp.lb.Image = null;
                vtBanDo[temp.X, temp.Y] = 0;
                psbCooldownTime.Value = 0;
                DoiNguoiChoi();
            }
            else
            {
                QuanCo temp = new QuanCo();
                temp = cacQuanCo.Pop();
                temp.lb.Image = null;
                vtBanDo[temp.X, temp.Y] = 0;

                temp = cacQuanCo.Pop();
                temp.lb.Image = null;
                vtBanDo[temp.X, temp.Y] = 0;

                psbCooldownTime.Value = 0;
                nguoiChoi = 1;
            }
        }

        private void menuThoat_Click_1(object sender, EventArgs e)  
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void NguoiChoiVsNguoiChoi(object sender, EventArgs e)  
        {
            choiVoiMay = false;
            ketThucTroChoi = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            txtNamePlayer.Text = "";
            ptbPayer.Image = null;
            menuStrip1.Parent = pnTableChess;
            nguoiChoi = 1;
            BanDo = new Label[soHang + 2, soCot + 2];
            vtBanDo = new int[soHang + 2, soCot + 2];
            cacQuanCo = new Stack<QuanCo>();

            XayDungBanCo();
        }

        private void ChoiVoiMay(object sender, EventArgs e)  
        {
            choiVoiMay = true;
            ketThucTroChoi = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Properties.Resources.onnnn;
            txtNamePlayer.Text = "Người Chơi";
            menuStrip1.Parent = pnTableChess;
            nguoiChoi = 1;
            BanDo = new Label[soHang + 2, soCot + 2];
            vtBanDo = new int[soHang + 2, soCot + 2];
            cacQuanCo = new Stack<QuanCo>();

            XayDungBanCo();
        }

        private void KetThucTroChoi() 
        {
            tmCooldown.Stop();
            ketThucTroChoi = true;
            nenKetThucTroChoi();
        }

        private void nenKetThucTroChoi() 
        {
            for (int i = 2; i <= soHang; i++)
                for (int j = 1; j <= soCot; j++)
                {
                    BanDo[i, j].BackColor = Color.Gray;
                }
        }

        private void DoiNguoiChoi()  
        {
            if (nguoiChoi == 1)
            {
                nguoiChoi = 2;
                txtNamePlayer.Text = "Người Chơi 2";
                ptbPayer.Image = Properties.Resources.x_copy;
            }
            else
            {
                nguoiChoi = 1;
                txtNamePlayer.Text = "Người Chơi 1";
                ptbPayer.Image = Properties.Resources.onnnn;
            }
        }

        private void KiemTra(int x, int y)  
        {
            int i = x - 1, j = y;
            int cot = 1, hang = 1, cheoChinh = 1, cheoPhu = 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i >= 0)
            {
                cot++;
                i--;
            }
            i = x + 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i <= soHang)
            {
                cot++;
                i++;
            }
            i = x; j = y - 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && j >= 0)
            {
                hang++;
                j--;
            }
            j = y + 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && j <= soCot)
            {
                hang++;
                j++;
            }
            i = x - 1; j = y - 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i >= 0 && j >= 0)
            {
                cheoChinh++;
                i--; j--;
            }
            i = x + 1; j = y + 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i <= soHang && j <= soCot)
            {
                cheoChinh++;
                i++; j++;
            }
            i = x - 1; j = y + 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i >= 0 && j <= soCot)
            {
                cheoPhu++;
                i--; j++;
            }
            i = x + 1; j = y - 1;
            while (vtBanDo[x, y] == vtBanDo[i, j] && i <= soHang && j >= 0)
            {
                cheoPhu++;
                i++; j--;
            }

            if (cot == 5 || hang == 5 || cheoChinh == 5 || cheoPhu == 5)
            {
                KetThucTroChoi();
                if (choiVoiMay)
                {
                    if (nguoiChoi == 1)
                        MessageBox.Show("Bạn thắng !!");
                    else
                        MessageBox.Show("Bạn thua!!");
                }
                else
                {
                    if (nguoiChoi == 1)
                        MessageBox.Show("Người chơi 1 thắng");
                    else
                        MessageBox.Show("Người chơi 2 thắng");
                }
                HienThiMenu();

            }
        }
        private void HienThiMenu()
        {
            Form menuForm = new Form();
            menuForm.Text = "Menu";
            menuForm.Size = new Size(300, 350);

            Button btnChoiLai = new Button { Text = "Chơi lại", Location = new Point(50, 30) };
            Button btnChoiVoiMay = new Button { Text = "Chơi với máy", Location = new Point(50, 70) };
            Button btnChoiVoiNguoi = new Button { Text = "Chơi với người", Location = new Point(50, 110), Size = new Size(100,23) };
            Button btnChoiOnline = new Button { Text = "Chơi online", Location = new Point(50, 150) };

            btnChoiLai.Click += (s, e) => { menuForm.Close(); ChoiLai(); };
            btnChoiVoiMay.Click += (s, e) => { menuForm.Close(); ChoiVoiMay(); };
            btnChoiVoiNguoi.Click += (s, e) => { menuForm.Close(); NguoiChoiVsNguoiChoi(); };
            btnChoiOnline.Click += (s, e) => { menuForm.Close(); ChoiOnline(); };

            menuForm.Controls.Add(btnChoiLai);
            menuForm.Controls.Add(btnChoiVoiMay);
            menuForm.Controls.Add(btnChoiVoiNguoi);
            menuForm.Controls.Add(btnChoiOnline);

            menuForm.ShowDialog();
        }
        private void ChoiLai()
        {
            tmCooldown.Stop();

            // Khôi phục trạng thái ban đầu
            ketThucTroChoi = false; // Trạng thái trò chơi không kết thúc
            psbCooldownTime.Value = 0; // Đặt lại thanh thời gian
            pnTableChess.Controls.Clear(); // Xóa bảng cờ hiện tại

            // Khởi tạo lại các biến cần thiết
            BanDo = new Label[soHang + 2, soCot + 2]; // Khởi tạo lại bảng
            vtBanDo = new int[soHang + 2, soCot + 2]; // Khởi tạo lại vị trí bàn cờ
            cacQuanCo = new Stack<QuanCo>(); // Khởi tạo lại stack quân cờ

            // Xây dựng lại bàn cờ
            XayDungBanCo();

            // Thiết lập lại hình ảnh và tên người chơi dựa trên chế độ chơi
            if (choiVoiMay)
            {
                ptbPayer.Image = Properties.Resources.onnnn; // Hình ảnh cho người chơi
                txtNamePlayer.Text = "Người Chơi"; // Tên người chơi
            }
            else
            {
                ptbPayer.Image = null; // Hình ảnh trống cho chế độ người chơi vs. người chơi
                txtNamePlayer.Text = ""; // Không hiển thị tên cho chế độ này
            }

            // Thiết lập lại menuStrip cho bàn cờ
            menuStrip1.Parent = pnTableChess;

            // Khởi động lại thời gian đếm ngược nếu cần
            tmCooldown.Start();
        }

        private void ChoiVoiMay()
        {
            choiVoiMay = true;
            ketThucTroChoi = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Properties.Resources.onnnn;
            txtNamePlayer.Text = "Người Chơi";
            menuStrip1.Parent = pnTableChess;
            nguoiChoi = 1;
            BanDo = new Label[soHang + 2, soCot + 2];
            vtBanDo = new int[soHang + 2, soCot + 2];
            cacQuanCo = new Stack<QuanCo>();

            XayDungBanCo();
        }

        private void NguoiChoiVsNguoiChoi()
        {
            choiVoiMay = false;
            ketThucTroChoi = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            txtNamePlayer.Text = "";
            ptbPayer.Image = null;
            menuStrip1.Parent = pnTableChess;
            nguoiChoi = 1;
            BanDo = new Label[soHang + 2, soCot + 2];
            vtBanDo = new int[soHang + 2, soCot + 2];
            cacQuanCo = new Stack<QuanCo>();

            XayDungBanCo();
        }

        private void ChoiOnline()
        {
            // Khởi động lại trò chơi online
        }

        #region AI

        private int[] TanCong = new int[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private int[] PhongThu = new int[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        private void DatCo(int x, int y)
        {
            nguoiChoi = 0;
            psbCooldownTime.Value = 0;
            BanDo[x + 1, y].Image = Properties.Resources.x;

            vtBanDo[x, y] = 2; 
            KiemTra(x, y); 

            quanCo = new QuanCo(BanDo[x + 1, y], x, y);
            cacQuanCo.Push(quanCo);
        }

        
        private void MayTimQuanCo()
        {
            if (ketThucTroChoi) return; 
            long max = 0;
            int imax = 1, jmax = 1;
            for (int i = 1; i < soHang; i++)
            {
                for (int j = 1; j < soCot; j++)
                    if (vtBanDo[i, j] == 0) 
                    {
                        long temp = TinhToan(i, j); 
                        if (temp > max)
                        {
                            max = temp;
                            imax = i; jmax = j; 
                        }
                    }
            }
            DatCo(imax, jmax); 
        }

        private long TinhToan(int x, int y)
        {
            return QuanCoDich(x, y) + QuanCoMay(x, y);
        }

        private long QuanCoMay(int x, int y)
        {
            int i = x - 1, j = y;
            int cot = 0, hang = 0, cheoChinh = 0, cheoPhu = 0;
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;

            while (vtBanDo[i, j] == 2 && i >= 0)
            {
                cot++;
                i--;
            }
            if (vtBanDo[i, j] == 0) sc_ = 1; 
            i = x + 1;
            while (vtBanDo[i, j] == 2 && i <= soHang)
            {
                cot++;
                i++;
            }
            if (vtBanDo[i, j] == 0) sc = 1; 

            i = x; j = y - 1;
            while (vtBanDo[i, j] == 2 && j >= 0)
            {
                hang++;
                j--;
            }
            if (vtBanDo[i, j] == 0) sr_ = 1; 
            j = y + 1;
            while (vtBanDo[i, j] == 2 && j <= soCot)
            {
                hang++;
                j++;
            }
            if (vtBanDo[i, j] == 0) sr = 1;

            i = x - 1; j = y - 1;
            while (vtBanDo[i, j] == 2 && i >= 0 && j >= 0)
            {
                cheoChinh++;
                i--; j--;
            }
            if (vtBanDo[i, j] == 0) sm_ = 1; 
            i = x + 1; j = y + 1;
            while (vtBanDo[i, j] == 2 && i <= soHang && j <= soCot)
            {
                cheoChinh++;
                i++; j++;
            }
            if (vtBanDo[i, j] == 0) sm = 1; 

            i = x - 1; j = y + 1;
            while (vtBanDo[i, j] == 2 && i >= 0 && j <= soCot)
            {
                cheoPhu++;
                i--; j++;
            }
            if (vtBanDo[i, j] == 0) se_ = 1; 
            i = x + 1; j = y - 1;
            while (vtBanDo[i, j] == 2 && i <= soHang && j >= 0)
            {
                cheoPhu++;
                i++; j--;
            }
            if (vtBanDo[i, j] == 0) se = 1; 

            if (cot == 4) cot = 5;
            if (hang == 4) hang = 5;
            if (cheoChinh == 4) cheoChinh = 5;
            if (cheoPhu == 4) cheoPhu = 5;

            if (cot == 3 && sc == 1 && sc_ == 1) cot = 4;
            if (hang == 3 && sr == 1 && sr_ == 1) hang = 4;
            if (cheoChinh == 3 && sm == 1 && sm_ == 1) cheoChinh = 4;
            if (cheoPhu == 3 && se == 1 && se_ == 1) cheoPhu = 4;

            if (cot == 2 && hang == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (cot == 2 && cheoChinh == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) cot = 3;
            if (cot == 2 && cheoPhu == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) cot = 3;
            if (hang == 2 && cheoChinh == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (hang == 2 && cheoPhu == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (cheoPhu == 2 && cheoChinh == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) cot = 3;

            long Tong = TanCong[hang] + TanCong[cot] + TanCong[cheoChinh] + TanCong[cheoPhu];

            return Tong;
        }

        private long QuanCoDich(int x, int y)
        {
            int i = x - 1, j = y;
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;
            int cot = 0, hang = 0, cheoChinh = 0, cheoPhu = 0;

            while (vtBanDo[i, j] == 1 && i >= 0)
            {
                cot++;
                i--;
            }
            if (vtBanDo[i, j] == 0) sc_ = 1; 
            i = x + 1;
            while (vtBanDo[i, j] == 1 && i <= soHang)
            {
                cot++;
                i++;
            }
            if (vtBanDo[i, j] == 0) sc = 1; 

            i = x; j = y - 1;
            while (vtBanDo[i, j] == 1 && j >= 0)
            {
                hang++;
                j--;
            }
            if (vtBanDo[i, j] == 0) sr_ = 1; 
            j = y + 1;
            while (vtBanDo[i, j] == 1 && j <= soCot)
            {
                hang++;
                j++;
            }
            if (vtBanDo[i, j] == 0) sr = 1; 

            i = x - 1; j = y - 1;
            while (vtBanDo[i, j] == 1 && i >= 0 && j >= 0)
            {
                cheoChinh++;
                i--; j--;
            }
            if (vtBanDo[i, j] == 0) sm_ = 1; 
            i = x + 1; j = y + 1;
            while (vtBanDo[i, j] == 1 && i <= soHang && j <= soCot)
            {
                cheoChinh++;
                i++; j++;
            }
            if (vtBanDo[i, j] == 0) sm = 1; 

            i = x - 1; j = y + 1;
            while (vtBanDo[i, j] == 1 && i >= 0 && j <= soCot)
            {
                cheoPhu++;
                i--; j++;
            }
            if (vtBanDo[i, j] == 0) se_ = 1;
            i = x + 1; j = y - 1;
            while (vtBanDo[i, j] == 1 && i <= soHang && j >= 0)
            {
                cheoPhu++;
                i++; j--;
            }
            if (vtBanDo[i, j] == 0) se = 1; 

            if (cot == 4) cot = 5;
            if (hang == 4) hang = 5;
            if (cheoChinh == 4) cheoChinh = 5;
            if (cheoPhu == 4) cheoPhu = 5;

            if (cot == 3 && sc == 1 && sc_ == 1) cot = 4;
            if (hang == 3 && sr == 1 && sr_ == 1) hang = 4;
            if (cheoChinh == 3 && sm == 1 && sm_ == 1) cheoChinh = 4;
            if (cheoPhu == 3 && se == 1 && se_ == 1) cheoPhu = 4;

            if (cot == 2 && hang == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (cot == 2 && cheoChinh == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) cot = 3;
            if (cot == 2 && cheoPhu == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) cot = 3;
            if (hang == 2 && cheoChinh == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (hang == 2 && cheoPhu == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) cot = 3;
            if (cheoPhu == 2 && cheoChinh == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) cot = 3;

            long Tong = PhongThu[hang] + PhongThu[cot] + PhongThu[cheoChinh] + PhongThu[cheoPhu];

            return Tong;
        }

        #endregion AI

    }


    public class QuanCo  
{
    public Label lb;
    public int X;
    public int Y;

    public QuanCo()
    {
        lb = new Label();
    }

    public QuanCo(Label _lb, int x, int y)
    {
        lb = new Label();
        lb = _lb;
        X = x;
        Y = y;
    }
}

}
