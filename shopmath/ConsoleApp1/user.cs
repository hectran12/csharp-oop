using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class user : Money
    {
        private string name_user { get; set; }

        public user(string name)
        {
            name_user = name;
        }
        
        public string getName()
        {
            return name_user;
        }

        public int blance (string type,int num)
        {
            switch (type)
            {
                case "add":
                    AddMoney(num);
                    return num;
                    break;
                case "tract":
                    TractMoney(num);
                    return num;
                    break;
                case "set":
                    setEnvMoney();
                    return 0;
                    break;
                default:
                    return 1;
                    break;
            }
        }
        public int blance()
        {
            return GetMoney();
        }
    }
}
