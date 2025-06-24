using BusinessLayer;
using DLVD_Project.Driving_License;
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
    public partial class UC_Replacement : UserControl
    {
        public UC_Replacement()
        {
            InitializeComponent();
        }

        clsLicenseBL License = null;
        clsPeopleBL Person;
        clsApplications App;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Findlicense info 
            License = null;
            int LicenseID;
            if (int.TryParse(textBox1.Text, out LicenseID))
            {
                License = clsLicenseBL.FindByD(LicenseID);
                // Use License here
            }

            if (License == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            button1.Enabled = true;
            linkShowhistory.Enabled = false;



            lbLicenseID.Text = License.LicenseID.ToString();
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



            // Problem is here fix it 
            App = clsApplications.FindByID(License.ApplicationID);
            Person = clsPeopleBL.FindPerson(App.ApplicantPersonID);

            lbClass.Text = clsLicenseClassesBL.GetClassName(License.LicenseClass); // Change it to get class name by classid 
            lbNationalNo.Text = Person.NationalNo.ToString();
            lbName.Text = Person.FirstName.ToString() + " " + Person.SecondName.ToString() + " " + Person.ThirdName.ToString() + " " + Person.LastName.ToString();
            if (Person.Gender == 0)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";
            lbDateOfBirth.Text = Person.DOB.ToString("yyyy-MM-dd");
            if (!string.IsNullOrWhiteSpace(Person.ImagePath))
            {
                pictureBox2.Image = Image.FromFile(Person.ImagePath);
            }
            else
            {
                pictureBox2.Image = null;

            }
            lbDriverID.Text = clsDriver.GetDriverId(App.ApplicantPersonID).ToString();


            // Filling info 

            lbApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbCreateddBy.Text=Globals.CurrentUser.UserName;
            lbOldLicnseID.Text=License.LicenseID.ToString();
            if (License.IsActive == false)
            {
                MessageBox.Show("Selected License is not active , choose an active license.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                button1.Enabled = false;

            }
            linkShowhistory.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsApplications NewApp = new clsApplications();

            NewApp.ApplicantPersonID = App.ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            if (rdLost.Checked)
            {
                NewApp.ApplicationTypeID = 3;
                NewApp.PaidFees = 10;
            }
            else
            {
                NewApp.ApplicationTypeID = 4;
                NewApp.PaidFees = 5;
            }

                NewApp.ApplicationStatus = 1;
            NewApp.LastStatusDate = DateTime.Now;
            
            NewApp.CreatedByUserID = Globals.CurrentUser.UserID;

            NewApp.Save(); // Save applications 

            // then create new license for this person 



            //-------------------------------

            // Connect it either with internatinal or local application 

            clsLocalDrivingLicenseApplicationsBL LocalLicsnes = new clsLocalDrivingLicenseApplicationsBL();

            LocalLicsnes.ApplicationId = NewApp.ApplicationID;
            LocalLicsnes.LicenseClassID = License.LicenseClass;

            LocalLicsnes.Save();


            clsLicenseBL NewLicense = new clsLicenseBL();
            NewLicense.ApplicationID = NewApp.ApplicationID;
            NewLicense.DriverID = clsDriver.GetDriverId(NewApp.ApplicantPersonID);
            NewLicense.LicenseClass = License.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddDays(clsLicenseClassesBL.GetDefaultValidLength(License.LicenseClass) * 365);
          
            NewLicense.PaidFees = (NewApp.PaidFees + clsLicenseClassesBL.GetClassFees(License.LicenseClass));
            NewLicense.IsActive = true;
            if(rdDamaged.Checked)
            NewLicense.IssueReason = 3;
            else
            NewLicense.IssueReason = 4;

            NewLicense.CreatedByUserID = Globals.CurrentUser.UserID;

            if (NewLicense.Save())
            {

                MessageBox.Show($"Licnse has been renewd succussfully with id {NewLicense.LicenseID} ");
                License.IsActive = false;
                License.Save();
                lbReplacedID.Text = NewLicense.LicenseID.ToString();
                lbRApplicatoinID.Text = NewApp.ApplicantPersonID.ToString();
                gbFilter.Enabled = false;
                button1.Enabled = false;
                linkShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Licnesed failed to be Replaced");
            }
        }

        private void UC_Replacement_Load(object sender, EventArgs e)
        {
            rdDamaged.Checked = true;

        }

        private void rdDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lbFees.Text = "5";
        }

        private void rdLost_CheckedChanged(object sender, EventArgs e)
        {
            lbFees.Text = "10";
        }

        private void linkShowhistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenesHistory frm = new frmLicenesHistory(App.ApplicantPersonID);
            frm.ShowDialog();

        }
    }
}
