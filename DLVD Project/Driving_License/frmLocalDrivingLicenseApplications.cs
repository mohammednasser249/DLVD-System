﻿using System;
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
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        DataTable dt = new DataTable();
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }


        private void _GetAllLocalDrivingLicnseApplications()
        {

            dt = clsLocalDrivingLicenseApplicationsBL.GetLocalDrivingLicenseApplications();
            dataGridView1.DataSource = dt;
            lbNumberOfRecrods.Text = dt.Rows.Count.ToString();

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;


        }

        private void _FillComboBox()
        {

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("L.D.LAppID");
            cbFilter.Items.Add("National No");
            cbFilter.Items.Add("Full Name");
            cbFilter.Items.Add("Status");

            cbFilter.SelectedIndex = 0;

            if (cbFilter.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
            }


        }


                private void Search(string FilterName, string FilterText)
                {


                DataView dv = dt.DefaultView;

            // Check the column type to apply filter 
            bool isStringCol = dt.Columns[FilterName].DataType == typeof(string);

            if (isStringCol)
            {
                if (string.IsNullOrEmpty(FilterText))
                {
                    dv.RowFilter = ""; // Clear the filter to show all rows
                }
                else
                {
                    FilterText = FilterText.ToString();
                    dv.RowFilter = $"[{FilterName}] LIKE '{FilterText}%'";
                }
            }
            else
            {
                if (int.TryParse(FilterText, out int numericValue)) // Check if input is a valid number
                {
                    dv.RowFilter = $"[{FilterName}] = {numericValue}";
                }
                else
                    dv.RowFilter = ""; // if invalid integer clear the filter to show all rows 

            }
            dataGridView1.DataSource = dv; // Always rebind, even if empty
            lbNumberOfRecrods.Text = dataGridView1.RowCount.ToString();

        }



        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            _GetAllLocalDrivingLicnseApplications();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
            {

                Search("LocalDrivingLicenseApplicationID", txtSearch.Text);
            }
            else if (cbFilter.SelectedIndex == 2)
            {
                Search("NationalNo", txtSearch.Text);
            }
            else if (cbFilter.SelectedIndex == 3)
            {
                Search("FullName", txtSearch.Text);
            }
            else if (cbFilter.SelectedIndex == 4)
            {
                Search("Status", txtSearch.Text);
            }

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex != 0)
            {
                txtSearch.Visible = true;
            }

        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel this application ?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplicationsBL.CancelApplication((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application has been cancelled ");
                    _GetAllLocalDrivingLicnseApplications();
                }
                else
                    MessageBox.Show("Application has failed to be cancelled ");

            }

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this application ?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplicationsBL.DeleteApplicationBL((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application has been Deleted ");
                    _GetAllLocalDrivingLicnseApplications();
                }
                else
                    MessageBox.Show("Application has failed to be cancelled ");

            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {


                frmVisionTestAppointemtns frm = new frmVisionTestAppointemtns((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            _GetAllLocalDrivingLicnseApplications();
     
            
        }

        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicnseViewBl View = clsLocalDrivingLicnseViewBl.FindByLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);

           

        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWrittenTestAppointments frm = new frmWrittenTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _GetAllLocalDrivingLicnseApplications();

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStreetTestAppointments frm = new frmStreetTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _GetAllLocalDrivingLicnseApplications();


        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _GetAllLocalDrivingLicnseApplications();
        
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicnseViewBl View = clsLocalDrivingLicnseViewBl.FindByLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplicationsBL LocalApplication = clsLocalDrivingLicenseApplicationsBL.FindbyID((int)dataGridView1.CurrentRow.Cells[0].Value);



            if (View.PassedTestCount == 0)
            {
                scheduleTestToolStripMenuItem.Enabled = true;

                visionTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;


            }


            if (View.PassedTestCount == 1)
            {
                scheduleTestToolStripMenuItem.Enabled = true;

                visionTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;



            }
            if (View.PassedTestCount == 2)
            {
                scheduleTestToolStripMenuItem.Enabled = true;

                visionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;




            }

            if (View.PassedTestCount == 3)

            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;  

            }


            if (clsLicenseBL.IsThereAlicenceForApplicatoin(LocalApplication.ApplicationId))
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;   
            }else
            {
                showLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenesHistory frm = new frmLicenesHistory((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }

}