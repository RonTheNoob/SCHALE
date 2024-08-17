using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SCHALE
{
    public partial class frmLogin : Form
    {



        private string connectionString = "Data Source = ron\\SQLEXPRESS;Initial Catalog = users; Integrated Security = true";
        public frmLogin()
        {
            InitializeComponent();
            this.ActiveControl = txtUser;
            txtUser.Focus();

        }

        public class orNum
        {
            private Random random;

            public orNum()
            {
                random = new Random();
            }

            // Rest of your code...

            public long GenerateRandomNumber(Random random, int numberOfDigits)
            {
                // Ensure the first digit is not 0
                int firstDigit = random.Next(1, 10);

                // Generate the remaining digits
                long otherDigits = 0;
                for (int i = 0; i < numberOfDigits - 1; i++)
                {
                    otherDigits = otherDigits * 10 + random.Next(10);
                }

                // Combine the first digit and the remaining digits
                long result = firstDigit * (long)Math.Pow(10, numberOfDigits - 1) + otherDigits;

                return result;
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {

            orNum p1 = new orNum();

            Random random = new Random();
            // Generate a 15-digit random number
            long receiptNumber = p1.GenerateRandomNumber(random, 15);

            string user = txtUser.Text;
            string pass = txtPass.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command;
                String sql;

                sql = "Select username,password from users";

                command = new SqlCommand(sql);

                string selectQuery = "SELECT first_name FROM users WHERE username = @username AND password = @password";

                if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Please fill in all text boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", user);
                        cmd.Parameters.AddWithValue("@password", pass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User exists and the credentials match
                                string name = reader["first_name"].ToString();
                                MessageBox.Show("Login successful! Welcome back " + name + "! Proceeding to the store...", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //open txt file
                                StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                                sw.WriteLine("USER: " + name + " (" + user + ")");
                                sw.WriteLine("=============================================");
                                sw.WriteLine("\nOR #: " + receiptNumber);
                                sw.WriteLine("\n=============================================");
                                sw.Close();

                                connection.Close();
                                this.Hide();
                                this.Close();
                                frmStore f2 = new frmStore();
                                f2.ShowDialog();
                            }
                            else
                            {
                                // User not found or credentials do not match
                                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    command.Dispose();

                }
            }

        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLog.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
