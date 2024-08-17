using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class TrackAppointment : Form
    {
        public TrackAppointment()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//ENTER APPOINTMENT EMAIL
        {

        }

        private void button1_Click(object sender, EventArgs e)//SEARCH BUTTON
        {
            string appointmentEmail = textBox1.Text;

            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment WHERE WHERE APPOINTMENTID = :appointmentID";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":AppointmentEmail", OracleDbType.Varchar2).Value = appointmentEmail;

                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display appointment details
                                // For example:
                                // textBox2.Text = reader["ColumnName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No appointment found for the provided email.");
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//DELETE BUTTON
        {
            string appointmentEmail = textBox1.Text;

            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "DELETE FROM Appointment WHERE APPOINTMENTID = :appointmentID";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":AppointmentEmail", OracleDbType.Varchar2).Value = appointmentEmail;

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No appointment found for the provided email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//COMPLETED BUTTON
        {
            string appointmentEmail = textBox1.Text;

            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "UPDATE Appointment SET Status = 'Checked' WHERE APPOINTMENTID = :appointmentID";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":AppointmentEmail", OracleDbType.Varchar2).Value = appointmentEmail;

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment status updated to 'Checked' successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No appointment found for the provided email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void TrackAppointment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string appointmentID = textBox1.Text;

            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment WHERE APPOINTMENTID = :appointmentID";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":AppointmentEmail", OracleDbType.Varchar2).Value = appointmentID;

                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display appointment details
                                // For example:
                                // textBox2.Text = reader["ColumnName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No appointment found for the provided email.");
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
