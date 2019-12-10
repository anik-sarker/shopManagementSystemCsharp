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
    public partial class AdminNew : Form
    {
        public AdminNew()
        {
            InitializeComponent();
        }
        public AdminNew(int id)
        {
            InitializeComponent();
            string s = id.ToString();
            database da = new database();
            string name = da.getAdminName(id);
            textBox1.Text = s;
            textBox2.Text = name;
        }

        private void productListTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productListTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.shopManagementSystemDataSet);

        }

        private void AdminNew_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopManagementSystemDataSet.employeeTable' table. You can move, or remove it, as needed.
            this.employeeTableTableAdapter.Fill(this.shopManagementSystemDataSet.employeeTable);
            // TODO: This line of code loads data into the 'shopManagementSystemDataSet.orderListTable' table. You can move, or remove it, as needed.
            this.orderListTableTableAdapter.Fill(this.shopManagementSystemDataSet.orderListTable);
            // TODO: This line of code loads data into the 'shopManagementSystemDataSet.productListTable' table. You can move, or remove it, as needed.
            this.productListTableTableAdapter.Fill(this.shopManagementSystemDataSet.productListTable);

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int empId = Convert.ToInt32(idTextBox.Text.ToString());
                int amm = Convert.ToInt32(textBox3.Text.ToString());
                string dt = DateTime.Now.ToString();
                database ds = new database();
                ds.insertInSalaryTable(empId, dt, amm);
            }
            catch
            {
                MessageBox.Show("Please enter the employee id and amount");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productListTableDataGridView_MouseHover(object sender, EventArgs e)
        {
            label8.Enabled = true;
        }

        private void employeeTableDataGridView_Enter(object sender, EventArgs e)
        {
            database da = new database();
            int j = da.getLastEmpId();
            int k = da.getEmppass(j);
            da.insertInUserTable(j, k, "Employee");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            database da = new database();
            int j = da.getLastEmpId();
            int k = da.getEmppass(j);
            da.insertInUserTable(j, k, "Employee");
        }
    }
}
