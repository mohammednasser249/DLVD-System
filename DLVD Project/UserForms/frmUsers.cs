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
    public partial class frmUsers : Form
    {
        DataTable dt = new DataTable();
        public frmUsers()
        {
            InitializeComponent();
        }


        private void _GetAllUsers()
        {

             dt =clsUserBL.GetAllUsers();
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[2].Width = 220;   



        }

        private void _FillSearchComboBox()
        {
            dt = clsUserBL.GetAllUsers();

            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;

            foreach (DataColumn col in dt.Columns)
            {
                cbFilter.Items.Add(col.ColumnName);

            }


        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
             _FillSearchComboBox();
            _GetAllUsers(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void _GetSearch(string FilterName, string FilterText)
        {
            DataView UserView = dt.DefaultView;

            // Check the column type to apply filter 
            bool isStringCol = dt.Columns[FilterName].DataType == typeof(string);

            if (isStringCol)
            {
                if (string.IsNullOrEmpty(FilterText))
                {
                    UserView.RowFilter = ""; // Clear the filter to show all rows
                }
                else
                {
                    FilterText = FilterText.ToString();
                    UserView.RowFilter = $"[{FilterName}] LIKE '{FilterText}%'";
                }
            }
            else
            {
                if (int.TryParse(FilterText, out int numericValue)) // Check if input is a valid number
                {
                    UserView.RowFilter = $"[{FilterName}] = {numericValue}";
                }
                else
                    UserView.RowFilter = ""; // if invalid integer clear the filter to show all rows 

            }
            dataGridView1.DataSource = UserView; // Always rebind, even if empty
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                _GetSearch(cbFilter.SelectedItem.ToString(), txtSearch.Text);
                lbNumberOfRecrods.Text = dataGridView1.RowCount.ToString(); // Get number of rows 

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddUsersMDI frmAddUsersMDI = new frmAddUsersMDI();
            frmAddUsersMDI.ShowDialog();
        }
    }
}
