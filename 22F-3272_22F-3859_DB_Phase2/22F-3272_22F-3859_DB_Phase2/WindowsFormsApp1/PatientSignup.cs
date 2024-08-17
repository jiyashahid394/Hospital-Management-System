using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PatientSignup : Form
    {
        public PatientSignup()
        {
            InitializeComponent();
        }

        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the values entered by the user
            string Name = name.Text;
            string Phone = phone.Text;
            string Username = username.Text;
            string Email = email.Text;
            string Password = password.Text;
            int age = Convert.ToInt32(Age.Text);
            string Gender = gender.Text;
            string Address = address.Text;

            string otp = GenerateOTP(); // Generate OTP

            // Connection string to your Oracle database
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

            // SQL INSERT command to insert data into the database table
            string insertQuery = "INSERT INTO PATIENTS (NAME, EMAIL, PHONE, USERNAME, PASSWORD, AGE, GENDER, ADDRESS, OTP) " +
                                 "VALUES (:Name, :Email, :Phone, :Username, :Password, :Age, :Gender, :Address, :OTP)";

            // Create OracleConnection and OracleCommand objects
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand(insertQuery, connection))
            {
                // Add parameters to the command
                command.Parameters.Add(":Name", OracleDbType.Varchar2).Value = Name;
                command.Parameters.Add(":Phone", OracleDbType.Varchar2).Value = Phone;
                command.Parameters.Add(":Username", OracleDbType.Varchar2).Value = Username;
                command.Parameters.Add(":Email", OracleDbType.Varchar2).Value = Email;
                command.Parameters.Add(":Password", OracleDbType.Varchar2).Value = Password;
                command.Parameters.Add(":Age", OracleDbType.Int32).Value = age;
                command.Parameters.Add(":Gender", OracleDbType.Varchar2).Value = Gender;
                command.Parameters.Add(":Address", OracleDbType.Varchar2).Value = Address;
                command.Parameters.Add(":OTP", OracleDbType.Varchar2).Value = otp;

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data inserted successfully. OTP generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Open the login form
                        Patientlogin patientlogin = new Patientlogin();
                        patientlogin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
