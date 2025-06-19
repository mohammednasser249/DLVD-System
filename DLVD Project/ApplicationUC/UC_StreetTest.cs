using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DLVD_Project.ApplicationUC
{
    public partial class UC_StreetTest : UserControl
    {
        clsLocalDrivingLicnseViewBl View = new clsLocalDrivingLicnseViewBl();
        clsTestAppointmentsBL Test;
        int LID;

        public UC_StreetTest()
        {
            InitializeComponent();
        }

      
        public void _LoadData(int TestAppoitnemntID, int licenceID)
        {
            // if new application 

            View = clsLocalDrivingLicnseViewBl.FindByLicenseID(licenceID);

            lbApplicatoinId.Text = View.LocalDrivingLicenseApplicationID.ToString();
            lbName.Text = View.FullName.ToString();
            lbClass.Text = View.ClassName.ToString();
            lbTrial.Text = clsTestAppointmentsBL.isExistTest3(licenceID).ToString();
            if (lbTrial.Text == "0")
                gbRetake.Enabled = false;
            else
                gbRetake.Enabled = true;

            LID = View.LocalDrivingLicenseApplicationID;

            if (TestAppoitnemntID == -1)
            {
                Test = new clsTestAppointmentsBL();
                Test.PaidFees = 35; // intial fees 
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                // Find the application info an fill them 

                /*
                dateTimePicker1.Text = View.ApplicationDate.ToString();
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                */


                if (lbTrial.Text == "0")
                    gbRetake.Enabled = false;
                else
                {
                    gbRetake.Enabled = true;
                    lbTitle.Text = "Retake Test";
                    Test.PaidFees += 5;
                }

                return;
            }


            Test = clsTestAppointmentsBL.FindById(TestAppoitnemntID);

            if (Test == null)
            {
                MessageBox.Show("Was not found");
                return;
            }

            dateTimePicker1.Text = Test.AppointmentDate.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";





        }

        private void UC_StreetTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test.TestTypeID = 3;
            Test.LocalDrivingLicenseApplicationID = LID;
            Test.AppointmentDate = dateTimePicker1.Value;

            Test.CreatedByUserID = Globals.CurrentUser.UserID;
            Test.IsLocked = false;


            if (Test.Save())
            {
                MessageBox.Show("Data Saved Succussfully");
                lbTestID.Text = Test.TestAppointmentID.ToString();
            }
            else
                MessageBox.Show("Data Failed to be save ");
        }
    }
}
