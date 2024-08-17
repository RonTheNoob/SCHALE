using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCHALE
{
    public partial class frmRegister : Form
    {

        private string connectionString = "Data Source = ron\\SQLEXPRESS;Initial Catalog = users; Integrated Security = true";

        public frmRegister()
        {
            InitializeComponent();
            this.ActiveControl = txtFirst;
            txtFirst.Focus();
        }

  
        private void btnLog_Click(object sender, EventArgs e)
        {
            string user = txtUsern.Text;
            string pass = txtPassw.Text;
            string email = txtEmail.Text;
            string firstN = txtFirst.Text;
            string lastN = txtLast.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(firstN) || string.IsNullOrWhiteSpace(lastN) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill all the required fields." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirst.Focus();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO users (username, password, first_name, last_name, email) VALUES (@username, @password, @first_name, @last_name, @email)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
              
                        cmd.Parameters.AddWithValue("@username", txtUsern.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassw.Text);
                        cmd.Parameters.AddWithValue("@first_name", txtFirst.Text);
                        cmd.Parameters.AddWithValue("@last_name", txtLast.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);


                        try
                        {
                            // Executing the SQL command
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("You have registered successfully! Returning to Welcome Page...", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();
                            this.Hide();
                            this.Close();
                            frmWelcome f0 = new frmWelcome();
                            f0.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void txtFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                txtLast.Focus();
            }
        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsern.Focus();
            }
        }

        private void txtUsern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassw.Focus();
            }
        }

        private void txtPassw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReg.PerformClick();
            }
        }
    }
 }
 