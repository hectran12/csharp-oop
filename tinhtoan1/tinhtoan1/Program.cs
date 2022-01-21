using System;
using System.Text;
using tinhtoan1;
namespace tinhtoan
{
    class Program
    {
        static void Main (string[] args)
        {

          //  Sum tinh = new Sum();
          //  Console.Write(tinh.sum(1, 2, 3, 4, 5, 6, 6, 7, 8, 8, 9, 11));

            List<dskh> dskhs = new List<dskh>();
            dskh lmao = new dskh();
            lmao.phone = "0909387863";
            lmao.ten = "Hoa dep trai";
            lmao.age = 19;
            dskhs.Add(lmao);
            dskhs.Add(new dskh()
            {
                phone = "00000",
                ten = "Trong hoa",
                age = 19
            });
            foreach (dskh l in dskhs)
            {
                Console.WriteLine(l.phone);
                Console.WriteLine(l.ten);
                Console.WriteLine(l.age);
            }
        }
    }
}