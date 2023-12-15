using QL_Quan_CF.DAO;
using QL_Quan_CF.DTO;
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

            if (Login(username, password).Count > 0)
            {
                Account accountLogin = Login(username, password)[0];

                this.Hide();
                fTableManager fTableManager = new fTableManager(accountLogin);
                fTableManager.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
            }
        }

        private List<Account> Login(string username, string password)
        {
            List<Account> accounts = AccountDAO.Instance.Login(username, password);


            return accounts;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
