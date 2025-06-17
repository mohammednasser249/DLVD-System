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
    public partial class frmTestTypes : Form
    {
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void _GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            dt = clsTestTypesBL.GetAllTestTypes();
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 500;
            dataGridView1.Columns[3].Width = 100;
            lbNumberOfRecrods.Text = dataGridView1.RowCount.ToString(); 
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _GetAllTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes frmEditTestTypes = new frmEditTestTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmEditTestTypes.ShowDialog();
            _GetAllTestTypes();
        }
    }
}
