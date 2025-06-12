using DLVD_Project.UserUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLVD_Project
{
    public partial class frmAddUsersMDI : Form
    {
        UCAddUser uc = new UCAddUser();

        UCLoginInfo ucLogin = new UCLoginInfo();

        private int _PersonID;

        public frmAddUsersMDI()
        {
            InitializeComponent();

            // Put as the main one as soon as the form opens 
         
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            btnSave.Enabled = false;

        }

        private void personalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            btnSave.Enabled = false;


        }

        private void loginInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = uc.PersonID; // get it from the showdeatils usercontrol 
            panelMain.Controls.Clear();
            ucLogin.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLogin);
            btnSave.Enabled = true;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ucLogin._LoadPersonIDAndSaveUser(_PersonID))
            {
                lbTitle.Text = "Update User";
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmUsers frmUsers = new frmUsers();
            frmUsers._GetAllUsers();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _PersonID = uc.PersonID; // get it from the showdeatils usercontrol 
            panelMain.Controls.Clear();
            ucLogin.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLogin);
            btnSave.Enabled = true;
        }
    }
}
