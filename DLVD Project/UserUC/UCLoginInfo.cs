using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DLVD_Project.UserUC
{
    public partial class UCLoginInfo : UserControl
    {
        int PersonID;
        public UCLoginInfo()
        {
            InitializeComponent();
        }
        public void _LoadPersonIDAndSaveUser(int ID)
        {
            PersonID = ID;
            clsUserBL User = new clsUserBL();

            User.PersonID = PersonID;
            User.UserName = txtUserName.Text;
            if(txtPassword.Text==txtConfirmPassword.Text) 
            User.Password = txtPassword.Text;

            if (cbActive.Checked == true)
                User.isActive = 1;
            else 
                User.isActive = 0;

            if(User.Save())
            {
                MessageBox.Show("Data Saved Succussfully");
            }
            {
                MessageBox.Show("Data Failed to be saved ");

            }


        }


     
        private void UCLoginInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
