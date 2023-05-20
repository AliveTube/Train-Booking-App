using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseGUI
{
    public partial class CustomerMenu : Form
    {
        Customer customer1 = new Customer();
        public CustomerMenu(String customerName)
        {
            InitializeComponent();
            label1.Text = "Welcome back Mr/Mrs " + customerName ;
        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 mainMenu = new Form1();
            this.Hide();
            mainMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
