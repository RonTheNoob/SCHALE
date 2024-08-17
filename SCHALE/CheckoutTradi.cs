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
using System.Xml.Linq;

namespace SCHALE
{
    public partial class CheckoutTradi : Form
    {
        public CheckoutTradi()
        {
            InitializeComponent();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {

            string contactNum = txtContact.Text;
            string address = txtAddress.Text;
            string mode = cmbMode.Text;

            int numLen = contactNum.Length;

            if (numLen != 11)
            {
                MessageBox.Show("Contact Number is invalid. Please input an 11-digit contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(mode))
            {
                MessageBox.Show("Please fill all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                sw.WriteLine("ADDRESS FOR DELIVERY: " + address);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPurchase_KeyPress(object sender, KeyPressEventArgs e)
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
