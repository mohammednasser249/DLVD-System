using System;
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
        public frmMakeAVisionTests(int LicenceID)
        {
            InitializeComponent();
            ID = LicenceID;
        }

        private void frmMakeAVisionTests_Load(object sender, EventArgs e)
        {
            uC_VisoinTest1._LoadData(ID);
        }
    }
}
