using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    internal class AddCart
    {
        private string name { get; set; }
        private int id { get; set; }
        private int cost { get; set; }
        private int amount { get; set; }
        private int idcart { get; set; }    
      //  private string[] infoment { get; set; } = new string[2];
        public Dictionary<int,List<string>> data = new Dictionary<int,List<string>>();
       // private List<string> history { get; set; } = new List<string>();
        public void aCart (string name, int cost, int amount)
        {
            this.name = name;
            this.cost = cost;
            this.amount = amount;
            List<string> item = new List<string> ();
            item.Add (this.name);
            item.Add (Convert.ToString(this.cost));
            item.Add (Convert.ToString(this.amount));
            bool checkadd = newID(item);
            if(checkadd == true)
            {
                Console.Write("Them don hang thanh cong, co id la: "+this.id);
                Thread.Sleep(2000);
            } else
            {
                Console.Write("Them don hang khong thanh cong!");
                Thread.Sleep(1000);
            }
        }




        public bool viewCart()
        {
            int sttdonhang = 0;
            if (data.Count == 0)
            {
                return false;
            } else
            {
                Console.Write("Khong co mon hang nao trong kho ca\n");
                foreach (KeyValuePair<int, List<string>> item in data)
                {
                    sttdonhang++;
                    Console.WriteLine("Nhap {0} neu ban muon mua mon hang nay", sttdonhang);
                    Console.Write("ID Mon hang: " + item.Key + "\n");
                    string[] ten = { "Name", "Cost", "Amount" };
                    int samount = 0;
                    foreach (string item2 in item.Value)
                    {
                        if (ten[samount] == "Amount")
                        {
                            if (item2 == "0")
                            {
                                Console.WriteLine("Amount : Het hang roi");
                            } else
                            {
                                Console.WriteLine(ten[samount] + " : " + item2);
                            }
                        }
                        else
                        {
                            Console.WriteLine(ten[samount] + " : " + item2);
                        }
                        samount++;
                    }
                }
                return true;
            }

        }

        public void amCount(int sl)
        {
            int tru;
            tru = Convert.ToInt32(data[this.idcart][2]) - sl;
            data[this.idcart][2] = Convert.ToString(tru);
        }

        public List<string> GetItem (int id)
        {
            int sllgoc = 0;
            List<string> kq = new List<string>();
            foreach (KeyValuePair<int,List<string>> item in data)
            {
                sllgoc++;
                if(sllgoc == id)
                {
                    kq = item.Value;
                    this.idcart = item.Key;
                    break;
                } 
            }
            return kq;
        }



        public void EditCart (int id)
        {
            List<string> itemne = GetItem (id);
            string[] ten = { "Name", "Cost", "Amount","rm" };
            Console.WriteLine(ten[0] + " : " + itemne[0] + " || " + ten[1] + " : " + itemne[1] + " || " + ten[2] + " : " + itemne[2]);
            Console.Write("nhap rm de xoa: ");
            string nhapedit = Convert.ToString(Console.ReadLine());
             if (nhapedit == ten[3])
            {
                rmCart();
                Console.Write("Xoa thanh cong");
                Thread.Sleep(1000);
            }
            
        }


        public void rmCart ()
        {
            data.Remove(this.idcart);
        }

        public bool newID(List<string> item)
        {
            Random rand = new Random();
            while (true)
            {
                int r = rand.Next(9999);
                if (this.data.ContainsKey(r) == false)
                {
                    this.data.Add(r, item);
                    this.id = r;
                    return true;
                    break;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
