using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ptrinhbac1
    {
        public double a { get; set; }
        public double b { get; set; }
        public string tinh()
        {
            if (a == 0 && b == 0) { return "Phương trình vô số nghiệm"; }
            else if (a == 0 && b != 0) { return "Phương trình vô nghiệm"; };
            return "Kết quả của x là: " + (-b / a);
        }

    }
}
