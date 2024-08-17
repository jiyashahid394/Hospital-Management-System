using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace WindowsFormsApp1
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//username
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//password
        {

        }

        private void button1_Click(object sender, EventArgs e)//LOGIN  BTTN
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (IsValid_Credentials(email, password))
                {
                    MessageBox.Show("Successfully Logged!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dashboard newdashboard = new Dashboard();
                    newdashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Field Cannot Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool IsValid_Credentials(string email, string password)
        {
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ADMIN WHERE Email = :email AND Password = :password";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
                    command.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSignup adminsignForm = new AdminSignup();
            adminsignForm.Show();
        }
    }
}
