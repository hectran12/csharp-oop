using System;
using System.Text;
namespace banhang
{
    class Program
    {
        static void Main (string[] args)
        {
            cat cat = new cat();
            Console.Write("Nhap so luong don hang muon dua vao kho: ");
            int am = Convert.ToInt32(Console.ReadLine());
            Dictionary<string,string> kho = new Dictionary<string, string> ();
            int az = 0;
            for(int i = 0; i < am; i++)
            {
                az++;
                Console.Write("Nhap ten don hang: ");
                string catname = Convert.ToString(Console.ReadLine());
                Console.Write("Nhap the loai don: ");
                string type = Convert.ToString(Console.ReadLine());
                Console.Write("Nhap so luong don: ");
                int amz = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhap gia thanh sp: ");
                int giathanh = Convert.ToInt32(Console.ReadLine());
                cat.setItem(catname, type, amz, giathanh, az);
                Dictionary<string, string> gop = cat.GetItem();
                kho = gopdic(kho, gop, 1);
            }
            foreach (KeyValuePair<string, string> k in kho)
            {
                Console.WriteLine(k.Key+" : "+k.Value);
            }
        }
        static Dictionary<string, string> gopdic (Dictionary<string, string> a1, Dictionary<string, string> a2,int type)
        {
            if (type == 1)
            {
                foreach (KeyValuePair<string, string> kv in a2)
                {
                    a1.Add(kv.Key, kv.Value);
                }
                return a1;
            } else
            {
                foreach (KeyValuePair<String, string> kv in a1)
                {
                    a2.Add(kv.Key, kv.Value);
                }
                return a2;
            }
        }
    }
}