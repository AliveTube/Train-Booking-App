using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseGUI
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text)) {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                // We use using keyword so it handles exeptions if happened and also to close the connection after finishing automatically
                using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("INSERT INTO Customer (fName , lName , email , password, phone) values (@fName, @lName, @email, @password, @phone)", connection);
                    newCommand.Parameters.AddWithValue("@fName", textBox1.Text);
                    newCommand.Parameters.AddWithValue("@lName", textBox2.Text);
                    newCommand.Parameters.AddWithValue("@email", textBox3.Text);
                    newCommand.Parameters.AddWithValue("@password", textBox4.Text);
                    newCommand.Parameters.AddWithValue("@phone", textBox5.Text);
                    newCommand.ExecuteNonQuery();

                    Console.WriteLine("You have been registered successfully :)");
                    String query = "SELECT id FROM Customer WHERE email = @Email AND password = @Password";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", textBox3.Text);
                    command.Parameters.AddWithValue("@Password", textBox4.Text);
                    int id = (int)command.ExecuteScalar();
                    MessageBox.Show("You have been registered successfully, Your ID is : " + id);
                    this.Close();
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
