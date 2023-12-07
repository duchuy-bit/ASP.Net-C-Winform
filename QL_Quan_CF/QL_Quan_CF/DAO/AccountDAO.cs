using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) return new AccountDAO();
                else return instance;
            }
            private set => instance = value;
        }

        public AccountDAO() { }

        public bool Login(string Username, string Password)
        {
            string query = "select * from account where account.UserName = \"" + Username + "\"  and account.Password = \"" + Password + "\"";

            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count > 0;
        }

    }
}
