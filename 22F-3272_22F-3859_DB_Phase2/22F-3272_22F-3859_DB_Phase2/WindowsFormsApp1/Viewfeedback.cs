using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Viewfeedback : Form
    {
        public Viewfeedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//search bttn 
        {
            // Establish database connection and fetch feedback descriptions
            string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=HOST;PASSWORD=1234";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = "SELECT DESCRIPTION FROM FEEDBACK";

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder feedbackText = new StringBuilder();

                            while (reader.Read())
                            {
                                feedbackText.AppendLine(reader["DESCRIPTION"].ToString());
                            }

                            textBox3.Text = feedbackText.ToString();
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

        private void Viewfeedback_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard Newform1 = new Dashboard();
            Newform1.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
