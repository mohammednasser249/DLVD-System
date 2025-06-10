using DLVD_Project.PersonUC;
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
    public partial class frmAddPeople : Form
    {
        public frmAddPeople()
        {
            InitializeComponent();
        }

      

        private void uC_AddPeople1_Load(object sender, EventArgs e)
        {
            UC_AddPeople us = new UC_AddPeople(-1);

        }

        private void frmAddPeople_Load(object sender, EventArgs e)
        {

        }

        
    }
}
