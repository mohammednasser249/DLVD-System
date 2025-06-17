using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
namespace DLVD_Project.Driving_License
{
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }


        private void _GetAllApplicationTypes()
        {
            DataTable dt = clsApplicationTypesBl.GetAllApplicationTypes();
            dataGridView1.DataSource = dt;
            lbNumberOfRecrods.Text =dt.Rows.Count.ToString();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].Width = 100;  // First column
            dataGridView1.Columns[1].Width = 280;  // Second column

        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            _GetAllApplicationTypes();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _GetAllApplicationTypes();
        }
    }
}
