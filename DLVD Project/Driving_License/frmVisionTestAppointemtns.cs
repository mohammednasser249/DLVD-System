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
            // Check first 
            clsTestAppointmentsBL App = clsTestAppointmentsBL.FindById(LicnseId);
            bool check;
            if (App == null)
            {
                check = true;
            }
            else
                check = App.IsLocked;

            if (check)
            {
                frmMakeAVisionTests frm = new frmMakeAVisionTests(LicnseId);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Person Already have an active appointment for this test , you can not add new appointment  ");
        }
    }
}
