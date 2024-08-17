using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class checkprofile : Form
    {
        // Connection string to your Oracle database
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public checkprofile()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//ENTER EMAIL
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Retrieve patient information based on the entered email
                RetrievePatientInformation(textBox1.Text);
            }
            else
            {
                // Clear text boxes if email is empty
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void RetrievePatientInformation(string email)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to retrieve patient information using email
                    string sqlQuery = "SELECT NAME, AGE, HISTORY FROM PATIENTS WHERE EMAIL = :email";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("email", email));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display patient information in respective text boxes
                                textBox2.Text = reader["NAME"].ToString();
                                textBox3.Text = reader["AGE"].ToString();
                                textBox4.Text = reader["HISTORY"].ToString();
                            }
                            else
                            {
                                // Clear text boxes if no patient found with the entered email
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                MessageBox.Show("Patient not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//CHECK PROFILE
        {
            RetrievePatientInformation(textBox1.Text);
        }

        private void checkprofile_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dbform = new Dashboard();
            dbform.Show();
        }
    }
}
