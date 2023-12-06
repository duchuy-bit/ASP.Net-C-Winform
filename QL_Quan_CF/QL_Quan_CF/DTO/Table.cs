using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class Table
    {
        public Table(int id, string name, string status) {
            this.iD = id;
            this.Name = name;
            this.Status = status;
        }

        public Table (DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = (string)row["name"];
            this.Status = (string)row["status"];
        }

        private string name;
        private string status;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }

        
    }
}
