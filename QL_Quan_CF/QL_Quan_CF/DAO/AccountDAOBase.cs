using QL_Quan_CF.DTO;
using System.Collections.Generic;
using System.Data;

namespace QL_Quan_CF.DAO
{
    internal class AccountDAOBase
    {

        public List<Account> Login(string Username, string Password)
        {
            List<Account> accounts = new List<Account>();
            string query = "select * from account where account.UserName = \"" + Username + "\"  and account.Password = \"" + Password + "\"";

            DataTable result = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                Account account = new Account(row);
                accounts.Add(account);
            }

            return accounts;
        }
    }
}