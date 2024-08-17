using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;

namespace SCHALE
{
    public partial class Character_Art : Form
    {
        SqlConnection con = new SqlConnection("Data Source = ron\\SQLEXPRESS;Initial Catalog = users; Integrated Security = true");

        public class Price
        {
            private double bust, half, full;
            private double additional;
            public Price()
            {
                this.bust = 2500;
                this.half = 3500;
                this.full = 4000;
                this.additional = 0;
            }
            public void increaseBust()
            {
                this.bust = this.bust + 100;
                additional = this.additional + 100;
            }
            public void increaseHalf()
            {
                this.half = this.half + 100;
                additional = this.additional + 100;
            }
            public void increaseFull()
            {
                this.full = this.full + 100;
                additional = this.additional + 100;
            }
            public double currentBust()
            {
                return this.bust;
            }
            public double currentHalf()
            {
                return this.half;
            }
            public double currentFull()
            {
                return this.full;
            }
            public double additionalPrice()
            {
                return this.additional;
            }

        }

        private Price p1 = new Price();

        public Character_Art()
        {
            InitializeComponent();
        }

        private void rtxtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                string comp = cmbComp.Text;
                if (comp == "Bust Up (P2500)")
                {
                    p1.increaseBust();
                }
                else if (comp == "Half Body (P3500)")
                {
                    p1.increaseHalf();
                }
                else if (comp == "Full Body (P4000)")
                {
                    p1.increaseFull();
                }


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

        private void btnPurchase_Click(object sender, EventArgs e)
        {

            string comp = cmbComp.Text;

            double bust = p1.currentBust();
            double half = p1.currentHalf();
            double full = p1.currentFull();

            double addPrice = p1.additionalPrice();


            // insert info into database
            string insertQuery = "INSERT INTO CharacterArt (character_name, description, composition, price) VALUES (@character_name, @description, @composition, @price)";

            using (SqlCommand command = new SqlCommand(insertQuery, con))
            {
                con.Open();
                command.Parameters.AddWithValue("@character_name", txtCharacter.Text);
                command.Parameters.AddWithValue("@description", rtxtDesc.Text);

                CheckoutDigi fd = new CheckoutDigi();

                if (comp == "Bust Up (P2500)")
                {
                    command.Parameters.AddWithValue("@composition", "Bust Up");
                    command.Parameters.AddWithValue("@price", 2500);
                    command.ExecuteNonQuery();

                    DialogResult m = MessageBox.Show("You chose: CHARACTER ART (Bust Up)\nYour total is: P" + bust + ".00\nIs this correct?", "Checking out...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (m == DialogResult.Yes)
                    {

                        //File
                        StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                        sw.WriteLine("CHARACTER NAME: " + txtCharacter.Text);
                        sw.WriteLine("COMPOSITION: " + cmbComp);
                        sw.WriteLine("DESCRIPTIONS: \n" + rtxtDesc.Text);
                        sw.WriteLine("\nADDITIONAL PRICE:   P" + addPrice + ".00");
                        sw.WriteLine("---");
                        sw.WriteLine("TOTAL PRICE:  P" + bust + ".00");
                        sw.WriteLine("\n=============================================");
                        sw.Close();
                    }

                    this.Hide();
                    this.Close();

                    fd.ShowDialog();
                    con.Close();

                }
                else if (comp == "Half Body (P3500)")
                {
                    command.Parameters.AddWithValue("@composition", "Half Body");
                    command.Parameters.AddWithValue("@price", 3500);
                    command.ExecuteNonQuery();

                    DialogResult m = MessageBox.Show("You chose: CHARACTER ART (Half Body)\nYour total is: P" + half + ".00\nIs this correct?", "Checking out...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (m == DialogResult.Yes)
                    {

                        //File
                        StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                        sw.WriteLine("CHARACTER NAME: " + txtCharacter.Text);
                        sw.WriteLine("COMPOSITION: " + cmbComp);
                        sw.WriteLine("DESCRIPTIONS: \n" + rtxtDesc.Text);
                        sw.WriteLine("\nADDITIONAL PRICE:   P" + addPrice + ".00");
                        sw.WriteLine("---");
                        sw.WriteLine("TOTAL PRICE:  P" + half + ".00");
                        sw.WriteLine("\n=============================================");
                        sw.Close();
                    }

                    this.Hide();
                    this.Close();

                    fd.ShowDialog();
                    con.Close();

                }
                else if (comp == "Full Body (P4000)")
                {
                    command.Parameters.AddWithValue("@composition", "Full Body");
                    command.Parameters.AddWithValue("@price", 4000);
                    command.ExecuteNonQuery();

                    DialogResult m = MessageBox.Show("You chose: CHARACTER ART (Half Body)\nYour total is: P" + full + ".00\nIs this correct?", "Checking out...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (m == DialogResult.Yes)
                    {

                        //File
                        StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
                        sw.WriteLine("CHARACTER NAME: " + txtCharacter.Text);
                        sw.WriteLine("COMPOSITION: " + cmbComp);
                        sw.WriteLine("DESCRIPTIONS: \n" + rtxtDesc.Text);
                        sw.WriteLine("\nADDITIONAL PRICE:   P" + addPrice + ".00");
                        sw.WriteLine("---");
                        sw.WriteLine("TOTAL PRICE:  P" + full + ".00");
                        sw.WriteLine("\n=============================================");
                        sw.Close();
                    }

                    this.Hide();
                    this.Close();

                    fd.ShowDialog();
                    con.Close();

                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "Downloads";
                ofd.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                ofd.ShowDialog();

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    con.Open();

                    // background
                    string file_name = System.IO.Path.GetFileName(ofd.FileName);
                    SqlCommand cmd = new SqlCommand("INSERT INTO CharacterArt(backgroundimg)VALUES('\\Image\\" + "\\" + file_name + "')", con);
                    cmd.ExecuteNonQuery();
                    string filepath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    System.IO.File.Copy(ofd.FileName, filepath + "\\Image\\" + file_name);

                    MessageBox.Show("Information Verified! Double check your inputted information and proceed to checkout after!", "Verified!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //show image
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CharacterArt WHERE character_name = '"+txtCharacter.Text+"'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    pboxBack.Image = Image.FromFile(filepath + dt.Rows[0]["backgroundimg"].ToString()); 
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Background Image Already Exists.");
                con.Close();
            }
        }

        private void Character_Art_Load(object sender, EventArgs e)
        {

            ArrayList comp = new ArrayList(); //Array list for composition

            comp.Add("Bust Up (P2500)");
            comp.Add("Half Body (P3500)");
            comp.Add("Full Body (P4000)");

            foreach (string c in comp)
            {
                cmbComp.Items.Add(c);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {

        }
    }
}
