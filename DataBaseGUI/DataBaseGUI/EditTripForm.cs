using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseGUI
{
    public partial class EditTripForm : Form
    {
        private int[] tripID = { };
        private int selectedTrip = 0;
        public EditTripForm()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TripID From Trip", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    tripID = tripID.Append(int.Parse(reader["TripID"].ToString())).ToArray();
                }
                reader.Close();

                connection.Close();
            }
            InitializeComponent();

        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                dataGridView1.Rows.Clear();
                SqlCommand newCommand = new SqlCommand("SELECT t.Source, t.Destination, t.TripDate, tr.TrainID, tr.Model\r\nFROM Trip t\r\nINNER JOIN Train tr ON t.Train = tr.TrainID", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    object[] rowValues = new object[reader.FieldCount];
                    reader.GetValues(rowValues);
                    dataGridView1.Rows.Add(rowValues);
                }
                reader.Close();
                newCommand = new SqlCommand("SELECT TrainID From Train", connection);
                reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["TrainID"]);
                }
                reader.Close();

                connection.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    DateTime date = dateTimePicker1.Value.Date;
                    DateTime time = dateTimePicker2.Value;
                    DateTime dateTime = date.Add(time.TimeOfDay);
                    string query = "UPDATE Trip SET Source = @Source , Destination = @Destination , TripDate = @TripDate , Train = @Train WHERE TripID = @TripID";
                    SqlCommand tripCommand = new SqlCommand(query, connection);
                    tripCommand.Parameters.AddWithValue("@Source", textBox1.Text);
                    tripCommand.Parameters.AddWithValue("@Destination", textBox2.Text);
                    tripCommand.Parameters.AddWithValue("@TripDate", dateTime);
                    tripCommand.Parameters.AddWithValue("@Train", comboBox1.Text);
                    tripCommand.Parameters.AddWithValue("@TripID", selectedTrip);
                    tripCommand.ExecuteNonQuery();
                    connection.Close();
                }
                Close();
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            string dateTimeString = selectedRow.Cells[2].Value.ToString();
            DateTime dateTimeValue = DateTime.Parse(dateTimeString);
            dateTimePicker1.Value = dateTimeValue.Date;
            dateTimePicker2.Value = dateTimeValue;
            comboBox1.Text = selectedRow.Cells[3].Value.ToString();
            selectedTrip = tripID[dataGridView1.SelectedRows[0].Index];
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            string source, destination;
            source= textBox1.Text;
            destination= textBox2.Text;
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            string deleteQuery = "DELETE FROM Trip WHERE Source = @src AND Destination = @des";
            if (String.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Please Select a Trip!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@src", source);
                        command.Parameters.AddWithValue("@des", destination);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Trip Deleted Successfully!");
                this.Close();
            }
  
        }
    }
}
