using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PreviousAppointment : Form
    {
        public PreviousAppointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//search bttn
        {
            int appointmentID;
            if (!int.TryParse(textBox1.Text, out appointmentID))
            {
                MessageBox.Show("Please enter a valid Appointment ID.");
                return;
            }

            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "SELECT PID, AppointmentDate, Time, DoctorID " +
                             "FROM Appointment " +
                             "WHERE AppointmentID = :AppointmentID";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":AppointmentID", OracleDbType.Int32).Value = appointmentID;

                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Text = reader["PID"].ToString();
                                textBox3.Text = reader["AppointmentDate"].ToString();
                                textBox4.Text = reader["Time"].ToString();
                                textBox5.Text = reader["DoctorID"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No appointment found for the provided Appointment ID.");
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

        private void textBox2_TextChanged(object sender, EventArgs e)//pid number
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//date 
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//time
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//doctorid
        {

        }

        private void PreviousAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
