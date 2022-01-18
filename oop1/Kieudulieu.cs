using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Kieudulieu
    {
        #region khai bien kieu du lieu
        private string ten;
        private int code;
        #endregion
        #region cac constructor
        public Kieudulieu()
        {
            this.ten = "tRONG hOA";
            this.code = 1999;
        }
        public Kieudulieu (int codex, string tenz)
        {
            this.ten = tenz;
            this.code = codex;
        }
        #endregion
        #region cac properties
        public int Code
        {
            get { return code; } // read
            set { code = value; } // write
        }
        public string Ten
        {
            get { return ten; } // read
               
            set { ten = value; } // write

        }
        #endregion
        #region cac phuon thuc
        public override string ToString()
        {
            return this.code + "\t" + this.ten;
        }
        #endregion
    }
}
