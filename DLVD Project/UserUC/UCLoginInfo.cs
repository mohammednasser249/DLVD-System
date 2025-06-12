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
        public bool _LoadPersonIDAndSaveUser(int ID)
        {
            clsUserBL User = new clsUserBL();
            PersonID = ID;

            User.PersonID = PersonID;
            User.UserName = txtUserName.Text;
            if(txtPassword.Text==txtConfirmPassword.Text) 
            User.Password = txtPassword.Text;

            if (cbActive.Checked == true)
                User.isActive = 1;
            else 
                User.isActive = 0;

            bool isadded = false;
            int UID;
            if((UID = User.Save())!=-1)
            {
                MessageBox.Show("Data Saved Succussfully");
                lbUserID.Text = UID.ToString();
                isadded = true;
                
            }else
            {
                MessageBox.Show("Data Failed to be saved ");

            }
            return isadded;

        }


     
        private void UCLoginInfo_Load(object sender, EventArgs e)
        {

        }

        private void lbUserID_Click(object sender, EventArgs e)
        {

        }
    }
}
