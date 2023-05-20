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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(adminIdBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                using (SqlConnection customerConnection = new SqlConnection("Data Source=ALIVETUBE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    customerConnection.Open();
                    String query = "SELECT fName+' '+lName as Name FROM Admin WHERE adminId = @adminID AND password = @Password";
                    SqlCommand command = new SqlCommand(query, customerConnection);
                    command.Parameters.AddWithValue("@adminID", int.Parse(adminIdBox.Text));
                    command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        String adminName = reader["Name"].ToString();
                        AdminMenu adminMenu = new AdminMenu(adminName);
                        this.Hide();
                        adminMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Try again, Wrong credentials !");
                    }
                }
            }
            
        }

        private void adminIdBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
