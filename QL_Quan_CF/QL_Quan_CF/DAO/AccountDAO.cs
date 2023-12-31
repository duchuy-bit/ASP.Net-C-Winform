﻿using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance
        {
            get
            {
                if (instance == null) return new AccountDAO();
                else return instance;
            }
            private set => instance = value;
        }

        public AccountDAO() { }

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
