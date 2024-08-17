using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class managetask : Form
    {
        private string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234"; // Update with your connection string

        public managetask()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Search button
        {
            string email = textBox1.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string empIdQuery = "SELECT EMPID FROM EMPLOYEES WHERE EMAIL = :Email";

                using (OracleCommand empIdCommand = new OracleCommand(empIdQuery, connection))
                {
                    empIdCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                    try
                    {
                        connection.Open();
                        object empIdResult = empIdCommand.ExecuteScalar();

                        if (empIdResult != null)
                        {
                            int empId = Convert.ToInt32(empIdResult);

                            string taskQuery = "SELECT TASKID, DESCRIPTION FROM TASKS WHERE EMPID = :EmpId";

                            using (OracleCommand taskCommand = new OracleCommand(taskQuery, connection))
                            {
                                taskCommand.Parameters.Add(":EmpId", OracleDbType.Int32).Value = empId;

                                using (OracleDataAdapter adapter = new OracleDataAdapter(taskCommand))
                                {
                                    DataTable taskTable = new DataTable();
                                    adapter.Fill(taskTable);

                                    if (taskTable.Rows.Count > 0)
                                    {
                                        // Concatenate all task descriptions into a single string
                                        string taskDescriptions = "";
                                        foreach (DataRow row in taskTable.Rows)
                                        {
                                            taskDescriptions += $"Task ID: {row["TASKID"]}, Description: {row["DESCRIPTION"]}\n";
                                        }
                                        textBox3.Text = taskDescriptions;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No tasks found for this employee.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Back button
        {
            // Close this form or navigate to the previous form
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Completed button
        {
            int taskId = Convert.ToInt32(textBox2.Text);

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string updateQuery = "UPDATE TASKS SET STATUS = 'completed' WHERE TASKID = :TaskId";

                using (OracleCommand command = new OracleCommand(updateQuery, connection))
                {
                    command.Parameters.Add(":TaskId", OracleDbType.Int32).Value = taskId;

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No task found with the specified task ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
