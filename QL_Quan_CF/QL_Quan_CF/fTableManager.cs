using Org.BouncyCastle.Utilities;
using QL_Quan_CF.DAO;
using QL_Quan_CF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Quan_CF
{

    
    public partial class fTableManager : Form
    {

        Food FoodSelected ;

        int idTam;
        public fTableManager()
        {
            InitializeComponent();


            loadTable();

            loadComboBoxCateoryAndFood();

        }

        #region Method
        void loadComboBoxCateoryAndFood()
        {
            cbCategoryFood.Items.Clear();
            List<FoodCategory> foodCategories = FoodCategoryDAO.Instance.GetFoodCategories();

            cbCategoryFood.DataSource = foodCategories;
            cbCategoryFood.DisplayMember = "Name";
        }

        void loadTable()
        {
            List<Table> tableList = TableDAO.Instance.loadTableList();
            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Tag = table;
                btn.Click += this.clickTable;
                btn.BackColor = table.Status == "Trống" ? Color.Aqua : Color.LightPink;

                flpTable.Controls.Add(btn);
            }

        }

        void clickTable(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).ID;
            //objects = (sender as Button).Tag as Table;
            idTam = tableId;

            ShowBill(tableId);

            loadTableEmpty(tableId);

        }

        void loadTableEmpty(int idTableOld)
        {
            cbSwitchTable.Items.Clear();
            List<Table> tables = TableDAO.Instance.LoadTableEmpty(idTableOld);

            foreach (Table table in tables) { 
                cbSwitchTable.Items.Add(table.Name.ToString());
            }
        }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();

            List<DisplayBill> bills = new List<DisplayBill>();

            bills = BillDAO.Instance.DisplayBillWithTable(id);

            int i = 0;

            foreach (DisplayBill bill in bills)
            {
                i++;
                ListViewItem item = new ListViewItem(i.ToString());

                item.SubItems.Add(bill.NameFood.ToString());
                item.SubItems.Add(bill.Price.ToString());
                item.SubItems.Add(bill.Count.ToString());
                item.SubItems.Add(((int)(bill.Price * bill.Count)).ToString());
                lvBill.Items.Add(item);
            }
        }

        #endregion

        #region Events
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile();
            fAccountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
        }

        private void cbCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            ComboBox comboBox = sender as ComboBox;              
            FoodCategory foodCategory = comboBox.SelectedItem as FoodCategory;

            Console.WriteLine(foodCategory.Name);

            List<Food> food = FoodDAO.Instance.GetFood(foodCategory.ID);

            cbNameFood.DataSource = food;
            cbNameFood.DisplayMember = "Name";
            //cbNameFood.Tag = food;
        }

        private void cbNameFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Food food = comboBox.SelectedItem as Food;

            Console.WriteLine(food.IDCategory);

            FoodSelected =  new Food(food.ID, food.Name, food.Price, food.IDCategory);


            //int index = cbNameFood.SelectedIndex;
            //Console.WriteLine("Selected: "+index);
            //Console.WriteLine("Item Selected: " + cbNameFood.Items[index]);
        }
         

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Console.WriteLine("id ban: " + idTam);

            //Food foodAdd = cbNameFood.SelectedItem  as Food;

            //int tam = (cbNameFood.SelectedItem as Food).ID;

            //Console.WriteLine("Food Add: ", (cbNameFood.SelectedItem));

        }




        #endregion

        private void cbNameFood_SelectedValueChanged(object sender, EventArgs e)
        {
            //int id = ()
            //Console.WriteLine("Selected: " + cbNameFood.Text);

            //Console.WriteLine("ok "+ (sender as ComboBox));

            //Console.WriteLine(((sender as ComboBox).Tag as Food).ToString());
        }

        
    }
}
