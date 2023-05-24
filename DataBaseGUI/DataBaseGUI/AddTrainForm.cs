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
    public partial class AddTrainForm : Form
    {
        public AddTrainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please fill all required fields !");
            }
            else
            {
                // We use using keyword so it handles exeptions if happened and also to close the connection after finishing automatically
                using (SqlConnection connection = new SqlConnection("Data Source=WAR-MACHINE;Initial Catalog=projectDB;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand newCommand = new SqlCommand("INSERT INTO Train VALUES (@id, @model)", connection);
                    newCommand.Parameters.AddWithValue("@id", textBox1.Text);
                    newCommand.Parameters.AddWithValue("@model", textBox2.Text);
                    newCommand.ExecuteNonQuery();

                    foreach (DataGridViewRow seat in dataGridView1.Rows)
                    {
                        SqlCommand seatCommand = new SqlCommand("INSERT INTO Seat(SeatNo, TrainID, SeatType) VALUES (@num, @id, @type)", connection);
                        if (seat.Cells["Column1"].Value == null)
                            continue;
                        seatCommand.Parameters.AddWithValue("@id", textBox1.Text);
                        seatCommand.Parameters.AddWithValue("@num", seat.Cells["Column1"].Value);
                        seatCommand.Parameters.AddWithValue("@type", seat.Cells["Column2"].Value);
                        seatCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Train added successfully");
                    this.Hide();
                    Form1 mainMenu = new Form1();
                    mainMenu.ShowDialog();
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView1, dataGridView1.RowCount + 1, "");
            dataGridView1.Rows.Add(newRow);

        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
