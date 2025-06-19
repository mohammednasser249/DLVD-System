using DLVD_Project.ApplicationUC;
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
    public partial class frmMakeStreetTest : Form
    {
        int LID;
        int TID;

        public frmMakeStreetTest(int testid , int licenceid)
        {
            InitializeComponent();
            LID =licenceid ;
            TID = testid;    
        }

        private void frmMakeStreetTest_Load(object sender, EventArgs e)
        {
            uC_StreetTest1._LoadData(TID, LID);
        }
    }
}
