using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCHALE
{
    public partial class CheckoutDigi : Form
    {

        public CheckoutDigi()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {

            string contactNum = txtContact.Text;
            string mode = cmbMode.Text;

            int numLen = contactNum.Length;

            if (numLen != 11)
            {
                MessageBox.Show("Contact Number is invalid. Please input an 11-digit contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrWhiteSpace(mode))
            {
                MessageBox.Show("Please fill all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                sw.WriteLine("CONTACT NUMBER: " + contactNum);
                sw.WriteLine("MODE OF PAYMENT: " + mode);
                sw.WriteLine("=============================================\n");
                sw.Close();

                this.Hide();
                this.Close();
                frmFinal final = new frmFinal();
                final.ShowDialog();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsern_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassw_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckoutDigi_Load(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input if it's not a digit or a control character
            }
        }
    }
}
