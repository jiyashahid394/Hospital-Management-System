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
    public partial class ManageEmp : Form
    {
        public ManageEmp()
        {
            InitializeComponent();
        }

        private void ManageEmp_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//remove emp
        {
            Removemp newform34 = new Removemp();
            newform34.Show();
        }

        private void button3_Click(object sender, EventArgs e)//add emp
        {
            addemp newform45 = new addemp();
            newform45.Show();

        }
    }
}
