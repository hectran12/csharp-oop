using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynv
{
    internal class NhanVien
    {
        public const long LUONG_CO_BAN = 10000000;
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public LoaiChucVu ChucVu { get; set; }
        public PhongBan Phong { get; set; }
        public long TinhLuong
        {
          
            get
            {
                if (ChucVu == LoaiChucVu.GIAM_DOC)
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.25);
                if (ChucVu == LoaiChucVu.TRUONG_PHONG)
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.15);
                if (ChucVu == LoaiChucVu.PHO_PHONG)
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.05);
                return LUONG_CO_BAN;
            }
   

        }
        public override string ToString()
        {
            return this.MaNhanVien +
                "\t" + this.TenNhanVien + 
                "\t" + this.ChucVu + "\t==>" + 
                this.TinhLuong;

        }
    }
}
