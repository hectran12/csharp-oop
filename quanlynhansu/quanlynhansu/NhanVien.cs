using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhansu
{
    internal class NhanVien
    {
        public const long LUONG_CO_BAN = 10000000;
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public LoaiChucVu ChucVu { get; set; }
        public string Phong { get; set; }
        public long TinhLuong
        {
            get
            {
                if (ChucVu == LoaiChucVu.GIAM_DOC)
                {
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.25);
                } else if(ChucVu == LoaiChucVu.TRUONG_PHONG)
                {
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.15);
                } else if (ChucVu == LoaiChucVu.PHO_PHONG)
                {
                    return LUONG_CO_BAN + (long)(LUONG_CO_BAN * 0.5);
                } else
                {
                    return LUONG_CO_BAN;
                }

            }
        }

      

        public int genID()
        {
            Random rd = new Random();
            return rd.Next(10000000, 99999999);
        }
        public override string ToString()
        {
            return "STT: " + MaNhanVien + " | " + "Name: " + TenNhanVien + " | " + "Birthday: " + NgaySinh.Day + "/" + NgaySinh.Month + "/" + NgaySinh.Year + " | CV: " + ChucVu + " | Phong: " + Phong + " | Luong: " + TinhLuong;
        }
    }
}
