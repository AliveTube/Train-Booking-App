﻿using System;
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
            if (string.IsNullOrEmpty(IdBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                using (SqlConnection customerConnection = new SqlConnection("Data Source=ALIVETUBE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    customerConnection.Open();
                    String query = "SELECT fName+' '+lName as Name , fName , lName  , phone , email FROM Customer WHERE id = @customerID AND password = @Password";
                    SqlCommand command = new SqlCommand(query, customerConnection);
                    command.Parameters.AddWithValue("@customerID", int.Parse(IdBox.Text));
                    command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.setEmail(reader["email"].ToString());
                        customer.setPhoneNumber(reader["phone"].ToString());
                        customer.setCustomerID(int.Parse(IdBox.Text));
                        customer.setPassword(PasswordBox.Text);
                        customer.setEmail(reader["email"].ToString());
                        customer.setfirstName(reader["fName"].ToString());
                        customer.setlastName(reader["lName"].ToString());

                        String customerName = reader["Name"].ToString();
                        CustomerMenu customerMenu = new CustomerMenu(customerName);
                        this.Hide();
                        customerMenu.Show();
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
