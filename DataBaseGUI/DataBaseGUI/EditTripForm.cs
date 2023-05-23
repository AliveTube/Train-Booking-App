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
    public partial class EditTripForm : Form
    {
        private int tripID;
        public EditTripForm()
        {
            InitializeComponent();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                dataGridView1.Rows.Clear();
                SqlCommand newCommand = new SqlCommand("SELECT Source, Destination, TripDate, Train From Trip", connection);
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
                    tripCommand.Parameters.AddWithValue("@TripID", tripID);
                    tripCommand.ExecuteNonQuery();
                    EditTripForm_Load(sender, e);
                    connection.Close();
                }
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("ID: " + tripID.ToString());


            using (SqlConnection Connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
                {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = selectedRow.Cells[0].Value.ToString();
                    textBox2.Text = selectedRow.Cells[1].Value.ToString();
                    string dateTimeString = selectedRow.Cells[2].Value.ToString();
                    DateTime dateTimeValue;
                    if (DateTime.TryParse(dateTimeString, out dateTimeValue))
                    {
                        dateTimePicker1.Value = dateTimeValue.Date;
                        dateTimePicker2.Value = dateTimeValue;
                    }
                    
                    comboBox1.Text = selectedRow.Cells[3].Value.ToString();
                    Connection.Open();
                    String query = "SELECT TripID FROM Trip WHERE TripDate = @TripDate AND Train = @Train";
                    SqlCommand command = new SqlCommand(query, Connection);
                    command.Parameters.AddWithValue("@TripDate", DateTime.Parse(dateTimeString));
                    command.Parameters.AddWithValue("@Train", comboBox1.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tripID = int.Parse(reader["TripID"].ToString());
                            MessageBox.Show("ID: "+tripID.ToString());
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
