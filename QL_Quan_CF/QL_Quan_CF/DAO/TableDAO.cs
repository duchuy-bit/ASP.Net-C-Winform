using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        // Size Table
        public static int TableWidth = 80;
        public static int TableHeight = 80;
        // end Size Table

        public static TableDAO Instance
        {
            get
            {
                if (instance == null) return new TableDAO(); else return instance;
            }
            set => instance = value;
        }

        private TableDAO() { }

        public List<Table> loadTableList()
        {
            List<Table> tableList = new List<Table>();

            string query = "Select * from tablefood";
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Table table = new Table(row);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> LoadTableEmpty(int idTableOld)
        {
            List<Table> tableList = new List<Table>();

            string query = "Select * from tablefood where id!= " + idTableOld + " and status = \"Trống\" ";
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Table table = new Table(row);
                tableList.Add(table);
            }
            return tableList;
        }


    }
}
