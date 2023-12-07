using QL_Quan_CF.DTO;
using QL_Quan_CF.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Console.WriteLine("Display Table ");
            List<DisplayBill> tableList = new List<DisplayBill>();

            //left join billinfo on bill.id = billinfo.idBill
            //    left join tablefood on tablefood.id = bill.idTable
            //    left join food on food.id = billinfo.idFood

            string query = @"
                select bill.id as id, foodcategory.name as nameCategory, food.idCategory as idCategory, food.name as name, billinfo.count as count, food.price as price
                from bill
                inner join billinfo on bill.id = billinfo.idBill
                inner join tablefood on tablefood.id = bill.idTable
                inner join food on food.id = billinfo.idFood
                inner join foodcategory on foodcategory.id = food.idCategory
                where bill.status = 0 and idtable = " + idTable;
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            if (dataTable.Rows.Count <= 0)
            {
                return new List<DisplayBill>();
            }

            foreach (DataRow row in dataTable.Rows)
            {
                //Console.WriteLine(row["id"]);
                DisplayBill table = new DisplayBill(row);
                tableList.Add(table);
            }
            return tableList;
        }

        public void checkOut(int idBill, int idTable)
        {
            string queryUpdateBill = "update bill set status = 1 where bill.id = " + idBill;
            DataProvider.Instance.ExcuteNonQuery(queryUpdateBill);

            string queryUpdateTable = "update tablefood set status = \"Trống\" where tablefood.id = " + idTable;
            DataProvider.Instance.ExcuteNonQuery(queryUpdateTable);
        }
        public void addFoodToBill(int idBill, int idTable, int idFood, int count)
        {
            Console.WriteLine("addFoodToBill");
            string query = @"select * from  billinfo 
                where billinfo.idBill = " + idBill + @" and billinfo.idFood = " + idFood + @"; ";
            DataTable foodInDB = DataProvider.Instance.ExcuteQuery(query);

            if (foodInDB.Rows.Count > 0)
            {
                Console.WriteLine("foodInDB.Rows.Count > 0");
                int countInDB = (int)foodInDB.Rows[0]["count"];
                int idBillInfo = (int)foodInDB.Rows[0]["id"];
                if (countInDB + count > 0)
                {
                    Console.WriteLine("queryUpdateFoodInBill");
                    string queryUpdateFoodInBill =
                        @"UPDATE billinfo 
			            SET count = " + (countInDB + count) + @"
			            WHERE billinfo.idBill = " + idBill + @" and billinfo.id = " + idBillInfo;
                    DataProvider.Instance.ExcuteNonQuery(queryUpdateFoodInBill);
                }
                else
                {
                    Console.WriteLine("queryDeleteBillInfo , queryCheckBillEmpty");
                    string queryDeleteBillInfo = @"DELETE FROM billinfo WHERE billinfo.id = " + idBillInfo;
                    DataProvider.Instance.ExcuteNonQuery(queryDeleteBillInfo);

                    string queryCheckBillEmpty =
                        @"Select * from bill inner join billinfo on  bill.id = billinfo.idBill 
                        where bill.id = " + idBill;
                    DataTable countRowBill = DataProvider.Instance.ExcuteQuery(queryCheckBillEmpty);

                    //Console.WriteLine(countRowBill.Rows[0]["counter"]);

                    //int tam = (int)countRowBill.Rows[0]["counter"];

                    if (((int)countRowBill.Rows.Count) == 0)
                    {
                        Console.WriteLine(" queryDeleteBill ");
                        string queryDeleteBill =
                            @"DELETE FROM bill WHERE bill.id = " + idBill + @";
                             ";
                        DataProvider.Instance.ExcuteNonQuery(queryDeleteBill);

                        string queryUpdateTable =
                            @"update tablefood set status = ""Trống""  where id = " + idTable + @"; ";
                        DataProvider.Instance.ExcuteNonQuery(queryUpdateTable);

                        Console.WriteLine(" UPDATE TABLE SUCCESS");
                    }
                }
            }
            else
            {
                Console.WriteLine("Khoong tim thay mon an trong bill");
                if (count > 0)
                {
                    Console.WriteLine("so luong mon an > 0 => them vao bill");
                    string queryInsertNewFoodToBill =
                        @"INSERT INTO billinfo 
			            VALUES (null, " + idBill + @", " + idFood + @", " + count + @");";
                    DataProvider.Instance.ExcuteNonQuery(queryInsertNewFoodToBill);
                }
            }


            //string query = "call AddFoodToBill( @idBill , @idTable , @idFood , @count )";

            //DataTable dataTable = DataProvider.Instance.ExcuteQuery(
            //    query,
            //    new object[]
            //    {
            //        idBill, idTable, idFood, count
            //    }
            //);
        }
        public void addNewBill(int idBill, int idTable, int idFood, int count)
        {
            if (count > 0)
            {
                string query = @"
                    START TRANSACTION;
                        insert into bill  Values (null, NOW(), null, " + idTable + @", 0);
                        insert  into billinfo  Values (null, LAST_INSERT_ID() , " + idFood + @", " + count + @");
                        update tablefood set status = ""Có người""  where id = " + idTable + @";
                    COMMIT; ";

                DataProvider.Instance.ExcuteNonQuery(query);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lại số lượng món ");
            }

            //string query = "call AddNewBill( @idBill , @idTable , @idFood , @count )";

            //DataTable dataTable = DataProvider.Instance.ExcuteQuery(
            //    query,
            //    new object[]
            //    {
            //        idBill, idTable, idFood, count
            //    }
            //);
        }


    }
}
