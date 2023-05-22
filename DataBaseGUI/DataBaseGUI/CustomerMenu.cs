﻿using System;
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
        public Customer customer;
        public CustomerMenu(Customer customer, LoginPage data)
        {
            this.customer = customer;
            InitializeComponent();
            label1.Text = "Welcome back Mr/Mrs " + customer.getfirstName() + ' ' + customer.getlastName();
        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddTicket form=new AddTicket(customer);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditCustomerProfile form = new EditCustomerProfile(customer);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
