using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    internal class YouItem
    {
        private string name { get; set; }
        private string description { get; set; }
        private string amount { get; set; }
        private string cost { get; set; }
        private Dictionary<string, List<string>>tags { get; set; } = new Dictionary<string,List<string>>();
        private List<string> items { get; set; } = new List<string>();
        public void AddItem(string name, string desc, string am, string cost)
        {
            this.name = name;
            this.description = desc;
            this.amount = am;
            this.cost = cost;
            items.Add(this.name);
            items.Add(this.description);
            items.Add(this.amount);
            items.Add(this.cost);
            genID();
        }
        public void ItemRM (string id)
        {
            this.tags.Remove(id);
        }
        public int resellItem(string resell, string amban)
        {
            int getcost = Convert.ToInt32(tags[resell][3]) / 2;
            if (Convert.ToInt32(amban) < Convert.ToInt32(tags[resell][2]) || Convert.ToInt32(amban) == Convert.ToInt32(tags[resell][2]))
            {
                int tiencong = getcost * Convert.ToInt32(amban);
               // AddMoney(tiencong);
                int amconlai = Convert.ToInt32(tags[resell][2]) - Convert.ToInt32(amban);
                tags[resell][2] = Convert.ToString(amconlai);
                List<string> items = new List<string>();
                items.Add(Convert.ToString(tiencong));
                return tiencong;
            } else
            {
                Console.Write("Ban khong du so luong de resell!");
                Thread.Sleep(1000);
                return 0;
            }
        }
        public void viewall()
        {
            if(tags.Count == 0)
            {
                Console.WriteLine("Khong co vat pham nao o day!, enter de back ve menu");
            } else
            {
                foreach (KeyValuePair<string, List<string>> s in tags)
                {
                    string[] tagss = { "Ten Don Hang", "Mo ta", "So Luong", "Gia resell" };
                    int a = 0;
                    Console.Write("Name-resell : " + s.Key + "\n");
                    foreach (string sz in s.Value)
                    {
                        if (a == 3)
                        {
                            double kqtinh = Convert.ToInt32(sz) / 2;
                            Console.WriteLine(tagss[a] + " : " + kqtinh);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(tagss[a] + " : " + sz);
                        }

                        a++;
                    }
                }
            }
 
        }
        public void genID()
        {
            if (tags.ContainsKey(this.name))
            {
                if (tags[this.name][3] != this.cost)
                {
                    Random rand = new Random();
                    int iditem = rand.Next(999);
                    tags.Add(this.name+iditem, this.items);
                }
                else
                {
                    int kqtinh = Convert.ToInt32(tags[this.name][2]) + Convert.ToInt32(this.amount);
                    tags[this.name][2] = Convert.ToString(kqtinh);
                }
            } else
            {
                tags.Add(this.name, this.items);
            }
            
        }
    }
}
