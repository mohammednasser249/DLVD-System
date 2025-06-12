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

        clsUserBL User;
        public UCLoginInfo()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        enum enMode
        {
            AddNew,Update
        }

        enMode Mode;

      
       
        public bool LoadDataBack(int ID)
        {
            User.PersonID = ID;
            User.UserName = txtUserName.Text;
            if (txtPassword.Text == txtConfirmPassword.Text)
                User.Password = txtPassword.Text;

            if (cbActive.Checked == true)
                User.isActive = 1;
            else
                User.isActive = 0;

            bool isadded = false;
            if (User.Save())
            {
                MessageBox.Show("Data Saved Succussfully");
                lbUserID.Text = User.UserID.ToString();
                isadded = true;

            }
            else
            {
                MessageBox.Show("Data Failed to be saved ");

            }
            return isadded;
        }


        public bool _LoadDataBackForUpdate(int ID)
        {
             User = clsUserBL.FindUserById(ID);
            if(User==null)
            {
                MessageBox.Show("User was not found");
                return false;
            }
            lbUserID.Text=User.UserID.ToString();
            txtPassword.Text = User.Password;
            txtConfirmPassword.Text = User.Password;
            txtUserName.Text = User.UserName;
            
            
            if (User.isActive == 1)
                cbActive.Checked = true;
            else
                cbActive.Checked = false;

            Mode = enMode.Update;

            return true;
              




        }

        public bool _LoadPersonIDAndSaveUser(int ID)
        {
            if (Mode == enMode.AddNew)
            {
                User = new clsUserBL();
                PersonID = ID;
            }

            return LoadDataBack(ID);


        }



        private void UCLoginInfo_Load(object sender, EventArgs e)
        {

        }

        private void lbUserID_Click(object sender, EventArgs e)
        {

        }
    }
}
