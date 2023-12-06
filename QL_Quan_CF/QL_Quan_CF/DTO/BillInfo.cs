using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class BillInfo
    {
        private int id;
        private int idFood;
        private int idBill;
        private int count;
        private string nameFood;
        private long price;

        public BillInfo(int id, int idFood, int idBill, int count, string nameFood, long price)
        {
            this.Id = id;
            this.IdFood = idFood;
            this.IdBill = idBill;
            this.Count = count;
            this.NameFood = nameFood;
            this.Price = price;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdFood = (int)row["idFood"];
            this.IdBill = (int)row["idBill"];
            this.Count = (int)row["count"];
            this.NameFood = row["nameFood"].ToString();
            this.Price = (int)row["price"];
        }

        public int Id { get => id; set => id = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Count { get => count; set => count = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public long Price { get => price; set => price = value; }

    }
}
