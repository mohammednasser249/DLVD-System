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
    public partial class frmIssueDrivingLicense : Form
    {
        int LicenceID;
        public frmIssueDrivingLicense(int LID)
        {
            InitializeComponent();
            LicenceID = LID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            uC_ApplicatoinBasicInfo1.LoadData(LicenceID);
            uC_DrivingLicenseAppInfo1._LoadData(LicenceID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
              clsApplications Application = clsApplications.FindApplicationByLicnceID(LicenceID);
            
            clsLocalDrivingLicenseApplicationsBL localapp = clsLocalDrivingLicenseApplicationsBL.FindbyID(LicenceID);
            clsLocalDrivingLicnseViewBl View = clsLocalDrivingLicnseViewBl.FindByLicenseID(LicenceID);

            // check if the person is not a driver in the system if not then add him if he is already a 
            // driver do not add the driver just get its driver number and add to license 

            if (clsDriver.GetDriverId(Application.ApplicantPersonID) == -1)
            {
                clsDriver Driver = new clsDriver();
                Driver.PersonID = Application.ApplicantPersonID;
                Driver.CreatedByUserID = Globals.CurrentUser.UserID;
                Driver.CreatedDate = DateTime.Now;

                Driver.Save();
            }

            // Add new licence here 

            clsLicenseBL Licence = new clsLicenseBL();

            Licence.ApplicationID = Application.ApplicationID;
            Licence.DriverID = clsDriver.GetDriverId(Application.ApplicantPersonID);
            Licence.LicenseClass=localapp.LicenseClassID;
            Licence.IssueDate = DateTime.Now;
            Licence.ExpirationDate = Licence.IssueDate.AddDays(clsLicenseClassesBL.GetDefaultValidLength(localapp.LicenseClassID)*365);
            Licence.Notes = textBox1.Text;
            Licence.PaidFees = 20;
            Licence.IsActive= true;
            Licence.IssueReason = 1; // First time 
            Licence.CreatedByUserID= Globals.CurrentUser.UserID;

            if (Licence.Save())
            {
                MessageBox.Show($"License Issued Succussfully with licence Id = {Licence.LicenseID} ");
              
                    

            }
            else
                MessageBox.Show("License Failed to be issued");


        }
    }
}
