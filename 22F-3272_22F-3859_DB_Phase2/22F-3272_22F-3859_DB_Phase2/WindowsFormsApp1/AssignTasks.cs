using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class AssignTasks : Form
    {
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public AssignTasks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string name = textBox2.Text;
            string task = textBox3.Text;

            // Verify employee existence based on email and name
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string selectEmployeeQuery = "SELECT EMPID FROM EMPLOYEES WHERE EMAIL = :Email AND NAME = :Name";

                using (OracleCommand selectEmployeeCommand = new OracleCommand(selectEmployeeQuery, connection))
                {
                    selectEmployeeCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;
                    selectEmployeeCommand.Parameters.Add(":Name", OracleDbType.Varchar2).Value = name;

                    try
                    {
                        connection.Open();
                        object empIdResult = selectEmployeeCommand.ExecuteScalar();
                        connection.Close();

                        if (empIdResult != null)
                        {
                            int empId = Convert.ToInt32(empIdResult);

                            // Insert task into the task table with the associated employee details
                            string insertTaskQuery = "INSERT INTO TASKS (EMPID, DESCRIPTION, STATUS) VALUES (:EmpId, :Task, 'INCOMPLETE')";

                            using (OracleCommand insertTaskCommand = new OracleCommand(insertTaskQuery, connection))
                            {
                                insertTaskCommand.Parameters.Add(":EmpId", OracleDbType.Int32).Value = empId;
                                insertTaskCommand.Parameters.Add(":Task", OracleDbType.Varchar2).Value = task;

                                try
                                {
                                    connection.Open();
                                    int rowsAffected = insertTaskCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Update employee salary
                                        string updateSalaryQuery = "UPDATE EMPLOYEES SET SALARY = SALARY + 1000 WHERE EMPID = :EmpId";

                                        using (OracleCommand updateSalaryCommand = new OracleCommand(updateSalaryQuery, connection))
                                        {
                                            updateSalaryCommand.Parameters.Add(":EmpId", OracleDbType.Int32).Value = empId;

                                            int salaryRowsAffected = updateSalaryCommand.ExecuteNonQuery();
                                            if (salaryRowsAffected > 0)
                                            {
                                                MessageBox.Show("Task assigned successfully! Salary updated.");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Failed to update salary.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to assign task.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided email and name.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void AssignTasks_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard newform23 = new Dashboard();
            newform23.Show();
        }
    }
}
