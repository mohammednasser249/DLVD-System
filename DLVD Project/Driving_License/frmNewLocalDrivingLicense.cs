using DLVD_Project.ApplicationUC;
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

namespace DLVD_Project.Driving_License
{
    public partial class frmNewLocalDrivingLicense : Form
    {
        UCAddUser uc = new UCAddUser();
        UC_IssueDrivingLicense ucI = new UC_IssueDrivingLicense();
        int PersonID;
        public frmNewLocalDrivingLicense()
        {
            InitializeComponent();
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            btnSave.Enabled = false;

        }

        private void personalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personalInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ucI.LoadDataNewLicense(uc.PersonID);
        }

        private void applicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ucI.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucI);
            btnSave.Enabled = true;
        }
    }
}
