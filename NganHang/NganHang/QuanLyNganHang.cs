using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class QuanLyNganHang
    {

        #region Fields
        private List<TaiKhoanNganHang> _dsTaiKhoanNganHang;
        
        #endregion

        #region Properties
        public List<TaiKhoanNganHang> DsTaiKhoanNganHang { get => _dsTaiKhoanNganHang; private set => _dsTaiKhoanNganHang = value;  }
        #endregion


        #region Constructors
        public QuanLyNganHang ()
        {
            DsTaiKhoanNganHang = new List<TaiKhoanNganHang> ();
        }

        #endregion

        #region Methods


       

        public bool ThemTaiKhoanMoi (TaiKhoanNganHang taiKhoanNganHang)
        {
            DsTaiKhoanNganHang.Add(taiKhoanNganHang);
            return true;
        }

        public bool XoaTaiKhoanTheoSoTaiKhoan (string soTaiKhoan)
        {
            foreach (TaiKhoanNganHang taiKhoan in DsTaiKhoanNganHang)
            {
                if (taiKhoan.SoTaiKhoan == soTaiKhoan)
                {
                    DsTaiKhoanNganHang.Remove(taiKhoan);
                    return true;
                }
            }
            return false;
        }

        public TaiKhoanNganHang TimTaiKhoanTheoSoTaiKhoan (string soTaiKhoan)
        {
            foreach (TaiKhoanNganHang taiKhoan in DsTaiKhoanNganHang)
            {
                if (taiKhoan.SoTaiKhoan == soTaiKhoan) return taiKhoan;
            }
            return null;
        }

        public KhachHang TimKhachHangTheoMaKH (string maKh)
        {
            foreach (TaiKhoanNganHang taiKhoan in DsTaiKhoanNganHang)
            {
                if (taiKhoan.ChuTaiKhoan.MaKh == maKh) return taiKhoan.ChuTaiKhoan;
            }
            return null;
        }

        public void HienThiToanBoDanhSachTaiKhoan ()
        {
            for (int i = 0; i < DsTaiKhoanNganHang.Count; i++)
            {
                Console.WriteLine("[{0}] {1}", (i + 1), DsTaiKhoanNganHang[i].ToString());
            }
        }


        
        public string LaySoTaiKhoanMoi ()
        {
            string finalSoTaiKhoan;
            do
            {
                finalSoTaiKhoan = Utils.RandomSoTaiKhoan();
            } while (TimTaiKhoanTheoSoTaiKhoan(finalSoTaiKhoan) != null);
            return finalSoTaiKhoan;
        }

        public string LayMaKHMoi ()
        {
            string finalMaKh;
            do
            {
                finalMaKh = Utils.RandomMaKH();
            } while (TimKhachHangTheoMaKH(finalMaKh) != null);
            return finalMaKh;
        }
        

        #endregion

    }
}
