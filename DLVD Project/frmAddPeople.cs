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
        int PersonId = 0;
        public frmAddPeople(int personId)
        {
            InitializeComponent();
            PersonId = personId;
            if (PersonId != 0 && PersonId != -1)  // Check for valid ID
            {
                uC_AddPeople1.LoadPerson(PersonId);
            }
            else
            {
                // If adding new person, you can still call LoadPerson with -1 or handle accordingly
                uC_AddPeople1.LoadPerson(-1);
            }


        }

        private void frmAddPeople_Load(object sender, EventArgs e)
        {

        }

        
    }
}
