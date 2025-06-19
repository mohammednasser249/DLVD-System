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
    public partial class frmTakeStreetTest : Form
    {
        int TestId;

        public frmTakeStreetTest(int testid)
        {
            InitializeComponent();
            TestId = testid;
        }

        private void frmTakeStreetTest_Load(object sender, EventArgs e)
        {
            uC_TakeStreetTest1._LoadData(TestId);
        }
    }
}
