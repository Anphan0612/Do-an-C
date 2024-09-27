using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class CaRo
    {
        private char[,] arr = null; //mảng để lưu X,O, và N(null)       
        public bool LuotDiHienTai = false; //quân X là False, quân O la True.
        public void ResetGame()
        {
            arr = new char[30, 30];
            LuotDiHienTai = false;
        }
        public void ThemQuanX(int dong, int cot)
        {
            arr[dong, cot] = 'X';
            DuLieuLuotDi LuotDi = new DuLieuLuotDi();
        }
        public void ThemQuanO(int dong, int cot)
        {
            arr[dong, cot] = 'O';
            DuLieuLuotDi LuotDi = new DuLieuLuotDi();
            LuotDi.dong = dong;
            LuotDi.cot = cot;
            LuotDi.Player = true;
        }
        private bool KiemTraDoc(int dong, int cot, char QuanCo)
        {
            int KiemTraLenTren = 0;
            int KiemTraXuongDuoi = 0;
            bool BiChanDauTren = false;
            bool BiChanDauDuoi = false;
            for (int i = dong + 1; i < 30; i++)
            {
                if (arr[i, cot] == QuanCo)
                    KiemTraXuongDuoi++;
                else
                {
                    if (arr[i, cot] == 'X' || arr[i, cot] == 'O')
                        BiChanDauDuoi = true;
                    break;
                }
            }
            for (int i = dong - 1; i >= 0; i--)
            {
                if (arr[i, cot] == QuanCo)
                    KiemTraLenTren++;
                else
                {
                    if (arr[i, cot] == 'X' || arr[i, cot] == 'O')
                        BiChanDauTren = true;
                    break;
                }
            }
            if (BiChanDauDuoi == true && BiChanDauTren == true)
                return false;
            if (KiemTraLenTren + KiemTraXuongDuoi >= 4)
                return true;
            return false;
        }
        private bool KiemTraNgang(int dong, int cot, char QuanCo)
        {
            int KiemTraSangTrai = 0;
            int KiemTraSangPhai = 0;
            bool BiChanPhai = false;
            bool BiChanTrai = false;
            for (int i = cot + 1; i < 30; i++)
            {
                if (arr[dong, i] == QuanCo)
                    KiemTraSangPhai++;
                else
                {
                    if (arr[dong, i] == 'X' || arr[dong, i] == 'O')
                        BiChanPhai = true;
                    break;
                }
            }
            for (int i = cot - 1; i >= 0; i--)
            {
                if (arr[dong, i] == QuanCo)
                    KiemTraSangTrai++;
                else
                {
                    if (arr[dong, i] == 'X' || arr[dong, i] == 'O')
                        BiChanTrai = true;
                    break;
                }
            }
            if (BiChanPhai == true && BiChanTrai == true)
                return false;
            if (KiemTraSangPhai + KiemTraSangTrai >= 4)
                return true;
            return false;
        }
        private bool KiemTraCheoSac(int dong, int cot, char QuanCo) // theo hướng dấu sắc '/'
        {
            int XuongSangTrai = 0;
            int LenSangPhai = 0;
            int d1 = dong;
            int c1 = cot;
            int d2 = dong;
            int c2 = cot;
            bool BiChanPhaiTren = false;
            bool BiChanTraiDuoi = false;
            while (true)
            {
                d1++;
                c1--;
                if (arr[d1, c1] == QuanCo)
                    XuongSangTrai++;
                else
                {
                    if (arr[d1, c1] == 'X' || arr[d1, c1] == 'O')
                        BiChanTraiDuoi = true;
                    break;
                }
            }
            while (true)
            {
                d2--;
                c2++;
                if (arr[d2, c2] == QuanCo)
                    LenSangPhai++;
                else
                {
                    if (arr[d2, c2] == 'X' || arr[d2, c2] == 'O')
                        BiChanPhaiTren = true;
                    break;
                }
            }
            if (BiChanPhaiTren == true && BiChanTraiDuoi == true)
                return false;
            if (XuongSangTrai + LenSangPhai >= 4)
                return true;
            return false;
        }
        private bool KiemTraCheoHuyen(int dong, int cot, char QuanCo) // theo hướng dấu huyền '\'
        {
            int LenSangTrai = 0;
            int XuongSangPhai = 0;
            int d1 = dong;
            int c1 = cot;
            int d2 = dong;
            int c2 = cot;
            bool BiChanTraiTren = false;
            bool BiChanPhaiDuoi = false;
            while (true)
            {
                d1--;
                c1--;
                if (arr[d1, c1] == QuanCo)
                    LenSangTrai++;
                else
                {
                    if (arr[d1, c1] == 'X' || arr[d1, c1] == 'O')
                        BiChanPhaiDuoi = true;
                    break;
                }
            }
            while (true)
            {
                d2++;
                c2++;
                if (arr[d2, c2] == QuanCo)
                    XuongSangPhai++;
                else
                {
                    if (arr[d2, c2] == 'X' || arr[d2, c2] == 'O')
                        BiChanTraiTren = true;
                    break;
                }
            }
            if (BiChanPhaiDuoi == true && BiChanTraiTren == true)
                return false;
            if (LenSangTrai + XuongSangPhai >= 4)
                return true;
            return false;
        }
        public bool KiemTraWin(int dong, int cot, char QuanCo)
        {
            if (KiemTraDoc(dong, cot, QuanCo) || KiemTraNgang(dong, cot, QuanCo) || KiemTraCheoSac(dong, cot, QuanCo) || KiemTraCheoHuyen(dong, cot, QuanCo))
                return true;
            return false;
        }
    }
}
