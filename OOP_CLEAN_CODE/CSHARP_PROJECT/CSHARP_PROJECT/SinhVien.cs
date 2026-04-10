using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_PROJECT
{
    internal class SinhVien
    {
        public string MaSV { get; private set; }
        public string HoTen { get; private set; }
        public NgayThang NgaySinh { get; private set; }
        public DiemThi DiemThi { get; private set; }
       

        public SinhVien ()
        {
            MaSV = "";
            HoTen = "";
            DiemThi = new DiemThi ();
            NgaySinh = new NgayThang ();
        }

        public SinhVien (string maSV, string hoTen, DiemThi diemThi, NgayThang ngayThang)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemThi = diemThi;
            NgaySinh = ngayThang;
        }

        private string NhapThongTin(string infoName)
        {
            string infoValue;
            while (true)
            {
                Console.Write($"Nhap {infoName}: ");
                infoValue = Console.ReadLine();
                if (String.IsNullOrEmpty(infoValue))
                {
                    Console.WriteLine($"Vui long khong de trong {infoName}");
                    continue;
                }
                break;

            }
            return infoValue;
        }

        public void NhapThongTinSinhVien ()
        {
            string maSV, hoTen;
            
            maSV = NhapThongTin("Ma Sinh Vien");
            hoTen = NhapThongTin("Ho va Ten");

            DiemThi diemThi = new DiemThi();
            NgayThang ngaySinh = new NgayThang();
            diemThi.NhapDiem();
            ngaySinh.NhapNgaySinh();

            MaSV = maSV;
            HoTen = hoTen;
            DiemThi = diemThi;
            NgaySinh = ngaySinh;

        }

        public void XuatThongTin ()
        {
            Console.WriteLine("Ho va ten: {0}", HoTen);
            Console.WriteLine("Ma SV: {0}", MaSV);
            NgaySinh.XuatNgaySinh();
            Console.WriteLine("Diem Toan: {0}, Diem Ly: {1}, Diem Hoa: {2}", DiemThi.DiemToan, DiemThi.DiemLy, DiemThi.DiemHoa);
            Console.WriteLine("Diem trung binh mon: {0:f2}", DiemThi.TinhDiemTrungBinh());
        }
    }
}
