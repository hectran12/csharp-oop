using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    internal class Money
    {
        private int money { get; set; }
        public void createEnvMoney()
        {
            this.money = 0;
        }
        public void AddMoney (int moneyadd)
        {
            this.money += moneyadd;
        }
        public int GetMoney()
        {
            return this.money;
        }
        public void amMoney(int moneyam)
        {
            this.money -= moneyam;
        }
    }
}
