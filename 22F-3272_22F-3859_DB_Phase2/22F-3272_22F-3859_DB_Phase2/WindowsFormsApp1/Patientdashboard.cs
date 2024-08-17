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
    public partial class Patientdashboard : Form
    {
        public Patientdashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkprofile newform1 = new checkprofile();
            newform1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerSupport newform2 = new CustomerSupport();
            newform2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookAppointment newform3 = new BookAppointment();
            newform3.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrackAppointment newform56 = new TrackAppointment();
            newform56.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PreviousAppointment newform57 = new PreviousAppointment();
            newform57.Show();
        }
    }
}
