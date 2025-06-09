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

namespace DLVD_Project
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }


        // A function to Load the data of people to datatable then display it in the grid view 
        private void _GetAllPeople()
        {
            DataTable dt = clsPeopleBL.GetAllPeople();
            dataGridView1.DataSource = dt;
            lbNumberOfRecrods.Text=dataGridView1.RowCount.ToString();
            // Add first none to the combobox 
            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;
            // Adding other options to the combobox 
            foreach (DataColumn column in dt.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);

            }

        }

       



        private void frmPeople_Load(object sender, EventArgs e)
        {
            _GetAllPeople();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
            }else
            {
                txtSearch.Visible = true;

            }

        }
    }
}
