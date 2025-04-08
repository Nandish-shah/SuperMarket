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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Display1();
            Display2();
            Display3();
        }
        private void Display1()
        {

            string connectionString = "Server=127.0.0.1;Database=marketdb;Uid=root;Pwd=Ahmedabad@11;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM products";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount1.Text = "Total Products: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }

        }


        private void Display2()
        {
            string connectionString = "Server=127.0.0.1;Database=marketdb;Uid=root;Pwd=Ahmedabad@11;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM customers";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount2.Text = "Total Customers: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Display3()
        {
            string connectionString = "Server=127.0.0.1;Database=marketdb;Uid=root;Pwd=Ahmedabad@11;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM orders";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount3.Text = "Total Orders: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
