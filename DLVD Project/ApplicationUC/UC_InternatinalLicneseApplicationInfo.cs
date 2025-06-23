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
    public partial class UC_InternatinalLicneseApplicationInfo : UserControl
    {
        public UC_InternatinalLicneseApplicationInfo()
        {
            InitializeComponent();
        }
        clsLicenseBL License = null;
        clsApplications App;
        clsPeopleBL Person;


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

             if(License == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            button1.Enabled = true;
            linkShowhistory.Enabled = true;



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
                lbName.Text = Person.FirstName.ToString() + " " + Person.SecondName.ToString()+" "+ Person.ThirdName.ToString()+" "+Person.LastName.ToString();
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
                    pictureBox1.Image = null;

                }
                lbDriverID.Text = clsDriver.GetDriverId(App.ApplicantPersonID).ToString();

            // Filling 

            lbApplicationDate.Text = DateTime.Now.ToString("yyyy-mm-dd");
            lbisdate.Text = DateTime.Now.ToString("yyyy-mm-dd");
            lbExpDate.Text = DateTime.Now.AddDays(365).ToString("yyyy-mm-dd");
            lbCreateddBy.Text = Globals.CurrentUser.UserName;
            lbLocallicneseId.Text=License.LicenseID.ToString();






        }

        private void UC_InternatinalLicneseApplicationInfo_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            linkShowhistory.Enabled = false;
            linkShowLicenseInfo.Enabled = false;    

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsApplications NewApp = new clsApplications();

            // Check if person has international license first then issue him one 

            if (clsInternationalLicensesBl.isExist(App.ApplicantPersonID))
            {
                MessageBox.Show("This person already have an international Licnese","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            NewApp.ApplicantPersonID = App.ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationTypeID = 6;
            NewApp.ApplicationStatus = 1;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = 50;
            NewApp.CreatedByUserID=Globals.CurrentUser.UserID;  

            NewApp.Save(); // Save applications 

            // then create an internatinonal license and save its info here 

            clsInternationalLicensesBl InterLicense= new clsInternationalLicensesBl();
            InterLicense.ApplicationID = NewApp.ApplicationID;
            InterLicense.DriverID = clsDriver.GetDriverId(App.ApplicantPersonID);
            InterLicense.IssuedUsingLocalLicenseID = License.LicenseID;
            InterLicense.IssueDate = DateTime.Now;
            InterLicense.ExpirationDate = DateTime.Now.AddDays(365);
            InterLicense.IsActive = true;
            InterLicense.CreatedByUserID = Globals.CurrentUser.UserID;

            if (InterLicense.Save())
            {
                MessageBox.Show($"International License Created with ID {InterLicense.InternationalLicenseID}");
                lbLID.Text=InterLicense.InternationalLicenseID.ToString();
                lbApplicatoinId.Text=NewApp.ApplicationID.ToString();
                gbFilter.Enabled = false;
                button1.Enabled = false;
                linkShowLicenseInfo.Enabled = true;


            }
            else
                MessageBox.Show("International License Failed to be saved  ");
        }

        private void linkShowhistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenesHistory frm = new frmLicenesHistory(Person.ID);
            frm.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
