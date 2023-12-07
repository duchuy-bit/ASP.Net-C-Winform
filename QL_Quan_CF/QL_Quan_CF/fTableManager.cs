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

        Food FoodSelected;

        private List<DisplayBill> billDefaults = new List<DisplayBill>();

        int idTable;
        int idBill = -1;
        long sumBill = 0;
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
            flpTable.Controls.Clear();
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
            idTable = tableId;

            ShowBill(tableId);

            loadTableEmpty(tableId);

        }

        void loadTableEmpty(int idTableOld)
        {
            cbSwitchTable.Items.Clear();
            List<Table> tables = TableDAO.Instance.LoadTableEmpty(idTableOld);

            foreach (Table table in tables)
            {
                cbSwitchTable.Items.Add(table.Name.ToString());
            }
        }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();

            long sum = 0;

            List<DisplayBill> bills = new List<DisplayBill>();


            bills = BillDAO.Instance.DisplayBillWithTable(id);
            billDefaults = bills;

            int i = 0;
            if (bills.Count != 0 && bills[0]?.ID != null) idBill = bills[0].ID;
            else idBill = -1;

            if (bills.Count <= 0) {
                tbSum.Text = "0";
                sumBill = 0;
                return;
            }

            foreach (DisplayBill bill in bills)
            {
                i++;
                ListViewItem item = new ListViewItem(i.ToString());

                item.SubItems.Add(bill.NameFood.ToString());
                item.SubItems.Add(bill.Price.ToString());
                item.SubItems.Add(bill.Count.ToString());
                item.SubItems.Add(((int)(bill.Price * bill.Count)).ToString());
                lvBill.Items.Add(item);
                sum += ((int)(bill.Price * bill.Count));
            }

            sumBill = sum;
            tbSum.Tag = sum;
            tbSum.Text = string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("vi-VI"),
                "{0:#,##0.00}",
                double.Parse(sum.ToString()));
            //tbSum.Text = sum.ToString(); 
        }

        void checkOut(int idBill, int idtable)
        {
            BillDAO.Instance.checkOut(idBill, idtable);
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

            loadComboBoxFood(foodCategory.ID);
            //cbNameFood.Tag = food;
        }

        void loadComboBoxFood(int idCategory)
        {
            List<Food> food = FoodDAO.Instance.GetFood(idCategory);

            cbNameFood.DataSource = food;
            cbNameFood.DisplayMember = "Name";
        }

        private void cbNameFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null) {
                Food food = comboBox.SelectedItem as Food;
                Console.WriteLine(food.IDCategory);

                FoodSelected = new Food(food.ID, food.Name, food.Price, food.IDCategory);
                
            }


            //int index = cbNameFood.SelectedIndex;
            //Console.WriteLine("Selected: "+index);
            //Console.WriteLine("Item Selected: " + cbNameFood.Items[index]);
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Console.WriteLine("id Table: " + idTable);
            Console.WriteLine("id Bill: " + idBill);
            Console.WriteLine("id Food: " + FoodSelected.Name + " " + FoodSelected.ID);
            Console.WriteLine("Count: " + numberAmount.Value);
            if (idBill > 0)
            {
                BillDAO.Instance.addFoodToBill(idBill, idTable, FoodSelected.ID, (int)numberAmount.Value);
            }
            else
            {
                BillDAO.Instance.addNewBill(idBill, idTable, FoodSelected.ID, (int)numberAmount.Value);
            }

            loadTable();
            ShowBill(idTable);
        }

        #endregion

        private void cbNameFood_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void lvBill_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                // Reresh numberAmount;
                numberAmount.Value = billDefaults[e.ItemIndex].Count;


                // refresh ComboBox category , ComboBox Food
                cbCategoryFood.Text = billDefaults[e.ItemIndex].NameCategory;
                loadComboBoxFood(billDefaults[e.ItemIndex].IdCategory);
                cbNameFood.Text = billDefaults[e.ItemIndex].NameFood;

                //ListViewItem listViewItem = sender as ListViewItem;

                //Console.WriteLine("OKKOOKOK");
                //Console.WriteLine(e.Item);
                //Console.WriteLine(e.ItemIndex);
                //Console.WriteLine(billDefaults[e.ItemIndex].NameFood);


                //DisplayBill displaybill = listViewItem.Selected.La as DisplayBill;
            }
        }

        private void bthSale_Click(object sender, EventArgs e)
        {
            long sumPayment = 0;

            //Console.WriteLine( );

            //Console.WriteLine((tbSum as TextBox).Tag);

            //int tam = (int)(tbSum as TextBox).Tag;
                
            //int tam = int.Parse(tbSum.Tag);

            sumPayment = sumBill * (100 - (int)nudSale.Value) ;

            tbSum.Text =  string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("vi-VI"),
                "{0:#,##0.00}",
                double.Parse(sumPayment.ToString()));
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (idBill > 0)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán không? ", "Cảnh báo", 
                    MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Console.WriteLine("THanh toans");
                    checkOut(idBill, idTable);
                }

                loadTable();
                ShowBill(idTable);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn để thanh toán ");
            }

        }
    }
}

