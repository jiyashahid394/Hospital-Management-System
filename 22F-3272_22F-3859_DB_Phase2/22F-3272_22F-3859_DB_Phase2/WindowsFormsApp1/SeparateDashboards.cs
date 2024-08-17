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
    public partial class SeparateDashboards : Form
    {
        public SeparateDashboards()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empdashboard newform345 = new Empdashboard();
            newform345.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MedicalStaffdashboard newform804 = new MedicalStaffdashboard();
            newform804.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustDashboard newform3r = new CustDashboard();
            newform3r.Show();
        }
    }
}
