﻿using DLVD_Project.PersonUC;
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
    public partial class frmCurrentUserInfoForm : Form
    {
     


        public frmCurrentUserInfoForm()
        {
           InitializeComponent();
           uC_ShowPersonDetails1.LoadPersonIDToUserControl(Globals.CurrentUser.PersonID);
        }

        private void frmCurrentUserInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
