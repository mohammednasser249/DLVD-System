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
    public partial class UC_DriverLicenseInfo : UserControl
    {
        public UC_DriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void _LoadData(int LicenseID)
        {

            // Findlicense info 
            clsApplications Application = clsApplications.FindApplicationByLicnceID(LicenseID);

            clsLicenseBL License = clsLicenseBL.FindLicnseInfoByApplicationID(Application.ApplicationID);

            lbLicenseID.Text = LicenseID.ToString();
            lbIssueDate.Text = License.IssueDate.ToString(("yyyy-MM-dd"));
            lbExpirationDate.Text = License.ExpirationDate.ToString(("yyyy-MM-dd"));
            switch (License.IssueReason)
            {

                case 1:
                    lbReason.Text = "First Time";
                    break;
                case 2:
                    lbReason.Text = "Renew";
                    break;
                case 3:
                    lbReason.Text = "Replacement for Damage";
                    break;
                case 4:
                    lbReason.Text = "Replacement for Lost";
                    break;
            }
            if (License.IsActive == true)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";


            if (License.Notes != null)
            {
                lbNotes.Text = License.Notes.ToString();
            }
            else
                lbNotes.Text = "No Notes";



            clsLocalDrivingLicnseViewBl View = clsLocalDrivingLicnseViewBl.FindByLicenseID(LicenseID);

            lbClass.Text = View.ClassName.ToString();
            lbNationalNo.Text = View.NationalNo.ToString();
            clsPeopleBL Person = clsPeopleBL.FindPerson(Application.ApplicantPersonID);
            lbName.Text=View.FullName.ToString();
            if (Person.Gender == 0)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";
            lbDateOfBirth.Text = Person.DOB.ToString("yyyy-MM-dd");
            if (!string.IsNullOrWhiteSpace(Person.ImagePath))
            {
                pictureBox1.Image = Image.FromFile(Person.ImagePath);
            }
            else
            {
                pictureBox1.Image =null;

            }
            lbDriverID.Text =clsDriver.GetDriverId(Application.ApplicantPersonID).ToString();

            if(clsDetainedLicensesBl.isLicenseDetained(License.LicenseID))
            {
                lbIsDetained.Text = "Yes";
            }else
                lbIsDetained.Text = "NO";








        }

        private void UC_DriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
