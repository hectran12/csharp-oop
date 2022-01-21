using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinhtoan1
{
    internal class Sum
    {
        public int sum (params int[] arr)
        {
            int s = 0;
            foreach (int x in arr)
            {
                s += x;
            }
            return s;
        }
    }
}
