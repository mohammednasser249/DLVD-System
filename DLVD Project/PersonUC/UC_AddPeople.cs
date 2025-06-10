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

        public UC_AddPeople(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
            if(_PersonID==-1)
            {
                _Mode = enMode.AddNew;
            }else
                _Mode = enMode.UpdateNew;
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
                return;
            }



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


        private void UC_AddPeople_Load(object sender, EventArgs e)
        {
            _LoadCountriesToComboBox();
            _LoadData();
        }

    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            if(Person ==null)
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
            }else
            {
                MessageBox.Show("Person Failed to be save");

            }


        }

        private void cmCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
