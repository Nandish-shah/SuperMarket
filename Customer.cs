using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperMarket
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int customerid = int.Parse(textBox1.Text);
                string customername = textBox2.Text;
                string phone = textBox3.Text;
                string address = textBox4.Text;

                string query = "INSERT INTO customers (CustomerID, CustomerName, Phone, Address) VALUES(@CustomerID, @CustomerName, @Phone, @Address)";

                using (MySqlConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerid);
                        cmd.Parameters.AddWithValue("@CustomerName", customername);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Address", address);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Record Inserted Successfully!");
                CustomerData(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }
        private void CustomerData()
        {
            string query = "SELECT * FROM customers";
            using (MySqlConnection connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int customerid = int.Parse(textBox1.Text);
            string customername = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;

            string query = "Update customers SET CustomerNAme=@CustomerName, Phone=@Phone, Address=@Address WHERE CustomerID=@CustomerID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@CustomerName", customername);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Updated Successfully!");
            CustomerData(); // Refresh DataGridView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int customerid = int.Parse(textBox1.Text);
          
            string query = "Delete FROM customers WHERE CustomerID=@CustomerID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                   
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Deleted Successfully!");
            CustomerData(); // Refresh DataGridView
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            CustomerData();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
