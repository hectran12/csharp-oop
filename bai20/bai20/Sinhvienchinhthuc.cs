using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai20
{
    internal class Sinhvienchinhthuc:Sinhvien
    {
        public new void hocphi()
        {
            base.hocphi();
            Console.WriteLine("Day la phupng thuc tinh hoc phi cua sinhvienchinhthuc");
        }
    }
}
