using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
    internal class History
    {
        public string txt { get; set; }
        public List<string> list { get; set; } = new List<string>();
        public int rmnum { get; set; }
        public string add()
        {
           
            string date = string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            list.Add(Convert.ToString(" " + date + " " + txt));
            return "Add success history";
        }

        public void view()
        {
            int a = 0;
            foreach (string item in list)
            {
                a++;
                Console.WriteLine(a+item);
            }
        }

        public string rmcontrol()
        {
            list.RemoveAt(rmnum - 1);
            return "Remove success stt " + rmnum;
        }

        public string clear()
        {
            list.Clear();
            return "Remove success all history!";
        }
    }
}
