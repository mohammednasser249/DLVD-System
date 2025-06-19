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
    public partial class frmMakeAWrittenTest : Form
    {

        int LID;
        int TID;
        public frmMakeAWrittenTest(int testID,int lid)
        {
            InitializeComponent();
            LID = lid;
            TID = testID;
        }

        private void frmMakeAWrittenTest_Load(object sender, EventArgs e)
        {
            uC_WrittenTest1._LoadData(TID, LID);
        }
    }
}
