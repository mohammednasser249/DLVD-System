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

namespace DLVD_Project.UserUC
{
    public partial class UCLoginCurrentUserInfo : UserControl
    {
        public UCLoginCurrentUserInfo()
        {
            InitializeComponent();
        }

        private void UCLoginCurrentUserInfo_Load(object sender, EventArgs e)
        {
            clsUserBL User = clsUserBL.FindUserById(Globals.CurrentUser.UserID);
            if (User == null)
            {
                return;
            }
            lbUserID.Text = User.UserID.ToString();
            lbUserName.Text = User.UserName.ToString();
            if (User.isActive == 0)
                lbIsActive.Text = "No";
            else
                lbIsActive.Text = "Yes";   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
