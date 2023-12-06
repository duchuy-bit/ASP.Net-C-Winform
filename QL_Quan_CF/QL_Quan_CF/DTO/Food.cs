using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class Food
    {
        private int iD;
        private string name;
        private double price;
        private int iDCategory;

        public Food(int iD, string name, double price, int iDCategory)
        {
            this.ID = iD;
            this.Name = name;
            this.Price = price;
            this.IDCategory = iDCategory;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.IDCategory = (int)row["iDCategory"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
    }
}
