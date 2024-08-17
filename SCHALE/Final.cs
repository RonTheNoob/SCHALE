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
    public partial class frmFinal : Form
    {
        public frmFinal()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

            frmStore fstart = new frmStore();
            fstart.ShowDialog();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\ronni\\Documents\\Receipt.txt", true);
            sw.WriteLine("\n\n\n THANK YOU FOR FOR PURCHASING IN SCHALE!");
            sw.Close();

            MessageBox.Show("Thank you for purchasing our products! Your receipt has been printed. Please stay updated on your email for updates and additional information needed for your purchase. We Hope to see you again!", "Thank You!");
            this.Hide();
            this.Close();
            frmWelcome fStart = new frmWelcome();
            fStart.ShowDialog();
        }
    }
}
