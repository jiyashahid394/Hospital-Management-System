using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class CustomerSupport : Form
    {
        public CustomerSupport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//enter bttn
        {
            string email = textBox1.Text;
            string feedback = textBox2.Text;

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Establish database connection
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to retrieve PID based on email
                    string selectPatientIdQuery = "SELECT PID FROM PATIENTS WHERE EMAIL = :Email";

                    using (OracleCommand selectPatientIdCommand = new OracleCommand(selectPatientIdQuery, connection))
                    {
                        selectPatientIdCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                        // Execute the query to retrieve PID
                        object pidResult = selectPatientIdCommand.ExecuteScalar();

                        if (pidResult != null) // Check if PID is found
                        {
                            int pid = Convert.ToInt32(pidResult);

                            // Query to insert feedback with the retrieved PID into FEEDBACK table
                            string insertFeedbackQuery = "INSERT INTO FEEDBACK (PID, DESCRIPTION, STATUS) VALUES (:Pid, :Feedback, :Status)";

                            using (OracleCommand insertFeedbackCommand = new OracleCommand(insertFeedbackQuery, connection))
                            {
                                insertFeedbackCommand.Parameters.Add(":Pid", OracleDbType.Int32).Value = pid;
                     
                                insertFeedbackCommand.Parameters.Add(":Feedback", OracleDbType.Varchar2).Value = feedback;
                                insertFeedbackCommand.Parameters.Add(":Status", OracleDbType.Varchar2).Value = "Pending"; // Assuming default status is "Pending"

                                // Execute the query to insert feedback
                                int rowsAffected = insertFeedbackCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Feedback inserted successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Failed to insert feedback.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No patient found with the provided email.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
