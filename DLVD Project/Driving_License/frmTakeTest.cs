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
    public partial class frmTakeTest : Form
    {
        int TestId;
        public frmTakeTest(int testid)
        {
            InitializeComponent();
            TestId = testid;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            uC_TakeTest1._LoadData(TestId);
        }
    }
}
