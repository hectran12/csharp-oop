using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class KhachHang
    {
        #region Fields
        private string _maKh;
        private string _hoTen;
        private string _soCCCD;
        private string _soDienThoai;
        #endregion
        #region Properties
        public string MaKh { get => _maKh; private set => _maKh = value; }
        public string HoTen { get => _hoTen; private set => _hoTen = value;  }
        public string SoCCCD { get => _soCCCD; private set => _soCCCD = value; }
        public string SoDienThoai { get => _soDienThoai; private set => _soDienThoai = value; }
        #endregion

        #region Constructors
        public KhachHang (string maKh, string hoTen, string soCCCD, string soDienThoai)
        {

            if (!Utils.checkValidCCCD(soCCCD) || !Utils.checkValidPhoneNumber(soDienThoai))
                throw new AggregateException("so CCCD phai la 12 ki tu va so dien thoai phai la 10 chu so.");

            MaKh = maKh;
            HoTen = Utils.FormatFullName(hoTen);
            SoCCCD = soCCCD;
            SoDienThoai = soDienThoai;

            
        }

        public KhachHang ()
        {
            MaKh = string.Empty;
            HoTen = string.Empty;
            SoCCCD = string.Empty;
            SoDienThoai = string.Empty;
        }
        #endregion

        #region Methods
        public bool setThongTin(string Makh, string HoTen, string SoCCCD, string SoDienThoai)
        {
            if (!Utils.checkValidCCCD(SoCCCD) || !Utils.checkValidPhoneNumber(SoDienThoai)) return false;
            this.MaKh = MaKh;
            this.HoTen = Utils.FormatFullName(HoTen);
            this.SoCCCD = SoCCCD;
            this.SoDienThoai = SoDienThoai;
            return true;
        }

        public void XuatThongTin ()
        {
            Console.WriteLine("Ma khach hang: {0}\nHo va ten khach hang: {1}\nSo CCCD: {2}\nSo Dien Thoai: {3}",
                MaKh, HoTen, SoCCCD, SoDienThoai
            );
        }

        #endregion


    }
}
