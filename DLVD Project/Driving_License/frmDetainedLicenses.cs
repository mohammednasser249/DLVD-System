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
    public partial class frmDetainedLicenses : Form
    {
        public frmDetainedLicenses()
        {
            InitializeComponent();
        }
        DataTable dt;

        private void _GetAllDetainedLicenses()
        {

            dt = clsDetainedLicensesBl.GetAllDetainedLicenses();

            dataGridView1.DataSource= dt;

            dataGridView1.AllowUserToAddRows = false;
            lbNumberOfRecrods.Text=dt.Rows.Count.ToString();
            dataGridView1.Columns[7].Width = 200;

        }
        private void _GetSearch(string FilterName, string FilterText)
        {
            DataView PeopleView = dt.DefaultView;

            // Check the column type to apply filter 
            bool isStringCol = dt.Columns[FilterName].DataType == typeof(string);

            if (isStringCol)
            {
                if (string.IsNullOrEmpty(FilterText))
                {
                    PeopleView.RowFilter = ""; // Clear the filter to show all rows
                }
                else
                {
                    FilterText = FilterText.ToString();
                    PeopleView.RowFilter = $"[{FilterName}] LIKE '{FilterText}%'";
                }
            }
            else
            {
                if (int.TryParse(FilterText, out int numericValue)) // Check if input is a valid number
                {
                    PeopleView.RowFilter = $"[{FilterName}] = {numericValue}";
                }
                else
                    PeopleView.RowFilter = ""; // if invalid integer clear the filter to show all rows 

            }
            dataGridView1.DataSource = PeopleView; // Always rebind, even if empty
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;

            foreach (DataColumn column in dt.Columns)
            {
                cbFilter.Items.Add((string)column.ColumnName);
            }
        }
        private void frmDetainedLicenses_Load(object sender, EventArgs e)
        {
            _GetAllDetainedLicenses();
            _FillComboBox();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
            }else
                txtSearch.Visible = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                _GetSearch(cbFilter.SelectedItem.ToString(), txtSearch.Text);
                lbNumberOfRecrods.Text = dataGridView1.RowCount.ToString(); // Get number of rows 

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
