using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    internal class DataProvider
    {
        private string connectString = "server=localhost;database=quanlyquancf;uid=root;pwd=";

        public DataTable ExcuteQuery(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectString);

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);

            DataTable dataTable = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            adapter.Fill(dataTable);

            connection.Close();

            return dataTable;
        }
    }
}
