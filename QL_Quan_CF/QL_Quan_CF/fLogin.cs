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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát chương trình không? ","Cảnh báo", MessageBoxButtons.OKCancel)!= System.Windows.Forms.DialogResult.OK){
            //    e.Cancel = true;
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            this.Hide();
            fTableManager fTableManager = new fTableManager();
            fTableManager.ShowDialog();
            this.Close();
            //this.Show();
        }
    }
}
