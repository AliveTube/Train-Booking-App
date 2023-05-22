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
    public partial class AdminMenu : Form
    {
        public Admin admin;
        public AdminMenu(Admin a)
        {
            InitializeComponent();
            this.admin = a;
            label1.Text = "Welcome back Mr/Mrs " + admin.getfirstName() + ' ' + admin.getlastName();
        }
        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddTrainForm form = new AddTrainForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditTrainForm form = new EditTrainForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAdmin addAdminPage = new AddAdmin();
            this.Hide();
            addAdminPage.ShowDialog();
            this.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            EditAdminProfile editAdminProfile = new EditAdminProfile(admin);
            this.Hide();
            editAdminProfile.ShowDialog();
            this.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
