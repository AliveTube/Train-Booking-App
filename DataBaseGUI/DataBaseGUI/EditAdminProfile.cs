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
    
    public partial class EditAdminProfile : Form
    {
        public Admin admin;
        public EditAdminProfile(Admin a)
        {
            InitializeComponent();
            this.admin = a;
            this.Load += loadDataToTextBoxes;
        }
        private void loadDataToTextBoxes(object sender, EventArgs e)
        {
            textBox1.Text = admin.getAdminID().ToString();
            textBox2.Text = admin.getfirstName();
            textBox3.Text = admin.getlastName();
            textBox4.Text = admin.getEmail();
            textBox5.Text = admin.getPassword();
            textBox6.Text = admin.getPhoneNumber();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                // We use using keyword so it handles exeptions if happened and also to close the connection after finishing automatically
                using (SqlConnection connection = new SqlConnection("Data Source=ALIVETUBE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("UPDATE Admin " +
                        "SET fName = @fName , lName = @lName , email = @email , password = @password, phone = @phone " +
                        "WHERE adminId = " + admin.getAdminID(), connection);
                    newCommand.Parameters.AddWithValue("@fName", textBox2.Text);
                    newCommand.Parameters.AddWithValue("@lName", textBox3.Text);
                    newCommand.Parameters.AddWithValue("@email", textBox4.Text);
                    newCommand.Parameters.AddWithValue("@password", textBox5.Text);
                    newCommand.Parameters.AddWithValue("@phone", textBox6.Text);
                    newCommand.ExecuteNonQuery();
                    admin.setfirstName(textBox2.Text);
                    admin.setlastName(textBox3.Text);
                    admin.setEmail(textBox4.Text);
                    admin.setPassword(textBox5.Text);
                    admin.setPhoneNumber(textBox6.Text);
                    MessageBox.Show("Your new information has been saved successfully");
                    this.Hide();
                    AdminMenu adminMenu = new AdminMenu(admin);
                    adminMenu.ShowDialog();
                }
            }
        }
    }
}
