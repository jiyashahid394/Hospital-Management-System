using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminSignup : Form
    {
        public AdminSignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // SIGNUP NOW 
        {
            // Retrieve the values entered by the user
            string Name = name.Text;
            string Phone = phone.Text;
            string Username = username.Text;
            string Email = email.Text;
            string Password = password.Text;

            // Generate a random 4-digit OTP
            string otp = GenerateOTP();

            // Connection string to your Oracle database
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

            // SQL INSERT command to insert data into the database table
            string insertQuery = "INSERT INTO ADMIN (NAME, EMAIL, PHONE, USERNAME, PASSWORD, OTP) " +
                                 "VALUES (:Name, :Email, :Phone, :Username, :Password, :OTP)";

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
                        MessageBox.Show($"Data inserted successfully. OTP: {otp}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminLogin adminloginForm = new AdminLogin();
                        adminloginForm.Show();
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

        private void AdminSignup_Load(object sender, EventArgs e)
        {

        }

        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString(); // Generates a random 4-digit number
        }
    }
}
