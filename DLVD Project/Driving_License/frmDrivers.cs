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
    public partial class frmDrivers : Form
    {

        DataTable dt = new DataTable();
        public frmDrivers()
        {
            InitializeComponent();
        }

        private void _GetAllDrivers()
        {
            dt = clsDriver.GetAllDrivers();
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToAddRows = false;
            lbNumberOfRecrods.Text=dt.Rows.Count.ToString();

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 200;


            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex= 0;  

        }

        private void _FillcomboBox()
        {

            foreach (DataColumn dt in dt.Columns)
            {
                cbFilter.Items.Add(dt.ColumnName);  
            }
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


        private void frmDrivers_Load(object sender, EventArgs e)
        {
            _GetAllDrivers();
            _FillcomboBox();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
            }
            else
            {
                txtSearch.Visible = true;

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                _GetSearch(cbFilter.SelectedItem.ToString(), txtSearch.Text);
                lbNumberOfRecrods.Text = dataGridView1.RowCount.ToString(); // Get number of rows 

            }

        }
    }
}
