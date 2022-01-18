using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace oop
{
    class Program
    {
        static void Main (string[] args)
        {
            Kieudulieu kieudulieu = new Kieudulieu();
            Console.WriteLine(kieudulieu);
            kieudulieu.Ten = "Trong Hoa Ne";
            kieudulieu.Code = 2000;
            Console.WriteLine(kieudulieu);
            Kieudulieu ki = new Kieudulieu(1333, "Teof nef ahihi");
            Console.WriteLine(ki);
        }
    }
}
    
    
    
    
