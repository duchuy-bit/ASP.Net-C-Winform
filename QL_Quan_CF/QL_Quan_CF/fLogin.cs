using QL_Quan_CF.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Quan_CF
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát chương trình không? ","Cảnh báo", MessageBoxButtons.OKCancel)!= System.Windows.Forms.DialogResult.OK){
            //    e.Cancel = true;
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassword.Text;

            if (Login(username, password))
            {
                this.Hide();
                fTableManager fTableManager = new fTableManager();
                fTableManager.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
            }
        }

        private bool Login(string username, string password)
        {
            bool result = AccountDAO.Instance.Login(username, password);

            return result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
