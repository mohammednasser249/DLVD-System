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
using static System.Net.Mime.MediaTypeNames;

namespace DLVD_Project.ApplicationUC
{
    public partial class UC_TakeStreetTest : UserControl
    {
        public UC_TakeStreetTest()
        {
            InitializeComponent();
        }

        clsLocalDrivingLicnseViewBl View = new clsLocalDrivingLicnseViewBl();
        clsTestAppointmentsBL Test = new clsTestAppointmentsBL();
        clsTestBL NewTest = new clsTestBL();

        public void _LoadData(int TestID)
        {

            int LicenceID = clsTestAppointmentsBL.FindById(TestID).LocalDrivingLicenseApplicationID;

            View = clsLocalDrivingLicnseViewBl.FindByLicenseID(LicenceID);

            lbApplicatoinId.Text = View.LocalDrivingLicenseApplicationID.ToString();
            lbName.Text = View.FullName.ToString();
            lbClass.Text = View.ClassName.ToString();
            lbTrial.Text = clsTestAppointmentsBL.isExistTest2(LicenceID).ToString();

            Test = clsTestAppointmentsBL.FindById(TestID);

            lbDate.Text = Test.AppointmentDate.ToString();

            // Create a new test 





        }

        private void UC_TakeStreetTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewTest.TestAppointmentID = Test.TestAppointmentID;
            if (rdPass.Checked)
                NewTest.TestResult = 1;
            else if (rdFail.Checked)
                NewTest.TestResult = 0;
            NewTest.Notes = txtNotes.Text;
            NewTest.CreatedByUserID = Globals.CurrentUser.UserID;

            if (NewTest.Save())
            {
                Test.IsLocked = true;
                Test.Save(); // to save it is locked and finished 
                MessageBox.Show("Saved Succussfully");
            }
            else
                MessageBox.Show("Failed to be saved");
        }
    }
}
