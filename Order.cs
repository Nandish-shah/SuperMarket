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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int orderid = int.Parse(textBox1.Text);
                int customerid = int.Parse(textBox2.Text);
                int productid = int.Parse(textBox3.Text);
                decimal quantity = decimal.Parse(textBox4.Text);
                decimal amount = decimal.Parse(textBox5.Text);

                string query = "INSERT INTO orders (OrderID, CustomerID, ProductID, Quantity ,Amount) VALUES(@OrderID, @CustomerID, @ProductID, @Quantity , @Amount)";

                using (MySqlConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderid);
                        cmd.Parameters.AddWithValue("@CustomerID", customerid);
                        cmd.Parameters.AddWithValue("@ProductID", productid);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Record Inserted Successfully!");
                OrderData(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }

        private void OrderData()
        {
            string query = "SELECT * FROM orders";
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
            int orderid = int.Parse(textBox1.Text);
            int customerid = int.Parse(textBox2.Text);
            int productid = int.Parse(textBox3.Text);
            decimal quantity = decimal.Parse(textBox4.Text);
            decimal amount = decimal.Parse(textBox5.Text);

            string query = "Update orders SET CustomerID=@CustomerID, ProductID=@ProductID, Quantity=@Quantity , Amount=@Amount WHERE OrderID=@OrderID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderid);
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Updated Successfully!");
            OrderData(); // Refresh DataGridView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int orderid = int.Parse(textBox1.Text);
        
            string query = "DELETE FROM orders WHERE OrderID=@OrderID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderid);
                 
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Deleted Successfully!");
            OrderData(); // Refresh DataGridView
        }

        private void Order_Load(object sender, EventArgs e)
        {
            OrderData();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
