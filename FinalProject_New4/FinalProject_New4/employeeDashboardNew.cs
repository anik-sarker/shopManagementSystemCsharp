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
    public partial class employeeDashboardNew : Form
    {
        DataTable OLT;
        DataTable PLT;
        DataGridViewRow selectedRow;
        string empid;
        public employeeDashboardNew()
        {
            InitializeComponent();
        }
        public employeeDashboardNew(int id) {
            InitializeComponent();
            empid = id.ToString();
            database dl = new database();
           string s= dl.getEmployeeName(id);
            textBox1.Text = empid;
            textBox2.Text = s;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dk = new DataTable();
            database dt = new database();
            int k = Convert.ToInt32(textBox3.Text.ToString());
            dk= dt.getProductData(k);
            dataGridView2.DataSource = dk;
        }

        private void employeeDashboardNew_Load(object sender, EventArgs e)
        {
             database da = new database();
             OLT=da.getDataFromTable("orderListTable");
             PLT = da.getDataFromTable("productListTable");
             dataGridView1.DataSource = OLT;
             dataGridView2.DataSource = PLT;

             label6.Text = DateTime.Now.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selectedRow = dataGridView2.Rows[index];

            proIdTextBox.Text = selectedRow.Cells[0].Value.ToString();
            proNameTextBox.Text= selectedRow.Cells[3].Value.ToString();
            proQuantityTextBox.Text = selectedRow.Cells[1].Value.ToString();
            proPriceTextBox.Text= selectedRow.Cells[2].Value.ToString();
            proTypeTextBox.Text= selectedRow.Cells[4].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                database dt = new database();
                dt.insertInProductListTable(proNameTextBox.Text.ToString(), Convert.ToInt32(proQuantityTextBox.Text.ToString()), Convert.ToDouble(proPriceTextBox.Text.ToString()), proTypeTextBox.Text.ToString());
                dataGridView2.DataSource = dt.getDataFromTable("productListTable");
            }
            catch
            {
                MessageBox.Show("Please enter some values .");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                database dt = new database();
                int d = Convert.ToInt32(textBox3.Text.ToString());
                dt.deleteData(d);
                dataGridView2.DataSource = dt.getDataFromTable("productListTable");
            }
            catch {
                MessageBox.Show("Please insert an value");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void proIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void proQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid");
            }
        }

        private void proPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin will be notified about your salary.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                database ds = new database();
                ds.updateTable(proNameTextBox.Text.ToString(), Convert.ToInt32(proQuantityTextBox.Text.ToString()), Convert.ToInt32(proPriceTextBox.Text.ToString()), proTypeTextBox.Text.ToString(), Convert.ToInt32(proIdTextBox.Text.ToString()));
            }
            catch {
                MessageBox.Show("Please enter some values");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
