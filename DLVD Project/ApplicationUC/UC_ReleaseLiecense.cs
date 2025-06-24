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
    public partial class UC_ReleaseLiecense : UserControl
    {
        public UC_ReleaseLiecense()
        {
            InitializeComponent();
        }
        clsLicenseBL License = null;
        clsApplications App;
        clsPeopleBL Person;
        clsDetainedLicensesBl Detained;
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

            // Check if its not detained 
        

            if (License.IsActive==false)
            {
                MessageBox.Show("This License is not Active , choose antoher license ");
                button1.Enabled = false;
                return;
            }
         


            if(!clsDetainedLicensesBl.isLicenseDetained(License.LicenseID))
            {
                MessageBox.Show("This License is not detained , choose antoher license ");
                button1.Enabled = false;
                lbIsDetained.Text = "No";


                return;
            }
            lbIsDetained.Text = "Yes";


            // Filling 

            Detained = clsDetainedLicensesBl.FindByLicenseID(License.LicenseID);
            lbDetainedID.Text=Detained.DetainedID.ToString();
            lbDetainedDate.Text=Detained.DetainDate.ToString();
            lbCreateddBy.Text=Detained.CreatedByUser.ToString();
            lbLID.Text=License.LicenseID.ToString();
            lBFineFees.Text=Detained.FineFees.ToString();
            lbTotalFees.Text = (Detained.FineFees + 15).ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an new application of type release 

            clsApplications Application = new clsApplications();
            Application.ApplicantPersonID = App.ApplicantPersonID;
            Application.ApplicationDate=DateTime.Now;
            Application.ApplicationTypeID = 5;
            Application.ApplicationStatus = 1; // new applicatoin 
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 15;
            Application.CreatedByUserID = Globals.CurrentUser.UserID;
            lbApplicatoinID.Text=Application.ApplicantPersonID.ToString();

            Application.Save();

            // Now Edit the 

            Detained.isReleased = 1; // change is to its been released 
            Detained.ReleaseDate = DateTime.Now;
            Detained.ReleasedByUserID = Globals.CurrentUser.UserID;
            Detained.ReleaseApplicatoinID = Application.ApplicationID;

            if (Detained.Save())
            {
                MessageBox.Show("Detained License Released Succussfully");
            }
            else
                MessageBox.Show("Detained License Failed to be released");

        }
    }
}
