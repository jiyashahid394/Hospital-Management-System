using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Employeesignupcs : Form
    {
        private string employeeType; // To store the selected employee type

        public Employeesignupcs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employeeType = "Cashier/Receptionist";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employeeType = "Medical Staff";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            employeeType = "Customer Support";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the values entered by the user
            string Name = name.Text;
            string Phone = phone.Text;
            string Username = username.Text;
            string Email = email.Text;
            string Password = password.Text;
            string Age = textBox3.Text;
            string Gender = textBox1.Text;
            string Address = textBox2.Text;

            // Generate a random 4-digit OTP
            string otp = GenerateOTP();

            // Connection string to your Oracle database
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

            // SQL INSERT command to insert data into the database table
            string insertQuery = "INSERT INTO EMPLOYEES (NAME, EMAIL, PHONE, USERNAME, PASSWORD, AGE, GENDER, ADDRESS, TASK, TASK_STATUS, SALARY, TYPE, OTP) " +
                                 "VALUES (:Name, :Email, :Phone, :Username, :Password, :Age, :Gender, :Address, '', '', 0, :EmployeeType, :OTP)";

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
                command.Parameters.Add(":Age", OracleDbType.Decimal).Value = Age;
                command.Parameters.Add(":Gender", OracleDbType.Varchar2).Value = Gender;
                command.Parameters.Add(":Address", OracleDbType.Varchar2).Value = Address;
                command.Parameters.Add(":EmployeeType", OracleDbType.Varchar2).Value = employeeType;
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
                        Employee employeelogin = new Employee();
                        employeelogin.Show();
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

        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString(); // Generates a random 4-digit number
        }

        private void Employeesignupcs_Load(object sender, EventArgs e)
        {

        }
    }
}
