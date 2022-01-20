using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    internal class TaiKhoan
    {


        private string usr { get; set; }
        private string pwd { get; set; }
        private bool checkz {get; set; }
        public void setAcc(string user, string password)
        {
            this.usr = user;
            this.pwd = password;
        }
        public void checklogin()
        {
            string error = "";
            string success = "+";
            bool checkpsw = checkcount(this.pwd);
            bool checkuser = checkcount(this.usr);
            if(checkpsw == true)
            {
                success += "Password hop le!+";
            } else
            {
                error +="[No] ";
                error += "Password khong hop le, tren 8 ki tu\n";
            }
            if(checkuser == true)
            {
                success += "Username hop le+";
            } else
            {
                error += "[No] ";
                error += "User khong hop le, tren 8 ki tu\n";
            }

            string[] mang = success.Split('+');
            int am = 0;
            string log = "";
            foreach (string s in mang)
            {
                if(s != "")
                {
                    am++;
                    log +="[Yes] " + s + "\n";
                }
            }
            if(am == 2)
            {
                Console.Write(log);
                outputlog(1);
            } else
            {
                Console.Write(log);
                Console.Write(error);
                outputlog(2);
            }
            
        }
        public void outputlog (int st)
        {
            if (st == 1)
            {
                this.checkz = true;
            }
            else
            {
                this.checkz = false;
            }
        }
        public bool GetStatus()
        {
            return this.checkz;
        }
        public string getUser()
        {
            return this.usr;
        }
        public string getPsw()
        {
            return this.pwd;
        }
        public bool checkcount(string txt)
        {
            if(txt.ToCharArray().Length > 8)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
