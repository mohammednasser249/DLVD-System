﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLVD_Project.Driving_License
{
    public partial class frmMakeAVisionTests : Form
    {
        int ID;
        int TID;
        public frmMakeAVisionTests(int TestID,int LicenceID)
        {
            InitializeComponent();
            ID = LicenceID;
            TID = TestID;
        }

        private void frmMakeAVisionTests_Load(object sender, EventArgs e)
        {
            uC_VisoinTest1._LoadData(TID,ID);
        }
    }
}
