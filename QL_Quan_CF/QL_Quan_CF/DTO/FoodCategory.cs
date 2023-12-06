using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class FoodCategory
    {
        private int iD;
        private string name;

        public FoodCategory(int iD, string name)
        {
            this.ID = iD;
            this.Name = name;
        }

        public FoodCategory(DataRow row) {
            this.ID = (int)row["iD"];
            this.Name = row["name"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
