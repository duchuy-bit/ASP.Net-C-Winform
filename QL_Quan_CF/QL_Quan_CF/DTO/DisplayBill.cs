using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class DisplayBill
    {
        private int iD;
        private int count;
        private string nameFood;
        private int price;

        public DisplayBill(int iD, int count, string nameFood, int price)
        {
            this.ID = iD;
            this.Count = count;
            this.NameFood = nameFood;
            this.Price = price;
        }

        public DisplayBill(DataRow row) {
            this.ID = (int)row["iD"];
            this.Count = (int)row["count"];
            this.NameFood = row["name"].ToString();
            this.Price = (int)row["price"];
        }

        public int ID { get => iD; set => iD = value; }
        public int Count { get => count; set => count = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Price { get => price; set => price = value; }
    }
}
