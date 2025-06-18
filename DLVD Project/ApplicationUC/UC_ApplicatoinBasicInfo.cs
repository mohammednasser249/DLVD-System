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
    public partial class UC_ApplicatoinBasicInfo : UserControl
    {
        public UC_ApplicatoinBasicInfo()
        {
            InitializeComponent();
        }


        public void LoadData(int ID )
        {
            // find the licnce object with this id 

            clsApplications Application = clsApplications.FindApplicationByLicnceID(ID);



            //check if it is not null 

            if (Application == null)
            {
                MessageBox.Show("Was not found");
                return;
            }

            lbID.Text = Application.ApplicationID.ToString();
            lbStatus.Text = Application.ApplicationStatus.ToString();
            lbFees.Text = Application.PaidFees.ToString();
            lbType.Text = clsApplicationTypesBl.FindApplicationTypeByID(Application.ApplicationTypeID).ApplicationTitle;
            lbApplicant.Text = clsLocalDrivingLicnseViewBl.FindByLicenseID(ID).FullName.Trim();
            lbDate.Text = Application.ApplicationDate.ToString();   
            lbStatusDate.Text = Application.LastStatusDate.ToString();
            lbCreatedBy.Text = clsUserBL.FindUserById( Application.CreatedByUserID).UserName;



            // Start filling it in the textboxes 



        }

        private void UC_ApplicatoinBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
