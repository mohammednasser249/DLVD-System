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
           
            clsPeopleBL Person = clsPeopleBL.FindPerson(ApplicantId);
            if (Person == null)
            {
                MessageBox.Show("was not found");
                return;
            }





            Application.ApplicantPersonID = ApplicantId;
            Application.ApplicationDate = DateTime.Now;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Application.ApplicationTypeID = 1;
                    break;
                case 1:
                    Application.ApplicationTypeID = 2;
                    break;
                case 2:
                    Application.ApplicationTypeID = 3;
                    break;
                case 3:
                    Application.ApplicationTypeID = 4;
                    break;
                case 4:
                    Application.ApplicationTypeID = 5;
                    break;
                case 5:
                    Application.ApplicationTypeID = 6;
                    break;
            }
            Application.ApplicationStatus = 1;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 15;
            Application.CreatedByUserID = Globals.CurrentUser.UserID;

            // Check if there is an applicatoin with the same info 
            int checkid = clsApplications.IsExist(ApplicantId, Application.ApplicationTypeID);
            if (checkid!=-1)
            {
                MessageBox.Show($"Choose another class , the selected person is already have an active application for the selected class with id = {checkid}  ");
                return;
            }
            

            if (Application.Save())
            {
                MessageBox.Show("Saved succussfully");
                lbApplicatoinId.Text = Application.ApplicationID.ToString();
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
