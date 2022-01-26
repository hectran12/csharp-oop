using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LuyThua
    {
        public int A { get; set; }
        public int B { get; set; }

        public double tinh()
        {
            return Math.Pow(A, B);
        }
    }
}
