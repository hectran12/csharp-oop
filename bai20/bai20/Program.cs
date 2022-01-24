using System;
using System.Text;

namespace bai20
{
    class Program
    {
        static void testsinhvien()
        {
            Sinhvienchinhthuc hoa = new Sinhvienchinhthuc();
            hoa.Ma = 1;
            hoa.ten = "Trong Hoa";
            Console.WriteLine("Luong cua " + hoa.ten);
            hoa.hocphi();
            Sinhvientouu ty = new Sinhvientouu();
            ty.ten = "Ty teo";
            Console.WriteLine("Luong cua " + ty.ten);
            ty.hocphi();
        }
        static void Main (string[] args)
        {
            testsinhvien();
        }
    }
}