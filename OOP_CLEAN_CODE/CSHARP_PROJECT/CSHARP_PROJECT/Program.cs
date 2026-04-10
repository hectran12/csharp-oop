using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_PROJECT
{
    internal class Program
    {
        static void ShowBar(int amount)
        {
            for(int i = 0; i< amount; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
           
            SinhVien sinhVien = new SinhVien();

            ShowBar(70);
            Console.WriteLine("\t\tNhap thong tin sinh vien");
            ShowBar(70);
            sinhVien.NhapThongTinSinhVien();
            ShowBar(70);
            Console.WriteLine("\t\tXuat thong tin sinh vien");
            ShowBar(70);
            sinhVien.XuatThongTin();
        }
    }
}
