using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_App.GUI
{
    public partial class ManageStore : Form
    {
        public ManageStore()
        {
            InitializeComponent();
        }

        private void danhMụcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void ManageStore_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
            this.Show();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            this.Hide();
            acc.ShowDialog();
            this.Show();
        }
    }
}
