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
    public partial class frmDrivingLicenseInfo : Form
    {
        int LicenseId;
        public frmDrivingLicenseInfo(int licenseId)
        {
            InitializeComponent();
            LicenseId = licenseId;  
        }

        private void frmDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            uC_DriverLicenseInfo1._LoadData(LicenseId); 
        }
    }
}
