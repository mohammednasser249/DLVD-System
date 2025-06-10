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

        DataTable dt;

        // A function to Load the data of people to datatable then display it in the grid view 
        private void _GetAllPeople()
        {
            dt = clsPeopleBL.GetAllPeople();
            // Store the datatable in a grid view to display 
            dataGridView1.DataSource = dt;
            lbNumberOfRecrods.Text=dataGridView1.RowCount.ToString(); // Get number of rows 
            // Add first none to the combobox 
            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;
            // Adding other options to the combobox 
            foreach (DataColumn column in dt.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);

            }

        }


        // A function for researching when the textbox is changed 
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
            }else
            {
                if (int.TryParse(FilterText, out int numericValue)) // Check if input is a valid number
                {
                    PeopleView.RowFilter = $"[{FilterName}] = {numericValue}";
                }else
                    PeopleView.RowFilter = ""; // if invalid integer clear the filter to show all rows 

            }
            dataGridView1.DataSource = PeopleView; // Always rebind, even if empty
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
            if(cbFilter.SelectedIndex != 0)
            {
                _GetSearch(cbFilter.SelectedItem.ToString(), txtSearch.Text);

            }

        }
    }
}
