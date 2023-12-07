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
        private int idCategory;
        private string nameCategory;

        public DisplayBill(int iD, int count, string nameFood, int price, int idCategory, string nameCategory)
        {
            this.ID = iD;
            this.Count = count;
            this.NameFood = nameFood;
            this.Price = price;
            this.IdCategory = idCategory;
            this.NameCategory = nameCategory;
        }

        public DisplayBill(DataRow row)
        {
            this.ID = (int)row["iD"];

            var rowCount = row["count"];
            if (rowCount != null) this.Count = (int)rowCount;
            this.NameFood = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (int)row["price"];
            this.NameCategory = row["nameCategory"]?.ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public int Count { get => count; set => count = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Price { get => price; set => price = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
    }
}
