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
    public partial class MedicalStaffdashboard : Form
    {
        public MedicalStaffdashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CahsierCheckprofile newform57 = new CahsierCheckprofile();
            newform57.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prescription newform34 = new Prescription();
            newform34.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updaterecord newform56 = new updaterecord();
            newform56.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageAppS newform78 = new ManageAppS();
            newform78.Show();
        }
    }
}
