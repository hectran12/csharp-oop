using System;
using System.Text;

namespace quanlynv
{
    class Program
    {
        static List<PhongBan> dsPB = new List<PhongBan>();
        static void TestQLNV()
        {
            PhongBan pNS = new PhongBan();
            pNS.MaPhongBan = 1;
            pNS.TenPhongBan = "Phong Nhan Su";
            dsPB.Add(pNS);
            NhanVien teo = new NhanVien();
            teo.MaNhanVien = 1;
            teo.TenNhanVien = "Tèo";
            teo.ChucVu = LoaiChucVu.TRUONG_PHONG;
            pNS.ThemNhanVien(teo);

            NhanVien ty = new NhanVien();
            ty.MaNhanVien = 2;
            ty.TenNhanVien = "Tèo";
            ty.ChucVu = LoaiChucVu.NHAN_VIEN;
            pNS.ThemNhanVien(ty);

            NhanVien met = new NhanVien();
            met.MaNhanVien = 200;
            met.TenNhanVien = "met thi mwt";
            met.ChucVu = LoaiChucVu.NHAN_VIEN;
            pNS.ThemNhanVien(met);

            PhongBan pkt = new PhongBan();
            pkt.MaPhongBan = 2;
            pkt.TenPhongBan = "Phong Ke Toan";
            dsPB.Add(pkt);

            NhanVien bin = new NhanVien();
            bin.MaNhanVien = 3;
            bin.TenNhanVien = "bin bin bin";
            bin.ChucVu = LoaiChucVu.PHO_PHONG;
            pkt.ThemNhanVien(bin);

            Console.WriteLine("Toan bo nhan vien: ");
            foreach (PhongBan pb in dsPB)
            {
                Console.WriteLine(pb.TenPhongBan);
                pb.XuatToanBoNhanVien();
            }
            NhanVien old = pkt.TimNhanVien(3);
            if (old != null)
            {
                old.TenNhanVien = "Bim bim bim";
            }
            Console.WriteLine("Toan bo nhan vien: ");
            foreach (PhongBan pb in dsPB)
            {
                Console.WriteLine(pb.TenPhongBan);
                pb.XuatToanBoNhanVien();
            }
            if (pNS.XoaNhanVien(113) == false)
            {
                Console.WriteLine("Khong tim thay ma nhan vien!");
            } else
            {
                Console.WriteLine("Toan bo nhan vien: ");
                foreach (PhongBan pb in dsPB)
                {
                    Console.WriteLine(pb.TenPhongBan);
                    pb.XuatToanBoNhanVien();
                }
            }

            Console.WriteLine("Danh sach nhan vien thuoc phong nhan su");
            pNS.XuatToanBoNhanVien();
            Console.WriteLine("Sap xep");
            pNS.SapXep();
            pNS.XuatToanBoNhanVien();

            long sum = 0;
            foreach (PhongBan pb in dsPB)
            {
                sum += pb.TongLuong();
            }
            Console.WriteLine("Tong luong phai tra: " + sum);
        }
        static void Main (string[] args)
        {
            TestQLNV();
        }
    }
}