using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    internal class FoodDAO
    {
        private static FoodDAO instance;

        internal static FoodDAO Instance { 
            get {
                if (instance == null) return new FoodDAO();
                else return instance;
            } 
            set => instance = value; 
        }

        public List<Food> GetFood(int idFoodCategory) {

            List<Food> foodCategoryDAOs = new List<Food>();
            string query = "Select * From Food where idCategory = " + idFoodCategory.ToString();

            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Food table = new Food(row);
                foodCategoryDAOs.Add(table);
            }

            return foodCategoryDAOs;
        }
    }
}
