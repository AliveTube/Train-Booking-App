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
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                DateTime dt = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("INSERT INTO Trip (TripDate, Source, Destination, TrainID) values (@TripDate, @Source, @Destination, @Train)", connection);
                    newCommand.Parameters.AddWithValue("@TripDate", dt);
                    newCommand.Parameters.AddWithValue("@Source", textBox2.Text);
                    newCommand.Parameters.AddWithValue("@Destination", textBox3.Text);
                    newCommand.Parameters.AddWithValue("@Train", int.Parse(comboBox1.SelectedItem.ToString()));
                    newCommand.ExecuteNonQuery();
                    this.Close();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddTripFrom_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TrainID FROM Train", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["TrainID"]);
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
