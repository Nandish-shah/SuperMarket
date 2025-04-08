using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*'; // ⭐ Mask the password field
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Optional
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string correctUsername = "admin";
            string correctPassword = "password123";

            if (textBox1.Text == correctUsername && textBox2.Text == correctPassword)
            {
               Market mt = new Market();
                mt.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
