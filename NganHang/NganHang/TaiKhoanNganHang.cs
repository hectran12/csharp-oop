using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class TaiKhoanNganHang
    {
        #region Fields
        private string _soTaiKhoan;
        private KhachHang _chuTaiKhoan;
        private long _soDu;
        private LoaiTaiKhoan _loaiTaiKhoan;
        private List<LichSuGiaoDich> _lichSuGiaoDich;
        #endregion

        #region Properties
        public string SoTaiKhoan { get => _soTaiKhoan; private set => _soTaiKhoan = value; }
        public KhachHang ChuTaiKhoan { get => _chuTaiKhoan; private set => _chuTaiKhoan = value; }
        public long SoDu { get => _soDu; private set => _soDu = value; }
        public LoaiTaiKhoan LoaiTaiKhoan { get => _loaiTaiKhoan; private set => _loaiTaiKhoan = value; }

        public List<LichSuGiaoDich> LSGiaoDich { get => _lichSuGiaoDich; private set => _lichSuGiaoDich = value;  }
        #endregion


        #region Constructors
        public TaiKhoanNganHang (string soTaiKhoan, KhachHang chuTaiKhoan, long soDu, LoaiTaiKhoan loaiTaiKhoan)
        {
            SoTaiKhoan = soTaiKhoan;
            ChuTaiKhoan = chuTaiKhoan;
            SoDu = soDu;
            LoaiTaiKhoan = loaiTaiKhoan;
            LSGiaoDich = new List<LichSuGiaoDich>();
        }

        public TaiKhoanNganHang ()
        {
            SoTaiKhoan = String.Empty;
            ChuTaiKhoan = new KhachHang();
            SoDu = 0;
            LoaiTaiKhoan = LoaiTaiKhoan.THANH_TOAN;
            LSGiaoDich = new List<LichSuGiaoDich>();
        }

        #endregion

        #region Override Methods
        public override string ToString()
        {
            return "Ho va ten: " + ChuTaiKhoan.HoTen + ", So tai khoan: " + SoTaiKhoan + ", So Du: " + SoDu + ", Loai TK: " + LoaiTaiKhoan;
        }
        #endregion

        #region Methods

        public bool ThemLichSu (LoaiGiaoDich loaiGiaoDich, string Message)
        {
            LSGiaoDich.Add(new LichSuGiaoDich(loaiGiaoDich, Message));
            return true;
        }

        private bool CongTien (long soTienCong)
        {
            if (soTienCong <= 0) return false;
            SoDu += soTienCong;
            return true;
        }

        private bool TruTien (long soTienTru)
        {
            if (soTienTru <= 0) return false;
            if (soTienTru > SoDu) return false;
            SoDu -= soTienTru;
            return true;
        }

        public bool NapTien (long soTienNap)
        {
            if (CongTien(soTienNap) == false) return false;
            ThemLichSu(LoaiGiaoDich.NAP_TIEN, "Nap tien thanh cong " + soTienNap + "VND");
            return true;
        }

        public bool RutTien (long soTienRut)
        {
            if (TruTien(soTienRut) == false) return false;
            ThemLichSu(LoaiGiaoDich.RUT_TIEN, "Rut tien thanh cong " + soTienRut + "VND");
            return true;
        }
        
        public bool NhanTien(string HoVaTenNguoiChuyen, long soTienNhan)
        {
            if (CongTien(soTienNhan) == false) return false;
            ThemLichSu(LoaiGiaoDich.NHAN_TIEN, "Nhan tien chuyen khoan tu " +
                HoVaTenNguoiChuyen + ", so tien nhan la: " + soTienNhan
                + "VND");
            return true;
        }
        
        public bool ChuyenKhoan (long soTienChuyen, TaiKhoanNganHang taiKhoanMuonChuyen)
        {
            if (TruTien(soTienChuyen) == false) return false;
            if (taiKhoanMuonChuyen.NhanTien(ChuTaiKhoan.HoTen, soTienChuyen) == false) return false;
            return true;
        }

        

        #endregion

    }
}
