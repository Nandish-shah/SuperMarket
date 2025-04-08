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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperMarket
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int iid = int.Parse(textBox1.Text);
            int productid = int.Parse(textBox2.Text);
            int stockadded = int.Parse(textBox3.Text);
            decimal stockremoved = decimal.Parse(textBox4.Text);
            
            string query = "INSERT INTO inventory (IID, ProductID, StockAdded , StockRemoved ) VALUES(@IID, @ProductID, @StockAdded , @StockRemoved)";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@StockAdded", stockadded);
                    cmd.Parameters.AddWithValue("@StockRemoved", stockremoved);
                    
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Inserted Successfully!");
            InventoryData(); // Refresh DataGridView
        }
        private void InventoryData()
        {
            string query = "SELECT * FROM inventory";
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
            int iid = int.Parse(textBox1.Text);
            int productid = int.Parse(textBox2.Text);
            int stockadded = int.Parse(textBox3.Text);
            decimal stockremoved = decimal.Parse(textBox4.Text);

            string query = "UPDATE Inventory SET ProductID=@ProductID, StockAdded=@StockAdded , StockRemoved=@StockRemoved WHERE IID=@IID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@StockAdded", stockadded);
                    cmd.Parameters.AddWithValue("@StockRemoved", stockremoved);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Updated Successfully!");
            InventoryData(); // Refresh DataGridView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int iid = int.Parse(textBox1.Text);
           
            string query = "DELETE FROM inventory WHERE IID=@IID";

            using (MySqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);
                   
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("✅ Record Deleted Successfully!");
            InventoryData(); // Refresh DataGridView
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            InventoryData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
