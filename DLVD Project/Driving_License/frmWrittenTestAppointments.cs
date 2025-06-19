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

namespace DLVD_Project.Driving_License
{
    public partial class frmWrittenTestAppointments : Form
    {
        int LicnseId;
        public frmWrittenTestAppointments(int iD)
        {
            InitializeComponent();
            LicnseId = iD;    
        }

        private void _GetAllWrittenTest(int ID)
        {

            DataTable dt = clsTestAppointmentsBL.GetWrittenTestAppointemnts(ID);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void frmWrittenTestAppointments_Load(object sender, EventArgs e)
        {
            uC_ApplicatoinBasicInfo1.LoadData(LicnseId);
            uC_DrivingLicenseAppInfo1._LoadData(LicnseId);
            _GetAllWrittenTest(LicnseId);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int x = -1;
            clsTestAppointmentsBL App = null;

            int lastRowIndex = dataGridView1.AllowUserToAddRows
                ? dataGridView1.Rows.Count - 2  // Skip the empty new row
                : dataGridView1.Rows.Count - 1;

            if (lastRowIndex >= 0 &&
                dataGridView1.Rows[lastRowIndex].Cells[0].Value != null &&
                dataGridView1.Rows[lastRowIndex].Cells[0].Value != DBNull.Value)
            {
                x = Convert.ToInt32(dataGridView1.Rows[lastRowIndex].Cells[0].Value);
                App = clsTestAppointmentsBL.FindById(x);
            }


            bool check;
            if (App == null)
            {
                check = true;
            }
            else
                check = App.IsLocked;
            clsTestBL Test = new clsTestBL();
            bool check2 = true;
            // Check for passing the test or not 
            if (dataGridView1.CurrentRow != null &&
     dataGridView1.CurrentRow.Cells[0].Value != null &&
     dataGridView1.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                Test = clsTestBL.FindTestByID(App.TestAppointmentID);

                if (Test != null)
                    if (Test.TestResult == 1)
                        check2 = false;
            }



            if (check && check2)
            {

                frmMakeAWrittenTest frm = new frmMakeAWrittenTest(-1, LicnseId);
                frm.ShowDialog();
                _GetAllWrittenTest(LicnseId);

            }
            else if (check == false && check2 == true)
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
                frmMakeAWrittenTest frm = new frmMakeAWrittenTest((int)dataGridView1.CurrentRow.Cells[0].Value, LicnseId);
                frm.ShowDialog();
                _GetAllWrittenTest(LicnseId);
            }
            else
                MessageBox.Show("Appointment is locked person already sat for this test");

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
            if (Test != null)
            {
                if (Test.TestResult == 1 || Test.TestResult == 0)
                    check2 = false;
            }

            if (check2)
            {
                frmTakeWrittenTest frm = new frmTakeWrittenTest((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _GetAllWrittenTest(LicnseId);
            }
            else
                MessageBox.Show("Person already has taken this test ");
        }
    }
}
