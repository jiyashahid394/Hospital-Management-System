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
    public partial class BookAppointment : Form
    {
        public BookAppointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//patient id
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//NAME OF THE PATIENT
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//DATE
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//TIME
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//DOCTORID
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//email
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text;

            DateTime appointmentDate;
            if (!DateTime.TryParse(textBox3.Text, out appointmentDate))
            {
                MessageBox.Show("Please enter a valid appointment date.");
                return;
            }

            // Assuming appointment time is in valid format

            int doctorID;
            if (!int.TryParse(textBox5.Text, out doctorID))
            {
                MessageBox.Show("Please enter a valid DoctorID.");
                return;
            }

            // Connection and insertion code
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "INSERT INTO Appointment (PID, AppointmentDate, Time, DoctorID, Status) " +
                     "VALUES ((SELECT PID FROM PATIENTS WHERE EMAIL = :Email), :AppointmentDate, :AppointmentTime, :DoctorID, :Status)";
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;
                    command.Parameters.Add(":AppointmentDate", OracleDbType.Date).Value = appointmentDate;
                    command.Parameters.Add(":AppointmentTime", OracleDbType.Varchar2).Value = textBox4.Text;
                    command.Parameters.Add(":DoctorID", OracleDbType.Int32).Value = doctorID;
                    command.Parameters.Add(":Status", OracleDbType.Varchar2).Value = "Pending"; // Default status
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Error booking appointment!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void BookAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
