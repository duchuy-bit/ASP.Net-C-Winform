using MySql.Data.MySqlClient;
using QL_Quan_CF.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Quan_CF
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            loadAdminList();
        }



        void loadAdminList()
        {
            //string connectString = "datasource=localhost;port=8080;username=root;password=;database=quanlyquancf;";
            string connectString = "server=localhost;database=quanlyquancf;uid=root;pwd=";

            //string connectString = @"datasource=127.0.0.1;port=8080;Database=quanlyquancf;Uid=root;Pwd=;";
            //string connectString = @"Data Source=localhost;Initial Catalog=quanlyquancf;Uid=root;Pwd=;Integrated Security=True";

            string query = "Select * from account";

            DataProvider dataProvider = new DataProvider();

            dgvAccount.DataSource = dataProvider.ExcuteQuery(query);

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
