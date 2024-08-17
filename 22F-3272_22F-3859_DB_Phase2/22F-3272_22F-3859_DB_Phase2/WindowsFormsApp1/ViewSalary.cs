using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class ViewSalary : Form
    {
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public ViewSalary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;

            // Check if the current date is the end of the month
            if (DateTime.Now.Day != DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                MessageBox.Show("Salary can only be viewed at the end of the month.");
                return;
            }

            // Retrieve name, type, empid, and salary based on email
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string selectEmployeeQuery = "SELECT NAME, TYPE, EMPID, SALARY FROM EMPLOYEES WHERE EMAIL = :Email";

                using (OracleCommand selectEmployeeCommand = new OracleCommand(selectEmployeeQuery, connection))
                {
                    selectEmployeeCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                    try
                    {
                        connection.Open();
                        OracleDataReader reader = selectEmployeeCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            // Display name, type, empid, and salary in respective textboxes
                            textBox2.Text = reader["NAME"].ToString();
                            textBox3.Text = DateTime.Now.ToString("MMMM dd, yyyy"); // Current month date
                            textBox4.Text = reader["TYPE"].ToString();
                            textBox5.Text = reader["EMPID"].ToString();
                            textBox6.Text = reader["SALARY"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided email.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void ViewSalary_Load(object sender, EventArgs e)
        {

        }
    }
}
