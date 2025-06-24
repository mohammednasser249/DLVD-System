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
    public partial class UC_RenewLicenseApplication : UserControl
    {

        public UC_RenewLicenseApplication()
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

            // Filling Application info 
            lbApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbisdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbCreateddBy.Text=Globals.CurrentUser.UserName;
            lbLicenseFees.Text=clsLicenseClassesBL.GetClassFees(License.LicenseClass).ToString();
            lbTotalFees.Text = (7+clsLicenseClassesBL.GetClassFees(License.LicenseClass)).ToString();
            lbOldLicnseID.Text=License.LicenseID.ToString();
            lbExpDate.Text = DateTime.Now.AddDays(clsLicenseClassesBL.GetDefaultValidLength(License.LicenseClass)*365).ToString("yyyy-MM-dd");

            if(License.ExpirationDate>DateTime.Now )
            {
                button1.Enabled = false;
                MessageBox.Show($"Select License is not yet Expired , it will expire on {License.ExpirationDate}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }
            if(License.IsActive==false)
            {
                MessageBox.Show("Can not renew this license because it is not active");
                button1.Enabled = false;

            }
            linkShowhistory.Enabled=true;





        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsApplications NewApp = new clsApplications();

            NewApp.ApplicantPersonID = App.ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationTypeID = 2; // renew 
            NewApp.ApplicationStatus = 1;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = 7;
            NewApp.CreatedByUserID = Globals.CurrentUser.UserID;

            NewApp.Save(); // Save applications 

            // then create new license for this person 



            //-------------------------------

            // Connect it either with internatinal or local application 

            clsLocalDrivingLicenseApplicationsBL LocalLicsnes = new clsLocalDrivingLicenseApplicationsBL();

            LocalLicsnes.ApplicationId=NewApp.ApplicationID;
            LocalLicsnes.LicenseClassID = License.LicenseClass;

            LocalLicsnes.Save();


            clsLicenseBL NewLicense = new clsLicenseBL();
            NewLicense.ApplicationID = NewApp.ApplicationID;
            NewLicense.DriverID = clsDriver.GetDriverId(NewApp.ApplicantPersonID);
            NewLicense.LicenseClass=License.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddDays(clsLicenseClassesBL.GetDefaultValidLength(License.LicenseClass)*365);
            if (txtNotes.Text.Length > 0)
            {
                NewLicense.Notes = txtNotes.Text;
            }
            else
                NewLicense.Notes = "";
            NewLicense.PaidFees = (7 + clsLicenseClassesBL.GetClassFees(License.LicenseClass));
            NewLicense.IsActive = true;
            NewLicense.IssueReason = 2;
            NewLicense.CreatedByUserID= Globals.CurrentUser.UserID;

            if(NewLicense.Save())
            {

                MessageBox.Show($"Licnse has been renewd succussfully with id {NewLicense.LicenseID} ");
                License.IsActive = false;
                License.Save();
                lbLID.Text = NewLicense.LicenseID.ToString();
                lbRApplicatoinID.Text = NewApp.ApplicantPersonID.ToString();
                gbFilter.Enabled = false;
                button1.Enabled = false;
                linkShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Licnesed failed to be renewd");
            }
        }

        private void linkShowhistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenesHistory frm = new frmLicenesHistory(App.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void UC_RenewLicenseApplication_Load(object sender, EventArgs e)
        {
            linkShowhistory.Enabled = false;
        }

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
