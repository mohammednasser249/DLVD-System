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

namespace DLVD_Project.ApplicationUC
{
    public partial class UC_LicenseHist : UserControl
    {
        DataTable dt = new DataTable();
        int id;
        public UC_LicenseHist()
        {
            InitializeComponent();
        }
        public void _LoadDataLocalLiecens(int LID)
        {
            id = LID;
            dt = clsLicenseBL.GetAllLocalLicnses(LID);
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToAddRows = false;
            lbNumberOfRecrods.Text = dt.Rows.Count.ToString();
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[5].Width = 130;
        }

        public void _LoadDataInternationalLiecens(int LID)
        {
            id = LID;
            dt = clsInternationalLicensesBl.GetAllInternationalLicnses(LID);
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToAddRows = false;
            lbNumberOfRecrods.Text = dt.Rows.Count.ToString();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UC_LicenseHist_Load(object sender, EventArgs e)
        {
            _LoadDataLocalLiecens(id);

        }

        private void internationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadDataInternationalLiecens(id);
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadDataLocalLiecens(id);

        }
    }
}
