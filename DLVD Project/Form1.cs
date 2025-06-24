using DLVD_Project.Driving_License;
using DLVD_Project.UserForms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frm = new frmPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentUserInfoForm frm = new frmCurrentUserInfoForm();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrChangePassword fmrChangePassword = new fmrChangePassword();
            fmrChangePassword.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Visible = false;
            frmLong frmLong = new frmLong();
            frmLong.ShowDialog();
            
        }

        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense frm = new frmNewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypes frm = new frmApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.ShowDialog();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers frm = new frmDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewNational_License_Application frm = new frmNewNational_License_Application();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense frm = new frmRenewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementOrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementLicense frm = new frmReplacementLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
               frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }
    }
}
