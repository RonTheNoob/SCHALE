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

namespace SCHALE
{
    public partial class Painting : Form
    {
        SqlConnection con = new SqlConnection("Data Source = ron\\SQLEXPRESS;Initial Catalog = users; Integrated Security = true");
        public Painting()
        {
            InitializeComponent();
        }

        public class Price
        {
            private double price;
            private double additional;
            public Price()
            {
                this.price = 5000;
                this.additional = 0;
            }
            public void increasePrice()
            {
                this.price = this.price + 100;
                additional = this.additional + 100;
            }
            public double currentPrice()
            {
                return this.price;
            }
            public double additionalPrice()
            {
                return this.additional;
            }

        }

        private Price p1 = new Price();

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            double pricee = p1.currentPrice();
            double addPrice = p1.additionalPrice();

            string insertQuery = "INSERT INTO TraditionalArt (type, description) VALUES (@type, @description)";

            con.Open();

            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@type", "Painting");
                cmd.Parameters.AddWithValue("@description", rtxtDesc.Text);
                cmd.ExecuteNonQuery();
            }

            DialogResult m = MessageBox.Show("You chose: PAINTING\nYour total is: P" + pricee + ".00\nIs this correct?", "Checking out...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (m == DialogResult.Yes)
            {
                con.Close();

                StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                sw.WriteLine("DESCRIPTIONS: \n" + rtxtDesc.Text);
                sw.WriteLine("\nADDITIONAL PRICE:   P" + addPrice + ".00");
                sw.WriteLine("---");
                sw.WriteLine("TOTAL PRICE:  P" + pricee + ".00");
                sw.WriteLine("\n=============================================");
                sw.Close();

                this.Hide();
                this.Close();
                CheckoutTradi f8 = new CheckoutTradi();
                f8.ShowDialog();

            }


        }

        private void rtxtDesc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rtxtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                //increase price
                p1.increasePrice();
                double currentP = p1.currentPrice();
                lblPrice.Text = "PRICE: P" + currentP;

                e.Handled = true; // Prevent the Enter key from creating a new line

                // Get the current text in the RichTextBox
                string currentText = rtxtDesc.Text;

                // Get the selection start (current cursor position)
                int selectionStart = rtxtDesc.SelectionStart;

                // Insert a bullet point and a new line
                string bulletPoint = "• ";
                currentText = currentText.Insert(selectionStart, bulletPoint + " ");

                // Update the RichTextBox text
                rtxtDesc.Text = currentText;

                // Set the selection start to the beginning of the next line
                rtxtDesc.SelectionStart = selectionStart + bulletPoint.Length + 1;
            }
        }
    }
}
