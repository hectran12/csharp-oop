using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    internal class History
    {
        private List<string> history { get; set; } = new List<string>();
        public void add (string them)
        {
            string date = string.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now);
            this.history.Add (date+them);
        }
        public void remove (int id)
        {
            id--;
            this.history.RemoveAt(id);
        }
        public void rmall()
        {
            this.history.Clear();
        }
        public void view()
        {
            int stt = 0;
            if(history.Count == 0)
            {
                Console.WriteLine("Khong co chi tieu");
            } else
            {
                foreach (string them in this.history)
                {
                    stt++;
                    Console.WriteLine("[" + stt + "] " + them);
                }
            }
     
        }
    }
}
