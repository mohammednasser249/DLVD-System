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

namespace DLVD_Project.ApplicationUC
{
    public partial class UC_DrivingLicenseAppInfo : UserControl
    {
        public UC_DrivingLicenseAppInfo()
        {
            InitializeComponent();
        }


        public void _LoadData(int LicenseId)
        {
            clsLocalDrivingLicnseViewBl View = clsLocalDrivingLicnseViewBl.FindByLicenseID(LicenseId);
            if (View == null)
            {
                MessageBox.Show("Was not found");
            }

            lbApplicatoinId.Text = View.LocalDrivingLicenseApplicationID.ToString();
            lbClass.Text = View.ClassName.ToString();
            lbPassedTests.Text=View.PassedTestCount.ToString()+"/3";

        }

        private void UC_DrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
