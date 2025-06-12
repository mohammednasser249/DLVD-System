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

namespace DLVD_Project.UserUC
{
    public partial class UCAddUser : UserControl
    {

        public int PersonID;
        public UCAddUser()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("National NO");
            cbFilter.SelectedIndex = 0;
            cbFilter.Enabled = false;
        }

        private void _FillTheShowDetailsBasedOnNationalNo(string NationalNo)
        {

            DataTable dt = new DataTable();
            dt = clsPeopleBL.GetAllPeople();

            DataRow[] foundRows = dt.Select($"NationalNo = '{NationalNo}'");

            if (foundRows.Length > 0)
            {
                 PersonID = Convert.ToInt32(foundRows[0]["PersonID"]);
                uC_ShowPersonDetails1.LoadPersonIDToUserControl(PersonID);
            }
            else
            {
                MessageBox.Show("This person was not found.");
            }

        }

        private void UCAddUser_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _FillTheShowDetailsBasedOnNationalNo(txtSearch.Text);
        }

        private void uC_ShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddPeople frm = new frmAddPeople(0);
            frm.ShowDialog();
        }
    }
}
