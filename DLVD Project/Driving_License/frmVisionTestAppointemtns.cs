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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DLVD_Project.Driving_License
{
    public partial class frmVisionTestAppointemtns : Form
    {

        int LicnseId;

        public frmVisionTestAppointemtns(int Id)
        {

            InitializeComponent();
            LicnseId=Id;
        }

        private void _GetAllVisionTest(int ID)
        {

            DataTable dt = clsTestAppointmentsBL.GetVisionTestAppointemnts(ID);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void frmVisionTestAppointemtns_Load(object sender, EventArgs e)
        {
            uC_ApplicatoinBasicInfo1.LoadData(LicnseId);
            uC_DrivingLicenseAppInfo1._LoadData(LicnseId);
            _GetAllVisionTest(LicnseId);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clsTestAppointmentsBL App = null;
            if (dataGridView1.CurrentRow != null &&
     dataGridView1.CurrentRow.Cells[0].Value != null &&
     dataGridView1.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    App = clsTestAppointmentsBL.FindById(x);
            }

            bool check;
            if (App == null)
            {
                check = true;
            }
            else
                check = App.IsLocked;

            // Check for passing the test or not 

            clsTestBL Test = clsTestBL.FindTestByID(App.TestAppointmentID);

            bool check2 =true;
            if (Test.TestResult == 1)
                check2 = false;

       

            if (check && check2)
            {
                
                frmMakeAVisionTests frm = new frmMakeAVisionTests(-1,LicnseId);
                frm.ShowDialog();
                _GetAllVisionTest(LicnseId);
    
            }
            else if(check==false && check2==true)
                MessageBox.Show("Person Already have an active appointment for this test , you can not add new appointment  ");
            else
                MessageBox.Show("Person Already have passed this test  ");

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointmentsBL App = null;
            if (dataGridView1.CurrentRow != null &&
     dataGridView1.CurrentRow.Cells[0].Value != null &&
     dataGridView1.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                App = clsTestAppointmentsBL.FindById(x);
            }

            bool check;
            if (App == null)
            {
                check = true;
            }
            else
                check = App.IsLocked;

            if (!check)
            {
                frmMakeAVisionTests frm = new frmMakeAVisionTests((int)dataGridView1.CurrentRow.Cells[0].Value, LicnseId);
                frm.ShowDialog();
                _GetAllVisionTest(LicnseId);
            }
            else
                MessageBox.Show("implementing soon");

            // form of the person already has taken this test and it is locked 

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointmentsBL App = null;
            if (dataGridView1.CurrentRow != null &&
     dataGridView1.CurrentRow.Cells[0].Value != null &&
     dataGridView1.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                App = clsTestAppointmentsBL.FindById(x);
            }

            bool check;
            if (App == null)
            {
                check = true;
            }
            else
                check = App.IsLocked;

            // Check for passing the test or not 
            bool check2 = true;
            clsTestBL Test = clsTestBL.FindTestByID(App.TestAppointmentID);
            if (Test != null) {
                if (Test.TestResult == 1 || Test.TestResult == 0)
                    check2 = false;
            }

            if (check2)
            {
                frmTakeTest frm = new frmTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _GetAllVisionTest(LicnseId);
            }
            else
                MessageBox.Show("Person already has taken this test ");
                    
        }
    }
}
