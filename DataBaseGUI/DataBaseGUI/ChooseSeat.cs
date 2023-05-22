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
    public partial class ChooseSeat : Form
    {
        private AddTicket trip;
        private LoginPage customer=new LoginPage();
        public ChooseSeat(AddTicket x,LoginPage y)
        {
            InitializeComponent();
            this.trip = x;
            this.customer = y;
        }

        private void ChooseSeat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            string sqlQuery = "SELECT * FROM Seat WHERE SeatNo NOT IN (SELECT SeatNo FROM Ticket)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string getCustomerID()
        {
            string ans = "234";
            string sqlQuery = "SELECT id FROM Customer WHERE email = @value1 AND password =@value2";
            string email = customer.getEmail();
            string password = customer.getPass();
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@value1", email);
                    command.Parameters.AddWithValue("@value2", password);
                    object result = command.ExecuteScalar();
                    ans = result.ToString();
                }
            }
            return ans;
        }
        private string getTrainID()
        {
            string ans = "234";
            string sqlQuery = "SELECT Train FROM Trip WHERE TripID = @value1";
            string tripID = trip.getTripID();
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@value1", tripID);
                    object result = command.ExecuteScalar();
                    ans = result.ToString();
                }
            }
            return ans;
        }
        private string getSeatNo()
        {
            return textBox1.Text;
        }
        private string getTripID()
        {
            return trip.getTripID();
        }
        private void insert()
        {
            string sqlQuery = "INSERT INTO Ticket (CustomerID, TrainID, SeatNo, TripID, Price) VALUES (@Value2, @Value3, @Value4, @Value5, @Value6)";
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    string value2, value3, value4, value5, value6;
                    value2 = getCustomerID();
                    value3 = getTrainID();
                    value4 = getSeatNo();
                    value5 = getTripID();
                    value6 = "0";
                    command.Parameters.AddWithValue("@Value2", value2);
                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);
                    command.Parameters.AddWithValue("@Value5", value5);
                    command.Parameters.AddWithValue("@Value6", value6);
                    command.ExecuteNonQuery();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BELAL;Initial Catalog=projectDB;Integrated Security=True";
            string searchValue = textBox1.Text;
            string sqlQuery = "SELECT COUNT(*) FROM Seat WHERE SeatNo = @SearchValue AND SeatNo NOT IN (SELECT SeatNo FROM Ticket)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                  
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        insert();
                        MessageBox.Show("Your Ticket Was Added Successfully!");
                    }
                    else
                    {

                        MessageBox.Show("Please Enter a valid Seat Number!");
                    }
                }
            }
        }
        
    }
}
