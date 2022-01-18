using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banhang
{
    internal class cat
    {
        #region gat
        private string catName { get; set; }
        private string catType { get; set; }
        private int cost { get; set; }
        private int amount { get; set; }
        private int so { get; set; }
        #endregion
        #region prote

        public void setItem ()
        {
            this.cost = 0;
            this.amount = 0;
            this.catName = "Null";
            this.catType = "Null";
        }
        public void setItem (string cname, string ctype, int c,int sl, int so)
        {
            this.catName = cname;
            this.catType = ctype;
            this.cost = c;
            this.amount = sl;
            this.so = so;
        }
        #endregion
        #region output
        public Dictionary<string, string> GetItem()
        {
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic.Add("Name ["+this.so+"]",this.catName);
            dic.Add("Type ["+this.so+"]",this.catType);
            dic.Add("Amount ["+this.so+"]",Convert.ToString(this.amount));
            dic.Add("Cost [" + this.so + "]", Convert.ToString(this.cost));
            return dic;
        }
        #endregion
    }
}
