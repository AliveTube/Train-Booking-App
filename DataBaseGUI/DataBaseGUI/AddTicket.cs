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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseGUI
{
    public partial class AddTicket : Form
    {
        private Customer customer = null;
        public AddTicket(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        int getIDFromString(string str)
        {
            string s = "";
            foreach (char c in str)
            {
                if (c == ' ')
                    break;
                s += c;
            }
            return int.Parse(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tripID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int trainID = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                foreach (int i in checkedListBox1.SelectedIndices)
                {
                    int seatNo = getIDFromString(checkedListBox1.Items[i].ToString());
                    SqlCommand newCommand = new SqlCommand("INSERT INTO Ticket (CustomerID, TrainID, SeatNo, TripID, Price) VALUES (@cid, @tid, @sno, @trid, 25)", connection);
                    newCommand.Parameters.AddWithValue("@cid", customer.getCustomerID());
                    newCommand.Parameters.AddWithValue("@tid", trainID);
                    newCommand.Parameters.AddWithValue("@sno", seatNo);
                    newCommand.Parameters.AddWithValue("@trid", tripID);
                    newCommand.ExecuteNonQuery();
                }
            }
            MessageBox.Show(string.Format("You bought {0} tickets for {1}$", checkedListBox1.SelectedIndices.Count, checkedListBox1.SelectedIndices.Count * 25));
            this.Close();
        }

        private void AddTicket_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT Source FROM Trip", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Source"]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string source = comboBox1.Text;
            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT Destination FROM Trip WHERE Source = @src", connection);
                newCommand.Parameters.AddWithValue("@src", source);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    string dest = reader["Destination"].ToString();
                    comboBox2.Items.Add(dest);
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string source = comboBox1.Text;
            string dest = comboBox2.Text;

            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TripID, Source, Destination, TripDate, Train FROM Trip WHERE Source = @src AND Destination = @dest", connection);
                newCommand.Parameters.AddWithValue("@src", source);
                newCommand.Parameters.AddWithValue("@dest", dest);

                SqlDataAdapter adapter = new SqlDataAdapter(newCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            if (dataGridView1.CurrentRow == null) return;
            checkedListBox1.Items.Clear();
            int tripID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int trainID = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("Select * From Seat Where SeatNo Not In ( Select SeatNo From Ticket Where TripID = @trip) AND TrainID = @train", connection);
                newCommand.Parameters.AddWithValue("@train", trainID);
                newCommand.Parameters.AddWithValue("@trip", tripID);

                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    checkedListBox1.Items.Add(reader["SeatNo"].ToString() + ' ' + reader["SeatType"].ToString());
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
