using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void checkprofilebttn_Click(object sender, EventArgs e)//check profile 
        {
            CheckProfileAdmin newform57 = new CheckProfileAdmin();
            newform57.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Manageemp_Click(object sender, EventArgs e)
        {
            ManageEmp newform3 = new ManageEmp();
            newform3.Show();
        }

        private void viewpatients_Click(object sender, EventArgs e)
        {
            Viewfeedback newform5 = new Viewfeedback();
            newform5.Show();
        }

        private void viewtask_Click(object sender, EventArgs e)
        {
            AssignTasks newform36 = new AssignTasks();
            newform36.Show();
        }

        private void assignappointment_Click(object sender, EventArgs e)
        {
            BookAppointment newform34 = new BookAppointment();
            newform34.Show();
        }

        private void manageappointment_Click(object sender, EventArgs e)
        {
            ManageAppS newform34 = new ManageAppS();
            newform34.Show();
        }
    }
}
