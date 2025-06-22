using BusinessLayer;
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
    public partial class frmLicenesHistory : Form
    {
        int LID;
        public frmLicenesHistory(int ID)
        {
            InitializeComponent();
            LID = ID;
        }

        private void frmLicenesHistory_Load(object sender, EventArgs e)
        {
            clsApplications App = clsApplications.FindApplicationByLicnceID(LID);
            if(App==null)
            {
                uC_LicenseHist1._LoadDataLocalLiecens(LID);
                uC_ShowPersonDetails1.LoadPersonIDToUserControl(LID);
                return;
            }
            uC_LicenseHist1._LoadDataLocalLiecens(App.ApplicantPersonID);
            uC_ShowPersonDetails1.LoadPersonIDToUserControl(App.ApplicantPersonID);

        }
    }
}
