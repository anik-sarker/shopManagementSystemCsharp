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
    public partial class customerSignUp : Form
    {
        public customerSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database da = new database();
            try
            {
                string s = pass4.Text.ToString();
                int i = Convert.ToInt32(s);
                string ema = email1.Text.ToString();


                da.insertInCusSignUpTable(name1.Text.ToString(), ema, address3.Text.ToString(), dateTimePickerfromCusSignup1.Text.ToString(), genderComboBox1.Text.ToString(), i);

                int j = da.getUserID("cusSignUpTable", ema); //insert in userTable
                da.insertInUserTable(j, i, "Customer");
            }
            catch
            {
                MessageBox.Show("Please fill up the required fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
