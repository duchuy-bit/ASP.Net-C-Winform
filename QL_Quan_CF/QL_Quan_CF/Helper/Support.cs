using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.Helper
{
    public class Support
    {
        public string convertToString(object obj)
        {
            string tam = "";

            foreach (var item in obj.GetType().GetProperties())
            {
                tam += item.ToString() + "  ";
            }

            return tam;
        }
    }
}
