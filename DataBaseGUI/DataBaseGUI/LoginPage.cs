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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmailBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                using (SqlConnection customerConnection = new SqlConnection("Data Source=DESKTOP-BR1VI60\\MSSQLSERVER2;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    customerConnection.Open();
                    String query = "SELECT fName+' '+lName as Name , fName , lName  , phone , email , id FROM Customer WHERE email = @email AND password = @Password";
                    SqlCommand command = new SqlCommand(query, customerConnection);
                    command.Parameters.AddWithValue("@email", EmailBox.Text);
                    command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.setEmail((reader["email"].ToString()));
                        customer.setPhoneNumber(reader["phone"].ToString());
                        customer.setCustomerID(int.Parse(reader["id"].ToString()));
                        customer.setPassword(PasswordBox.Text);
                        customer.setfirstName(reader["fName"].ToString());
                        customer.setlastName(reader["lName"].ToString());
                        CustomerMenu customerMenu = new CustomerMenu(customer);
                        this.Hide();
                        customerMenu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Try again, Wrong credentials !");
                    }
                }
            }
            
        }
    }
}
