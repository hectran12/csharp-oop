using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Money
    {
        private int money { get; set; }
        public string setEnvMoney()
        {
            money = 0;
            return "Create success money env!";
        }
        public string AddMoney(int add)
        {
            money += add;
            return "Success add money!";
        }

        public string TractMoney (int tract)
        {
            money -= tract;
            return "Success tract money!";
        }

        public int GetMoney()
        {
            return money;
        }
    }
}
