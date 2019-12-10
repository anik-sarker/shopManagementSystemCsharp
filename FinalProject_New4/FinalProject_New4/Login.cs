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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerSignUp cs = new customerSignUp();
            cs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                database da = new database();
                int a = Convert.ToInt32(textBox1.Text.ToString());
                int b = Convert.ToInt32(textBox2.Text.ToString());
                string res = da.getUsertype(a, b);
                //MessageBox.Show(res);
                if (res == null)
                {
                    MessageBox.Show("WRONG username and password!");
                }
                else if (res.Equals("Customer"))
                {
                    CustomerDashboardNew1 cd = new CustomerDashboardNew1(a);
                    this.Hide();
                    cd.Show();
                    
                }
                else if (res.Equals("Employee"))
                {
                    employeeDashboardNew ed = new employeeDashboardNew(a);
                    ed.Show();
                    this.Hide();
                }
                else if (res.Equals("Admin"))
                {
                    AdminNew ad = new AdminNew(a);
                    ad.Show();
                    this.Hide();
                }
            }
            catch {
                MessageBox.Show("Wrong username and password");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter only Numbers");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
