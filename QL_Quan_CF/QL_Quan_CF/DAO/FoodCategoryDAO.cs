using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    internal class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;

        internal static FoodCategoryDAO Instance {
            get { if (instance == null) return new FoodCategoryDAO(); else return instance; }
            private set => instance = value; 
        }

        public List<FoodCategory> GetFoodCategories() {
            List<FoodCategory> foodCategories = new List<FoodCategory>();

            string query = "Select * from FoodCategory";
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                FoodCategory table = new FoodCategory(row);
                foodCategories.Add(table);
            }

            return foodCategories;

        }
    }
}
