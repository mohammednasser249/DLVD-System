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
    public partial class frmEditApplicationType : Form
    {
        int APPID;
        clsApplicationTypesBl Application = new clsApplicationTypesBl();
        public frmEditApplicationType(int ApplicationID)
        {
            InitializeComponent();
            APPID = ApplicationID;
        }

        private void _LoadData()
        {
             Application = clsApplicationTypesBl.FindApplicationTypeByID(APPID);
            if (Application == null)
            {
                MessageBox.Show("Was not found");
                return;
            }

            // Load data back to the fileds 
            lbID.Text = Application.ApplicationID.ToString();
            txtTitle.Text = Application.ApplicationTitle.ToString();
            txtFees.Text = Application.ApplicationFees.ToString();

        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Application.ApplicationTitle = txtTitle.Text;
            Application.ApplicationFees = decimal.Parse(txtFees.Text);
            if (Application.Save())
            {
                MessageBox.Show("Updated Succssfully");

            }
            else
                MessageBox.Show("Failed to be updated");
        }
    }
}
