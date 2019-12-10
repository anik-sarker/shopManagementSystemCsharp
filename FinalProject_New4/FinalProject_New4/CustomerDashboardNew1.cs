using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace FinalProject_New4
{
    public partial class CustomerDashboardNew1 : Form
    {
        string a;
        string name;
        double price;
        double vat;
        public CustomerDashboardNew1()
        {
            InitializeComponent();
        }
        public CustomerDashboardNew1(int id) {
            InitializeComponent();
            a = id.ToString();
            database da = new database();
            name= da.getCustomerName(id);
            textBox4.Text = a;
            textBox5.Text = name;
        }

        private void CustomerDashboardNew1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopManagementSystemDataSet.productListTable' table. You can move, or remove it, as needed.
            this.productListTableTableAdapter.Fill(this.shopManagementSystemDataSet.productListTable);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            database da = new database();
            productListTableDataGridView.DataSource = da.getDataFromTable("productListTable");
        }

        private void productListTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productListTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.shopManagementSystemDataSet);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void productListTableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = productListTableDataGridView.Rows[index];

            int i = itemOrderedGridview.Rows.Add();
            itemOrderedGridview.Rows[i].Cells[0].Value = selectedRow.Cells[0].Value;
            itemOrderedGridview.Rows[i].Cells[1].Value = selectedRow.Cells[1].Value;
            itemOrderedGridview.Rows[i].Cells[2].Value = selectedRow.Cells[3].Value;
            itemOrderedGridview.Rows[i].Cells[3].Value = textBox1.Text;


            string seletedProductQuan1 = selectedRow.Cells[2].Value.ToString();    //value minising

            int seletedProductQuan = Convert.ToInt32(seletedProductQuan1);
            int restProduct = seletedProductQuan - Convert.ToInt32(textBox1.Text);
            selectedRow.Cells[2].Value = restProduct.ToString();

            this.Validate();                                                        //product Updating
            this.productListTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.shopManagementSystemDataSet);


            string selPrice = selectedRow.Cells[3].Value.ToString();

            double pr = Convert.ToInt32(textBox1.Text);
            price *= pr;
            price += Convert.ToDouble(selPrice);
            vat = price * 0.05;
            price += vat;
            textBox3.Text = vat.ToString();          //VAT
            textBox2.Text = price.ToString();        //Grand Total    

        }

        private void productListTableDataGridView_MouseHover(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void itemOrderedGridview_MouseHover(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void itemOrderedGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = itemOrderedGridview.CurrentCell.RowIndex;
            price -= Convert.ToDouble(itemOrderedGridview.Rows[rowIndex].Cells[2].Value.ToString()); //new price
            price -= vat;
            double newVat = price * 0.05;
            price += newVat;

            textBox3.Text = newVat.ToString();
            textBox2.Text = price.ToString();
            if (rowIndex == 0)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                price = 0;
                vat = 0;
            }
            itemOrderedGridview.Rows.RemoveAt(rowIndex);

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.productListTableBindingSource.MoveNext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.productListTableBindingSource.MovePrevious();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string s = a;
                int i = itemOrderedGridview.CurrentCell.RowIndex;
                if (i == 0)
                {

                    int k = Convert.ToInt32(s);
                    MessageBox.Show("Products wiil be delivered to your address.(Only cash on deliver is avaiable now)");
                    database da = new database();
                    string a = Convert.ToString(DateTime.Now);
                    da.insertInPaymentTable(price, a);
                    int invoice = da.getLastInvoiceId();
                    invoice++;
                    da.insertInOrderListTable(k, invoice, price, a);
                }
                else
                {
                    MessageBox.Show("Please purchase atleast one product from product table to confirm your order.");
                }
            }
            catch {
                MessageBox.Show("Please order atleat one product");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void productListTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //private void button3_Click_1(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
