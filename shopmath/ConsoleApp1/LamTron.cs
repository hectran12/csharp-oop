using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LamTron
    {
        public string[] solamtron { get; set; }
 
        public int gioihan { get; set; }
    
        public List<double> action()
        {
            List <double> kq = new List<double>();
            foreach (string item in solamtron)
            {
                kq.Add(Math.Round(Convert.ToDouble(item), gioihan)) ;
            }
            return kq;
        }
    }
}
