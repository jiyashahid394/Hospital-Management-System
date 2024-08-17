using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class ManageAppS : Form
    {
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public ManageAppS()
        {
            InitializeComponent();
            button3.Click += button3_Click;
        }

        private void button5_Click(object sender, EventArgs e)//cancelbttn
        {
            UpdateAppointmentStatus("Cancelled");
        }

        private void button1_Click(object sender, EventArgs e)//attended
        {
            UpdateAppointmentStatus("Attended");
        }

        private void UpdateAppointmentStatus(string status)
        {
            string appointmentId = textBox1.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to update appointment status
                    string sqlQuery = "UPDATE appointment SET status = :Status WHERE appointmentid = :AppointmentId";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":Status", status));
                        cmd.Parameters.Add(new OracleParameter(":AppointmentId", appointmentId));

                        // Execute the SQL command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment status updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update appointment status.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//backbttn
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)//search bttn
        {
            string appointmentId = textBox1.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to retrieve appointment information
                    string sqlQuery = "SELECT status, appointmentdate, time, doctorid FROM appointment WHERE appointmentid = :AppointmentId";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter(":AppointmentId", appointmentId));

                        // Execute the SQL command
                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Display appointment information in respective textboxes
                            textBox2.Text = reader["status"].ToString();
                            textBox3.Text = reader["appointmentdate"].ToString();
                            textBox4.Text = reader["time"].ToString();
                            textBox5.Text = reader["doctorid"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found with the provided ID.");
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

        private void ManageAppS_Load(object sender, EventArgs e)
        {

        }
    }
}
