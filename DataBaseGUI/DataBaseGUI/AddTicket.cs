using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataBaseGUI
{
    public partial class AddTicket : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True");
        private LoginPage customer = null;
        public AddTicket(LoginPage x)
        {
            InitializeComponent();
            customer = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True";
            
            
            if(!string.IsNullOrEmpty(textBox1.Text)&&!string.IsNullOrEmpty(textBox2.Text))
            {
                string sqlQuery = "SELECT * FROM Trip WHERE Source = @source AND Destination = @dest";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@source", textBox1.Text);
                        command.Parameters.AddWithValue("@dest", textBox2.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.ReadOnly = true;
                    }
                }
            }
            else
            {   
                string sqlQuery = "SELECT * FROM Trip";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.ReadOnly = true;
                    }
                }
            }
            





        }
        public string getTripID()
        {
            return textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True";
            string search = textBox3.Text;
            string sqlQuery = "SELECT COUNT(*) FROM Customer WHERE id = @SearchValue";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", search);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        ChooseSeat x = new ChooseSeat(this,customer);
                        this.Hide();
                        x.ShowDialog();
                        this.Show();

                    }
                    else
                    {
                        
                        MessageBox.Show("The ID Trip You Entered Is not Valid\nPlease Try Again");
                    }
                }
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
