using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class updaterecord : Form
    {
        private string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";

        public updaterecord()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//email
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//disease
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//age
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//doctorid
        {

        }

        private void button1_Click(object sender, EventArgs e)//search bttn 
        {
            string email = textBox1.Text;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Update Patient Table
                    string updatePatientSql = "UPDATE PATIENTS SET NAME = :Name, HISTORY = :Disease, AGE = :Age WHERE EMAIL = :Email";
                    using (OracleCommand updatePatientCommand = new OracleCommand(updatePatientSql, connection))
                    {
                        updatePatientCommand.Parameters.Add(":Name", OracleDbType.Varchar2).Value = textBox2.Text;
                        updatePatientCommand.Parameters.Add(":Disease", OracleDbType.Varchar2).Value = textBox3.Text;
                        updatePatientCommand.Parameters.Add(":Age", OracleDbType.Int32).Value = Convert.ToInt32(textBox4.Text);
                        updatePatientCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;
                        updatePatientCommand.ExecuteNonQuery();
                    }

                    // Update Doctor Table
                    string updateDoctorSql = "UPDATE APPOINTMENT SET DOCTORID = :DoctorId WHERE PID IN (SELECT PID FROM PATIENTS WHERE EMAIL = :Email)";
                    using (OracleCommand updateDoctorCommand = new OracleCommand(updateDoctorSql, connection))
                    {
                        updateDoctorCommand.Parameters.Add(":DoctorId", OracleDbType.Int32).Value = Convert.ToInt32(textBox5.Text);
                        updateDoctorCommand.Parameters.Add(":Email", OracleDbType.Varchar2).Value = email;
                        updateDoctorCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Records updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating records: " + ex.Message);
                }
            }
        }

        private void updaterecord_Load(object sender, EventArgs e)
        {

        }
    }
}
