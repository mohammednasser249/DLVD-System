using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLVD_Project
{
    public partial class frmShowDetails : Form
    {
        int PersonID;
        public frmShowDetails(int personID)
        {
            InitializeComponent();
            PersonID = personID;
            uC_ShowPersonDetails1.LoadPersonIDToUserControl(PersonID); // Load personId to the usercontrol
        }

        private void uC_ShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void frmShowDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
