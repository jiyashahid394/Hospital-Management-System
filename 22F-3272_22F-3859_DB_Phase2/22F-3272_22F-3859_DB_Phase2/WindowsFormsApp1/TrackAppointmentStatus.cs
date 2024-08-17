using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class TrackAppointmentStatus : Form
    {
        // Connection string to your Oracle database
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public TrackAppointmentStatus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string appointmentId = textBox1.Text;

            // Retrieve appointment status based on appointment ID
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to retrieve appointment status
                    string sqlQuery = "SELECT STATUS FROM APPOINTMENT WHERE APPOINTMENTID = :AppointmentId";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":AppointmentId", appointmentId));

                        // Execute the SQL command
                        object status = cmd.ExecuteScalar();

                        if (status != null)
                        {
                            textBox2.Text = status.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string appointmentId = textBox1.Text;

            // Delete appointment based on appointment ID
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to delete appointment
                    string sqlQuery = "DELETE FROM APPOINTMENT WHERE APPOINTMENTID = :AppointmentId";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":AppointmentId", appointmentId));

                        // Execute the SQL command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully.");
                            textBox2.Clear(); // Clear status textbox after deletion
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete appointment.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form and go back to the previous form
        }
    }
}
