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
    public partial class AdminMenu : Form
    {
        public AdminMenu(String adminName)
        {
            InitializeComponent();
            label1.Text = "Welcome back Mr/Mrs " + adminName;
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAdmin addAdminPage = new AddAdmin();
            this.Hide();
            addAdminPage.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 mainMenu = new Form1();
            this.Hide();
            mainMenu.Show();
        }
    }
}
