using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    internal class Account
    {

        private int iD;
        private string displayName;
        private string userName;
        private string password;
        private int type;


        public Account(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.DisplayName = row["displayName"].ToString();
            this.UserName = row["userName"].ToString();
            this.Password = row["password"].ToString();
            this.Type = (int)row["type"];
        }

        public Account(int iD, string displayName, string userName, string password, int type)
        {
            this.ID = iD;
            this.DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            this.UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            this.Password = password ?? throw new ArgumentNullException(nameof(password));
            this.Type = type;
        }



        public int ID { get => iD; set => iD = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}
