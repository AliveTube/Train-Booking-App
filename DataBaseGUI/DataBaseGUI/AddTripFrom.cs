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
    public partial class AddTripFrom : Form
    {
        public AddTripFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("INSERT INTO Trip (TripDate, Source, Destination, Train) values (@TripDate, @Source, @Destination, @Train)", connection);
                    newCommand.Parameters.AddWithValue("@TripDate", textBox1.Text);
                    newCommand.Parameters.AddWithValue("@Source", textBox2.Text);
                    newCommand.Parameters.AddWithValue("@Destination", textBox3.Text);
                    newCommand.Parameters.AddWithValue("@Train", textBox4.Text);
                    newCommand.ExecuteNonQuery();

                    Console.WriteLine("New Trip Added Successfully !)");
                    String query = "SELECT TripID FROM Trip WHERE TripDate = @TripDate";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TripDate", textBox1.Text);
                    int id = (int)command.ExecuteScalar();
                    MessageBox.Show("New Trip Added With ID: " + id);
                    this.Close();
                }
            }
        }
    }
}
