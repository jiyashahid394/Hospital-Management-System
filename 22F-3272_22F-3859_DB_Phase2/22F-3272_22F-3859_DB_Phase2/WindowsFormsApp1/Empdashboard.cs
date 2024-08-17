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
    public partial class Empdashboard : Form
    {
        public Empdashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managetask newform56 = new managetask();
            newform56.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerSupport newform35 = new CustomerSupport();
            newform35.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewSalary newform47 = new ViewSalary();
            newform47.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CahsierCheckprofile newform45 = new CahsierCheckprofile();
            newform45.Show();
        }
    }
}
