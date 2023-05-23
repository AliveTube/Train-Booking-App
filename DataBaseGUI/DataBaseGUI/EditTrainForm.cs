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
    public partial class EditTrainForm : Form
    {
        int oldSeats = 0;
        public EditTrainForm()
        {
            InitializeComponent();
        }

        private void EditTrainForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TrainID From Train", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["TrainID"]);
                }
                reader.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int trainNo = int.Parse(comboBox1.SelectedItem.ToString());
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT * From Train WHERE TrainID = @num", connection);
                newCommand.Parameters.AddWithValue("@num", trainNo);
                SqlDataReader reader = newCommand.ExecuteReader();
                reader.Read();
                IDataReader row = (IDataReader)reader;
                textBox1.Text = row["TrainID"].ToString();
                textBox2.Text = row["Model"].ToString();
                reader.Close();

                SqlCommand seatCommand = new SqlCommand("SELECT SeatNo, SeatType From Seat WHERE TrainID = @num", connection);
                seatCommand.Parameters.AddWithValue("@num", trainNo);
                SqlDataReader seatReader = seatCommand.ExecuteReader();
                oldSeats = 0;
                while (seatReader.Read())
                {
                    DataGridViewRow gRow = new DataGridViewRow();
                    gRow.CreateCells(dataGridView1, seatReader["SeatNo"],
                                                    seatReader["SeatType"]);
                    dataGridView1.Rows.Add(gRow);
                    oldSeats++;
                }
                seatReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView1, dataGridView1.RowCount + 1, "");
            dataGridView1.Rows.Add(newRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                foreach (DataGridViewRow seat in dataGridView1.Rows)
                {
                    if (count >= oldSeats)
                    {
                        SqlCommand seatCommand = new SqlCommand("INSERT INTO Seat(SeatNo, TrainID, SeatType) VALUES (@num, @id, @type)", connection);
                        seatCommand.Parameters.AddWithValue("@id", textBox1.Text);
                        seatCommand.Parameters.AddWithValue("@num", seat.Cells["Column1"].Value);
                        seatCommand.Parameters.AddWithValue("@type", seat.Cells["Column2"].Value);
                        seatCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand seatCommand = new SqlCommand("UPDATE Seat Set SeatType = @type WHERE SeatNo=@num AND TrainID=@id", connection);
                        seatCommand.Parameters.AddWithValue("@id", textBox1.Text);
                        seatCommand.Parameters.AddWithValue("@num", seat.Cells["Column1"].Value);
                        seatCommand.Parameters.AddWithValue("@type", seat.Cells["Column2"].Value);
                        seatCommand.ExecuteNonQuery();
                    }
                    count++;
                }
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void deleteSeats()
        {
            string trainID = textBox1.Text;
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            string deleteQuery = "DELETE FROM Seat WHERE TrainID = @t";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@t", trainID);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string trainID=textBox1.Text;
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            string deleteQuery = "DELETE FROM Train WHERE TrainID = @t";
            deleteSeats();
            if (String.IsNullOrEmpty(trainID))
            {
                MessageBox.Show("Please Select a Train!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@t", trainID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Train Deleted Successfully!");
                this.Close();
            }
            
        }
    }
}
