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
    public partial class frmTraditional : Form
    {
        public frmTraditional()
        {
            InitializeComponent();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("CATEGORY: Painting (P5000.00)");
            sw.Close();

            this.Hide();
            this.Close();
            Painting f6 = new Painting();
            f6.ShowDialog();
        }

        private void btnIlluArt_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("CATEGORY: Illustration/Printed Art (P4000.00)");
            sw.Close();

            this.Hide();
            this.Close();
            IllustrationPrinted_Art f7 = new IllustrationPrinted_Art();
            f7.ShowDialog();
        }
    }
}
