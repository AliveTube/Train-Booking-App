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
        public EditTripForm()
        {
            InitializeComponent();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDBDataSet.Trip' table. You can move, or remove it, as needed.
            using (SqlConnection connection = new SqlConnection("Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand("SELECT Source FROM Trip", connection);
                SqlDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    //comboBox1.Items.Add(reader["Source"]);
                }
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
  
        }
    }
}
