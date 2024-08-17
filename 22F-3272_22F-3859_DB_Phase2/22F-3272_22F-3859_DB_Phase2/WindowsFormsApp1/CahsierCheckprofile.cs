using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class CahsierCheckprofile : Form
    {
        // Connection string to your Oracle database
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public CahsierCheckprofile()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;

            // Retrieve employee information based on email
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to retrieve employee information along with current system date
                    string sqlQuery = "SELECT NAME, TYPE, EMPID, TO_CHAR(SYSDATE, 'MM/DD/YYYY') AS HIREDATE FROM EMPLOYEES WHERE EMAIL = :Email";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":Email", email));

                        // Execute the SQL command
                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Display employee information in respective textboxes
                            textBox2.Text = reader["NAME"].ToString();
                            textBox3.Text = reader["HIREDATE"].ToString();
                            textBox4.Text = reader["TYPE"].ToString();
                            textBox5.Text = reader["EMPID"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Employee not found with the provided email.");
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
    }
}
