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
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerSupport newform1 = new CustomerSupport();
            newform1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Empdashboard newform3 = new Empdashboard();
            newform3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustDashboard newform4 = new CustDashboard();
            newform4.Show();
        }
    }
}
