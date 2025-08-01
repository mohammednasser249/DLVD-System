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

namespace DLVD_Project.PersonUC
{
    public partial class UC_AddPeople : UserControl
    {

        int _PersonID;
        enum enMode
        {
            AddNew,
            UpdateNew
        }
        string ImagePath;

        enMode _Mode;

        clsPeopleBL Person;

        public UC_AddPeople()
        {
            InitializeComponent(); // This is required for the designer to work
        }

        public UC_AddPeople(int ID)
        {
            InitializeComponent();
           

        }

        // Set a photo function 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Dispose previous image to avoid memory leak
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }   

                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    ImagePath = ofd.FileName;
                }
            }
        }


        


        // LoadDataFunction
        private void _LoadData()
        {
            

            if (_Mode == enMode.AddNew)
            {
                Person = new clsPeopleBL(); // create new object to fill it later 
                _Mode = enMode.UpdateNew;
                lbTitle.Text = "Add New Person";
                return;
            }

            // Edit mode 

            // Find the person by its ID to display its info 

            Person = clsPeopleBL.FindPerson(_PersonID);
            // Check if person exist 
            if (Person == null)
            {
                MessageBox.Show("Person was not found ");
                return;
            }
            lbTitle.Text = "Update Person";
            

            //Filling the data 

           lbPersonID.Text = Person.ID.ToString();
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;

            if (Person.Gender == 0)
                rdMale.Checked = true;
            else
                rdFemale.Checked = true;

            txtAddress.Text = Person.Address;
            txtNationalNo.Text = Person.NationalNo;
            txtEmail.Text = Person.Email;
            txtPhone.Text = Person.Phone;
            dateTimePicker1.Value = Person.DOB;

            clsCountriesBL Country = clsCountriesBL.FindCountry(Person.NationalityCountryID);
            cbCountries.SelectedItem = Country.CountryName;

            ImagePath = Person.ImagePath;
            pictureBox1.ImageLocation = ImagePath;

        }

        // Load All countries to the combo box 
        private void _LoadCountriesToComboBox()
        {
            DataTable dt = clsCountriesBL.GetAllCountriesBL();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
             
            cbCountries.SelectedIndex = 0;

        }


        public void LoadPerson(int id)
        {
            _PersonID = id;
            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.UpdateNew;// Set mode to update
            _LoadData();               // Load data based on _PersonID
        }



        private void UC_AddPeople_Load(object sender, EventArgs e)
        {

            _LoadCountriesToComboBox();
            // User at least should be 18 years old 
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            // _LoadData();
        }





        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Find the parentForm who used this user control
            if (parentForm != null)
            {
                parentForm.Close(); // or DialogResult = Cancel if shown with ShowDialog()
            }
            else
            {
                MessageBox.Show("Parent form not found.");
            }

        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {

        }


        // Save button to save all the data to the database 
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Invalid inputs");
                return;

            }
              


            if (Person ==null)
            {
                MessageBox.Show("Error the object is null");
                return;
            }
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            if (rdMale.Checked)
                Person.Gender = 0;
            else 
                Person.Gender = 1;
            Person.Address = txtAddress.Text;
            Person.NationalNo = txtNationalNo.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            Person.DOB = dateTimePicker1.Value;
            // Use the findcountry by name first get its object then get its id to store it in the people table 
            Person.ImagePath = ImagePath;
            clsCountriesBL Country = clsCountriesBL.FindCountryByNameBL(cbCountries.SelectedItem.ToString());
            Person.NationalityCountryID =(int) Country.CountryID;
            


            if (Person.Save())
            {
                MessageBox.Show("Person Saved Succssfully");
                lbPersonID.Text=Person.ID.ToString();
                lbTitle.Text = "Update Person";
                lbPersonID.Text = Person.ID.ToString();

            }else
            {
                MessageBox.Show("Person Failed to be save");

            }
        }

        private void cmCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;    
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "Please enter your FirstName! ");
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Please enter your txtSecondName! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecondName, null);
            }
        }

        private void txtThirdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                e.Cancel = true;
                txtThirdName.Focus();
                errorProvider1.SetError(txtThirdName, "Please enter your SecondName! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtThirdName, null);
            }

        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Please enter your LastName! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "Please enter your NationalNo! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void panel2_Validating(object sender, CancelEventArgs e)
        {
            if (!rdMale.Checked && !rdFemale.Checked)
            {
                e.Cancel = true;
                errorProvider1.SetError(panel2, "Please select a gender.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(panel2, "");
            }

        }

      

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Please enter your Address! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Please enter your Phone! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
         
            
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {


            pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Projects\DLVD\Images\LoginImages\user.png");

        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Projects\DLVD\Images\AddPeopleImages\admin_female.png");


        }

        private void lbPersonID_Click(object sender, EventArgs e)
        {

        }
    }
}
