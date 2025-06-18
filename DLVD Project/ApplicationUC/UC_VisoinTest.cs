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
    public partial class UC_VisoinTest : UserControl
    {
        clsLocalDrivingLicnseViewBl View = new clsLocalDrivingLicnseViewBl();
        clsTestAppointmentsBL Test = new clsTestAppointmentsBL();
        int LID;

        public UC_VisoinTest()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void _LoadData(int licenceID)
        {

             View = clsLocalDrivingLicnseViewBl.FindByLicenseID(licenceID);

            if (View == null)
            {
                MessageBox.Show("Was not found");
                return;
            }

           

            lbApplicatoinId.Text = View.LocalDrivingLicenseApplicationID.ToString();    
            lbName.Text = View.FullName.ToString();
            lbClass.Text = View.ClassName.ToString();
            dateTimePicker1.Text = View.ApplicationDate.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            lbTrial.Text = clsTestAppointmentsBL.isExist(licenceID).ToString();
            if(lbTrial.Text=="0")
                gbRetake.Enabled = false;
            else
            gbRetake.Enabled = true;

            LID=View.LocalDrivingLicenseApplicationID;





        }


        public void _LoadTestData (int licenceID)
        {
            

        }
        private void UC_VisoinTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test.TestTypeID = 1;
            Test.LocalDrivingLicenseApplicationID = LID;
            Test.AppointmentDate = dateTimePicker1.Value;
            Test.PaidFees = 10;
            Test.CreatedByUserID = Globals.CurrentUser.UserID;
            Test.IsLocked = false;


            if(Test.Save())
            {
                MessageBox.Show("Data Saved Succussfully");
            }else
                MessageBox.Show("Data Failed to be save ");

        }
    }
}
