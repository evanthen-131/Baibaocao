using C_App.GUI.DataSet1TableAdapters;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       
        bool Auth(string username,string password)
        {
            return false;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?","Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
            this.Show();

        }

            private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
