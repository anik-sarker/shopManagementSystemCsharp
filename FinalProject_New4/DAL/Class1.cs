using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
//using System.Threading.Tasks;
//using System.Windows.Forms;
namespace DAL
{
    public class Class1
    {
    }
    public class database
    {
        SqlConnection SqlConn = new SqlConnection("Data Source=LAPTOP-A0ECA2ON\\ANIK_DB;Initial Catalog=ShopManagementSystem;Integrated Security=True");
        public void insertInAdminData(string name, double balance, int pass) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into adminTable values('" + name + "','" + balance + "','" + pass + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInProductListTable(string name, int quentity, double price, string type) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into productListTable values('" + quentity + "','" + price + "','" + name + "','" + type + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInOrderListTable(int cusId, int invoiceId, double totalPrice, string orderDate) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into orderListTable values('" + cusId + "','" + invoiceId + "','" + totalPrice + "','" + orderDate + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInSalaryTable(int empId, string payDate, double ammount)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into salaryTable values('" + empId + "','" + payDate + "','" + ammount + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInCusSignUpTable(string name, string email, string address, string dob, string gender, int pass) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into cusSignUpTable values('" + name + "','" + email + "','" + address + "','" + dob + "','" + gender + "','" + pass + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInEmployeeTable(string name, string dob, string email, string gender, int pass)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into employeeTable values('" + name + "','" + dob + "','" + email + "','" + gender + "','" + pass + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInPaymentTable(double amn, string date)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into paymentTable values('" + amn + "','" + date + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public void insertInUserTable(int id, int pass, string usertype)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("Insert into userTable values('" + id + "','" + pass + "','" + usertype + "')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public string getUsertype(int id, int pass) {
            try
            {
                SqlDataAdapter SQLAdp = new SqlDataAdapter("select userType from userTable where userId = '" + id + "' and password = '" + pass + "'", SqlConn);
                DataTable ss = new DataTable();
                SQLAdp.Fill(ss);
                string sk = ss.Rows[0][0].ToString();
                return sk;
            }
            catch {

                return null;

            }
            
        }
        public string getAdminName(int id) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("select admName from adminTable where id = '" + id + "'", SqlConn);
            DataTable ss = new DataTable();
            SQLAdp.Fill(ss);
            string sk = ss.Rows[0][0].ToString();
            return sk;
        }
        public int getUserID(string s, string ema)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("select id from " + s + " where email = '" + ema + "'", SqlConn);
            DataTable ss = new DataTable();
            SQLAdp.Fill(ss);
            string sk = ss.Rows[0][0].ToString();
            int i = Convert.ToInt32(sk);
            return i;
        }
        public DataTable getProductData(int id) {
            string l = id.ToString();
            SqlDataAdapter sqladp = new SqlDataAdapter("select * from productListTable where proId = '" + l + "'", SqlConn);
            DataTable Dt = new DataTable();
            sqladp.Fill(Dt);
            return Dt;
        }
        public string getCustomerName(int id)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("select cusName from cusSignUpTable where id = '" + id + "'", SqlConn);
            DataTable ss = new DataTable();
            SQLAdp.Fill(ss);
            string sk = ss.Rows[0][0].ToString();
            return sk;
        }
        public string getEmployeeName(int id)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("select empName from employeeTable where id = '" + id + "'", SqlConn);
            DataTable ss = new DataTable();
            SQLAdp.Fill(ss);
            string sk = ss.Rows[0][0].ToString();
            return sk;
        }
        public void updateTable(string name, int quentity, double price, string type,int id)
        {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("update productListTable set proQuentity ='" + quentity + "',proPrice ='" + price + "',proName ='" + name + "',protype ='" + type + "'where proId = '"+ id+"')", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
        public int getEmppass(int id) {
            SqlDataAdapter sqladp = new SqlDataAdapter("select empPass from employeeTable where id='"+id+"'", SqlConn);
            DataTable Dt = new DataTable();
            sqladp.Fill(Dt);
            string sk = Dt.Rows[0][0].ToString();
            int i = Convert.ToInt32(sk);
            return i;
        }
        public int getLastEmpId() {
            SqlDataAdapter sqladp = new SqlDataAdapter("select id from employeeTable where id = (select MAX(id) from employeeTable)", SqlConn);
            DataTable Dt = new DataTable();
            sqladp.Fill(Dt);
            string sk = Dt.Rows[0][0].ToString();
            int i = Convert.ToInt32(sk);
            return i;
        }
        public int getLastInvoiceId() {
            SqlDataAdapter sqladp = new SqlDataAdapter("select invId from paymentTable where invId = (select MAX(invId) from paymentTable)", SqlConn);
            DataTable Dt = new DataTable();
            sqladp.Fill(Dt);
            string sk = Dt.Rows[0][0].ToString();
            int i = Convert.ToInt32(sk);
            return i;

        }
        public DataTable getDataFromTable(string tableName)
        {
            SqlDataAdapter sqladp = new SqlDataAdapter("select * from "+tableName, SqlConn);
            DataTable Dt = new DataTable();
            sqladp.Fill(Dt);
            return Dt;
        }
        public void deleteData(int id) {
            SqlDataAdapter SQLAdp = new SqlDataAdapter("delete from productListTable where proId = '"+ id+"'", SqlConn);
            DataTable DT = new DataTable();
            SQLAdp.Fill(DT);
        }
    }
}
