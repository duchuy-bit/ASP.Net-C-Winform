using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) return new BillDAO(); else return instance; }
            private set => instance = value;
        }

        public List<DisplayBill> DisplayBillWithTable(int idTable)
        {
            List<DisplayBill> tableList = new List<DisplayBill>();

            //left join billinfo on bill.id = billinfo.idBill
            //    left join tablefood on tablefood.id = bill.idTable
            //    left join food on food.id = billinfo.idFood

            string query = @"
                select bill.id as id, food.name as name, billinfo.count as count, food.price as price
                from bill
                left join billinfo on bill.id = billinfo.idBill
                left join tablefood on tablefood.id = bill.idTable
                left join food on food.id = billinfo.idFood
                where idtable = " + idTable;
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                DisplayBill table = new DisplayBill(row);
                tableList.Add(table);
            }
            return tableList;          
            
        }

    }
}
