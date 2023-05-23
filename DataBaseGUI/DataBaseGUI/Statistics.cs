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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "First Name";
            dataGridView1.Columns[1].HeaderText = "Second Name";
            dataGridView1.Columns[2].HeaderText = "Tickets";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TOP 10 C.fName, C.lName, COUNT(T.TicketID) AS TicketCount FROM Customer C JOIN Ticket T ON C.id = T.CustomerID GROUP BY C.fName, C.lName ORDER BY TicketCount DESC", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    object[] rowValues = new object[reader.FieldCount];
                    reader.GetValues(rowValues);
                    dataGridView1.Rows.Add(rowValues);
                }
                reader.Close();
                connection.Close();
            }
            dataGridView1.Visible = true;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "Source";
            dataGridView1.Columns[1].HeaderText = "Destination";
            dataGridView1.Columns[2].HeaderText = "Tickets Sold";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT TOP 10 T.Source, T.Destination, COUNT(Tk.TicketID) AS TicketsSold FROM Trip T JOIN Ticket Tk ON T.TripID = Tk.TripID GROUP BY T.Source, T.Destination ORDER BY TicketsSold DESC;", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    object[] rowValues = new object[reader.FieldCount];
                    reader.GetValues(rowValues);
                    dataGridView1.Rows.Add(rowValues);
                }
                reader.Close();
                connection.Close();
            }
            dataGridView1.Visible = true;
        }
    }
}
