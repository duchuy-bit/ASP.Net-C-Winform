
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Quan_CF.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int iDTable, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.IDTable = iDTable;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.DateCheckIn = (DateTime?)row["dateCheckOut"];
            this.DateCheckOut = (DateTime?)row["dateCheckIn"];
            this.IDTable = (int)row["idTable"];
            this.Status = (int)row["status"];
        }

        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int iDTable;
        private int status;

        public int ID { get => iD; set => iD = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }
        public int Status { get => status; set => status = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
    }
}
