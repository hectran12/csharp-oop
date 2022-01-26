using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LuongGiac
    {
        public int goc { get; set; }
        public void tinh()
        {
            double tinhchia;
            tinhchia = Math.PI * goc / 180;
           
            string menucossin = "Nhập [1] tinh sin\nNhập [2] tinh sin\nNhập [3] tinh cotan\n";
            Console.WriteLine(menucossin);
          
            Console.WriteLine("Nhap so vao: ");
            int num;
            num = Convert.ToInt32(Console.ReadLine());
           
            if (num == 1)
            {
                Console.WriteLine("Sin cua goc {0} la {1} ", goc, Math.Sin(tinhchia));
            }
            else if (num == 2)
            {
                Console.WriteLine("Cos cua goc {0} la {1} ", goc, Math.Cos(tinhchia));
            }
            else if (num == 3)
            {
                Console.WriteLine("Costan cua goc {0} la {1} ", goc, 1 / Math.Cos(tinhchia));
            }
            else
            {
                Console.WriteLine("Ket qua cua sin lan cos ca costan la");
                Console.WriteLine("Sin cua goc {0} la {1} ", goc, Math.Sin(tinhchia));
                Console.WriteLine("Cos cua goc {0} la {1} ", goc, Math.Cos(tinhchia));
                Console.WriteLine("Costan cua goc {0} la {1} ", goc, 1 / Math.Cos(tinhchia));
            }
        }
    }
}
