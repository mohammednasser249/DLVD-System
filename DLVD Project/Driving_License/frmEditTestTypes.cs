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
    public partial class frmEditTestTypes : Form
    {
        int TID;
        clsTestTypesBL Test = new clsTestTypesBL();
        public frmEditTestTypes(int TestID)
        {
            InitializeComponent();
            TID = TestID;
        }

        private void _LoadData()
        {
             Test = clsTestTypesBL.FindTestByID(TID);
            if (Test == null) {
                MessageBox.Show("Was not found");
                return;
              }

            lbID.Text = Test.TestTypeID.ToString();
            txtTitle.Text =Test.TestTypeTitle.ToString();
            txtDescription.Text = Test.TestTypeDescription.ToString();
            txtFees.Text = Test.TestTypeFees.ToString();


        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Test.TestTypeTitle = txtTitle.Text;
            Test.TestTypeDescription = txtDescription.Text;
            Test.TestTypeFees = decimal.Parse(txtFees.Text);

            if (Test.Save())
            {
                MessageBox.Show("Data Was updated succussfully");
            }
            else
                MessageBox.Show("Data failed to be updated");


        }
    }
}
