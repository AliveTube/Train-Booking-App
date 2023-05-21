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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseGUI
{
    public partial class EditCustomerProfile : Form
    {
        public Customer customer;
        public EditCustomerProfile(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            this.Load += loadDataToTextBoxes;
        }
        
        private void loadDataToTextBoxes(object sender, EventArgs e)
        {
            textBox1.Text = customer.getCustomerID().ToString();
            textBox2.Text = customer.getfirstName();
            textBox3.Text = customer.getlastName();
            textBox4.Text = customer.getEmail();
            textBox5.Text = customer.getPassword();
            textBox6.Text = customer.getPhoneNumber();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                // We use using keyword so it handles exeptions if happened and also to close the connection after finishing automatically
                using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("UPDATE Customer " +
                        "SET fName = @fName , lName = @lName , email = @email , password = @password, phone = @phone " +
                        "WHERE id = " + customer.getCustomerID(), connection);
                    newCommand.Parameters.AddWithValue("@fName", textBox2.Text);
                    newCommand.Parameters.AddWithValue("@lName", textBox3.Text);
                    newCommand.Parameters.AddWithValue("@email", textBox4.Text);
                    newCommand.Parameters.AddWithValue("@password", textBox5.Text);
                    newCommand.Parameters.AddWithValue("@phone", textBox6.Text);
                    newCommand.ExecuteNonQuery();
                    customer.setfirstName(textBox2.Text);
                    customer.setlastName(textBox3.Text);
                    customer.setEmail(textBox4.Text);
                    customer.setPassword(textBox5.Text);
                    customer.setPhoneNumber(textBox6.Text);
                    MessageBox.Show("Your new information has been saved successfully");
                    this.Close();
                }
            }
        }
    }
}
