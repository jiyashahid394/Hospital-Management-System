using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Removemp : Form
    {
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public Removemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;

            // Retrieve name of the employee based on email
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string selectEmployeeQuery = "SELECT NAME FROM EMPLOYEES WHERE EMAIL = :Email";

                using (OracleCommand selectEmployeeCommand = new OracleCommand(selectEmployeeQuery, connection))
                {
                    selectEmployeeCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                    try
                    {
                        connection.Open();
                        object nameResult = selectEmployeeCommand.ExecuteScalar();

                        if (nameResult != null)
                        {
                            // Display the name of the employee
                            textBox2.Text = nameResult.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;

            // Remove the employee record based on email
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string deleteEmployeeQuery = "DELETE FROM EMPLOYEES WHERE EMAIL = :Email";

                using (OracleCommand deleteEmployeeCommand = new OracleCommand(deleteEmployeeQuery, connection))
                {
                    deleteEmployeeCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                    try
                    {
                        connection.Open();
                        int rowsAffected = deleteEmployeeCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee record removed successfully!");
                            // Clear textboxes after removal
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageEmp newform1 = new ManageEmp();
            newform1.Show();
        }
    }
}
