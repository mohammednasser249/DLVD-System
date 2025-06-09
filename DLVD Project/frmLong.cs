using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DLVD_Project
{
    public partial class frmLong : Form
    {
        public frmLong()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLong_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsLoginBl.CheckLogincredentials(txtUsername.Text, txtPassword.Text))
            {
                Form1 frm = new Form1();
                frm.ShowDialog();

            }else
            {
                MessageBox.Show("User may be not registerd or is not Active", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
