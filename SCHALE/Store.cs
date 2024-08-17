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
    public partial class frmStore : Form
    {

        public frmStore()
        {
            InitializeComponent();

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("\n [ ORDER ]");
            sw.WriteLine();
            sw.Close();
        }

        private void btnDigital_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("\n TYPE: DIGITAL ART ");
            sw.WriteLine();
            sw.Close();

            this.Hide();
            this.Close();
            frmDigital f3 = new frmDigital();
            f3.ShowDialog();
        }

        private void btnTradi_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("\n TYPE: TRADITIONAL ART ");
            sw.WriteLine();
            sw.Close();

            this.Hide();
            this.Close();
            frmTraditional f4 = new frmTraditional();
            f4.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnProd_Click(object sender, EventArgs e)
        {

        }
    }
}
