using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynv
{
    internal class PhongBan
    {
        private List<NhanVien> dsNv = new List<NhanVien>();
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public NhanVien TruongPhong { get; set; }
        public bool ThemNhanVien(NhanVien nv)
        {
            bool trungMaNV = false;
            foreach (NhanVien oldNV in dsNv)
            {
                if(oldNV.MaNhanVien == nv.MaNhanVien)
                {
                    trungMaNV = true;
                    break;
                }
            }
            if (trungMaNV == true)
            {
                return false;
            } else
            {
                nv.Phong = this;
                dsNv.Add(nv);
                return true;
            }
        }

        public void XuatToanBoNhanVien()
        {
            foreach (NhanVien nv in dsNv)
            {
                Console.WriteLine(nv);
            }
        }

        public NhanVien TimNhanVien (int MaNv)
        {
            foreach (NhanVien old in dsNv)
            {
                if (old.MaNhanVien == MaNv)
                {
                    return old;
                }
            }
            return null;          
        }

        public bool XoaNhanVien (int maNv)
        {
            NhanVien nv = TimNhanVien(maNv);
            if (nv == null)
            {
                return false;
            } else
            {
                dsNv.Remove(nv);
                return true;
            }
        }
        private int compare (NhanVien nv1, NhanVien nv2)
        {
            int kqSSTen = string.Compare(nv1.TenNhanVien, nv2.TenNhanVien, true);
            if (kqSSTen == 0)
            {
                 if(nv1.MaNhanVien < nv2.MaNhanVien)
                {
                    return 1;
                }
                if (nv1.MaNhanVien > nv2.MaNhanVien)
                {
                    return -1;
                }
                return 0;
            } 
            return kqSSTen;
        }
        public void SapXep()
        {
            dsNv.Sort(compare);
        }

        public long TongLuong()
        {
            long sum = 0;
            foreach (NhanVien nv in dsNv)
            {
                sum += nv.TinhLuong;
            }
            return sum;
        }
    }
}
