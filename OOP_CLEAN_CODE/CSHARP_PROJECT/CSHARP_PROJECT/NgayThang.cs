using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_PROJECT
{
    internal class NgayThang
    {
        public int Ngay { get; private set; }
        public int Thang { get; private set; }
        public int Nam { get; private set; }

        public NgayThang ()
        {
            Ngay = 1;
            Thang = 1;
            Nam = 2000;
        }

        public NgayThang (int ngay, int thang, int nam)
        {
            ValidateDate(ngay, thang, nam);
            Ngay = ngay;
            Thang = thang;
            Nam = nam;
        }


        private void ValidateDate (int ngay, int thang, int nam)
        {
            try
            {
                new DateTime(nam, thang, ngay);
            } catch
            {
                throw new ArgumentException("Vui long nhap ngay thang hop le!");
            }
        }

        public void NhapNgaySinh ()
        {
            while (true)
            {
                try
                {
                    string fullDateStr;
                    Console.Write("Nhap ngay sinh (dd/mm/yyyy): ");
                    fullDateStr = Console.ReadLine();
                    string[] parts = fullDateStr.Split('/');
                    if (parts.Length != 3)
                    {
                        Console.WriteLine("Ngay sinh khong dung dinh dang dd/mm/yyyy");
                        continue;
                    }

                    int ngay, thang, nam;
                    ngay = int.Parse(parts[0]);
                    thang = int.Parse(parts[1]);
                    nam = int.Parse(parts[2]);
                    ValidateDate(ngay, thang, nam);
                    Ngay = ngay;
                    Thang = thang;
                    Nam = nam;
                    break;
                } catch
                {
                    Console.WriteLine("Ngay sinh khong hop le!");
                }
            }
        }

        public void XuatNgaySinh ()
        {
            Console.WriteLine("Ngay {0} Thang {1} Nam {2} ({3}/{4}/{5})", Ngay, Thang, Nam, Ngay, Thang, Nam);
        }

    }
}
