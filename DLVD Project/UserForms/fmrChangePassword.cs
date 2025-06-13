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

namespace DLVD_Project.UserForms
{
    public partial class fmrChangePassword : Form
    {
        public fmrChangePassword()
        {
            InitializeComponent();
        }


        private bool _CheckInformation(string currentpassword, string newpassword, string confirmpassword)
        {

            if (currentpassword == Globals.CurrentUser.Password.ToString() && newpassword == confirmpassword)
            {

                return true;
            }
            return false;
        }
        private void fmrChangePassword_Load(object sender, EventArgs e)
        {
            uC_ShowPersonDetails1.LoadPersonIDToUserControl(Globals.CurrentUser.PersonID);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_CheckInformation(txtCurrnetPassword.Text, txtNewPassword.Text, txtConfirmPassword.Text))
            {
                // ChangePassword function 
                clsUserBL.ChangePasswordBL(Globals.CurrentUser.UserID,txtNewPassword.Text);


                // Update the currnet User password
                 Globals.CurrentUser.Password = txtNewPassword.Text;

                MessageBox.Show("Password  updated succssfully");

            }
            else
            {
                MessageBox.Show("Failed to update the password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
