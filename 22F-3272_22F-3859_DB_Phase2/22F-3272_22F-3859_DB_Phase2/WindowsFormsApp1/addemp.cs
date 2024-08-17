using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class addemp : Form
    {
        // Connection string to your Oracle database
        string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public addemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve values from textboxes
            string empId = textBox8.Text;
            string name = textBox3.Text; // Name
            int age = Convert.ToInt32(textBox5.Text); // Age
            string email = textBox1.Text; // Email
            string phone = textBox2.Text; // Phone
            string address = textBox6.Text; // Address
            string gender = textBox4.Text; // Gender

            // Insert employee information into the database
            InsertEmployee(empId, name, age, email, phone, address, gender);
        }

        private void InsertEmployee(string empId, string name, int age, string email, string phone, string address, string gender)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to insert employee information into the database
                    string sqlQuery = "INSERT INTO EMPLOYEES ( NAME, AGE, EMAIL, PHONE, ADDRESS, Gender,SALARY ) " +
                                      "VALUES ( :Name, :Age, :Email, :Phone, :Address, :Gender, 0)";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        // Add parameters to the SQL query
                    
                        cmd.Parameters.Add(new OracleParameter(":Name", name));
                        cmd.Parameters.Add(new OracleParameter(":Age", age));
                        cmd.Parameters.Add(new OracleParameter(":Email", email));
                        cmd.Parameters.Add(new OracleParameter(":Phone", phone));
                        cmd.Parameters.Add(new OracleParameter(":Address", address));
                        cmd.Parameters.Add(new OracleParameter(":Gender", gender));

                        // Execute the SQL command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add employee.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageEmp newdbform = new ManageEmp();
            newdbform.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Retrieve values from textboxes
            string empId = textBox8.Text;
            string name = textBox3.Text; // Name
            int age = Convert.ToInt32(textBox5.Text); // Age
            string email = textBox1.Text; // Email
            string phone = textBox2.Text; // Phone
            string address = textBox6.Text; // Address
            string gender = textBox4.Text; // Gender

            // Insert employee information into the database
            InsertEmployee(empId, name, age, email, phone, address, gender);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ManageEmp newdbform = new ManageEmp();
            newdbform.Show();
        }
    }
}
