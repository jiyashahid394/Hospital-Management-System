using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Prescription : Form
    {
        private string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
        public Prescription()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//email
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//history
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//age
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//prescirbe
        {

        }

        private void button2_Click(object sender, EventArgs e)//prescribe bttn 
        {
            string email = textBox1.Text;
            string prescription = textBox5.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateSql = "UPDATE PATIENTS SET PRESCRIPTION = :Prescription WHERE EMAIL = :Email";

                    using (OracleCommand command = new OracleCommand(updateSql, connection))
                    {
                        command.Parameters.Add(":Prescription", OracleDbType.Varchar2).Value = prescription;
                        command.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Prescription added successfully!");
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

        private void button1_Click(object sender, EventArgs e)//search bttn 
        {
            string email = textBox1.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT NAME, AGE, HISTORY FROM PATIENTS WHERE EMAIL = :Email";

                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Text = reader["NAME"].ToString();
                                textBox4.Text = reader["AGE"].ToString();
                                textBox3.Text = reader["HISTORY"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No patient found with the provided email.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Prescription_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeDashboard newform34 = new EmployeeDashboard();
            newform34.Show();
        }
    }
}
