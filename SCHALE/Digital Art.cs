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
    public partial class frmDigital : Form
    {

        public frmDigital()
        {
            InitializeComponent();
        }

        private void btnCharArt_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("CATEGORY: Character Art");
            sw.Close();

            this.Hide();
            this.Close();
            Character_Art f4 = new Character_Art();
            f4.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnCharDes_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("CATEGORY: Character Design (P6000)");
            sw.Close();

            this.Hide();
            this.Close();
            Character_Design f5 = new Character_Design();
            f5.ShowDialog();
        }
    }
}
