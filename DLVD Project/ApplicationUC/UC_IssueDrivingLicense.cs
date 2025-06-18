using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DLVD_Project.ApplicationUC
{

    
    
    public partial class UC_IssueDrivingLicense : UserControl
    {


       public clsApplications Application = new clsApplications();

        public int PersonID;
        public UC_IssueDrivingLicense()
        {
            InitializeComponent();
        }


    

        public void _FillComboBox()
        {
            DataTable dt = clsLicenseClassesBL.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row[1].ToString()); 
                comboBox1.SelectedIndex = 0;
            }

        }

        public  void LoadDataNewLicense(int ApplicantId)
        {
           
            // Check if person exists 
            clsPeopleBL Person = clsPeopleBL.FindPerson(ApplicantId);
            if (Person == null)
            {
                MessageBox.Show("was not found");
                return;
            }





            Application.ApplicantPersonID = ApplicantId;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 1; // always one since this is a new license 
            Application.ApplicationStatus = 1;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 15;
            Application.CreatedByUserID = Globals.CurrentUser.UserID;


            Application.Save(); // saving in the application table 
      

            // Create local application object and fill it 

            clsLocalDrivingLicenseApplicationsBL localLicense = new clsLocalDrivingLicenseApplicationsBL();

            localLicense.ApplicationId = int.Parse(Application.ApplicationID.ToString());
            localLicense.LicenseClassID = comboBox1.SelectedIndex + 1;

            // Check if this perosn have an application
            // 
            if(clsLocalDrivingLicenseApplicationsBL.IsExist(ApplicantId, localLicense.LicenseClassID)!=-1)
            {
                MessageBox.Show($"Choose another license class , the selected person already have an active application for the selected class with id ={Application.ApplicationID} ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
          

            if (localLicense.Save())
            {
                MessageBox.Show("Saved succussfully");
                lbApplicatoinId.Text = localLicense.LocalDrivingLicenseApplicationID.ToString();

            }
            else
            {

                MessageBox.Show("Was not saved");
            }




        }

        private void UC_IssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            lbCreatedBy.Text = Globals.CurrentUser.UserName;
            lbApplicatoinDate.Text = DateTime.Now.ToString();
                
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
