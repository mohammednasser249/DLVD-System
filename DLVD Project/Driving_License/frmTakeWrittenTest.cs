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
    public partial class frmTakeWrittenTest : Form
    {
        int TestID;
        public frmTakeWrittenTest(int testID)
        {
            InitializeComponent();
            TestID = testID;    
        }

        private void frmTakeWrittenTest_Load(object sender, EventArgs e)
        {
            uC_TakeWrittenTest1._LoadData(TestID);
        }
    }
}
