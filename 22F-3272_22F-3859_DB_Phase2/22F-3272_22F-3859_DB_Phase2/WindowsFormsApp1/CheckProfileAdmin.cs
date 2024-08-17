using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class CheckProfileAdmin : Form
    {
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public CheckProfileAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//SEARCH
        {
            string email = textBox1.Text.Trim();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to retrieve admin information
                    string sqlQuery = "SELECT NAME, ADMINID FROM admin WHERE EMAIL = :Email";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":Email", email));

                        // Execute the SQL command
                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Display admin information in respective textboxes
                            textBox2.Text = reader["NAME"].ToString();
                            textBox3.Text = DateTime.Now.ToString("MMMM dd, yyyy"); // Display current date
                            textBox4.Text = "Admin"; // Default type as Admin
                            textBox5.Text = reader["ADMINID"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Admin not found with the provided email.");
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckprofileEmp newform55 = new CheckprofileEmp();
            newform55.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkprofile newform57 = new checkprofile();
            newform57.Show();
        }
    }
}
