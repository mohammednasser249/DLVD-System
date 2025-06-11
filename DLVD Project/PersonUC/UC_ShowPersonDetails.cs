using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DLVD_Project.PersonUC
{
    public partial class UC_ShowPersonDetails : UserControl
    {

        int PersonID;
        public UC_ShowPersonDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form PrintForm = FindForm();
            PrintForm.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public  void LoadPersonIDToUserControl(int ID)
        {
            PersonID = ID;
            clsPeopleBL Person = clsPeopleBL.FindPerson(PersonID);
            if (Person == null)
            {
                MessageBox.Show("People Can not be found");
                return;
            }
            else
            {
                lbName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lbEmail.Text= Person.Email;
                lbPhone.Text= Person.Phone;
                lbAddress.Text = Person.Address;
                lbDOB.Text = Person.DOB.ToString();
                clsCountriesBL Country = clsCountriesBL.FindCountry((int)Person.NationalityCountryID);
                lbCountry.Text = Country.CountryName;
                lbNationalNo.Text = Person.NationalNo;
                lbPersonId.Text =Person.ID.ToString();
                if (pbPersonalPhoto != null)
                {
                    if (pbPersonalPhoto.Image != null)
                    {
                        pbPersonalPhoto.Image.Dispose();
                    }

                    if (!string.IsNullOrWhiteSpace(Person.ImagePath))
                    {
                        pbPersonalPhoto.Image = new Bitmap(Person.ImagePath);
                    }
                    else
                    {
                        // Optionally set a default image or clear the PictureBox
                        pbPersonalPhoto.Image = null;
                        // or use a placeholder image:
                        // pbPersonalPhoto.Image = Properties.Resources.PlaceholderImage;
                    }
                }

                if (Person.Gender == 0)
                {
                    lbGender.Text = "Male";
                }
                else
                {
                    lbGender.Text = "Female";
                }



            }

        }



        private void UC_ShowPersonDetails_Load(object sender, EventArgs e)
        {




        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPeople frm = new frmAddPeople(PersonID);
            frm.ShowDialog();
        }
    }
}
