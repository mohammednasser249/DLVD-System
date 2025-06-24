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
    public partial class UC_DetainLicense : UserControl
    {
        public UC_DetainLicense()
        {
            InitializeComponent();
        }
        clsLicenseBL License = null;
        clsApplications App;
        clsPeopleBL Person;

        private void button1_Click(object sender, EventArgs e)
        {


            clsDetainedLicensesBl DetailLicense = new clsDetainedLicensesBl();

            DetailLicense.LicensesID=License.LicenseID;
            DetailLicense.DetainDate = DateTime.Now;
            DetailLicense.FineFees = 50;
            DetailLicense.CreatedByUser=Globals.CurrentUser.UserID;
            DetailLicense.isReleased = 0;
            DetailLicense.ReleaseApplicatoinID = null;
            DetailLicense.ReleaseDate = null;
            DetailLicense.ReleasedByUserID = null;

            // After createing the detali row application save to database 

            if (DetailLicense.Save())
            {
                MessageBox.Show($"License was detained with id={DetailLicense.DetainedID}");
            }
            else
                MessageBox.Show("License Failed to be detained");


                






        }

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
         
            //Filling 

            lbCreateddBy.Text=Globals.CurrentUser.UserName.ToString();
            lbLID.Text = License.LicenseID.ToString();
            if (clsDetainedLicensesBl.isLicenseDetained(License.LicenseID))
            {
                lbIsDetained.Text = "Yes";
                MessageBox.Show("Can not detain because it is already detained");
                button1.Enabled = false;    
            }
            else
                lbIsDetained.Text = "No";

        }
    }
}
