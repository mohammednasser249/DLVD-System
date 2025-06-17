using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationTypesBl
    {

      
        public int ApplicationID {  get; set; }
        public string ApplicationTitle{ get; set; }

        public decimal ApplicationFees{ get; set; }

        public clsApplicationTypesBl()
        {

        }
        clsApplicationTypesBl(int applicationID, string applicationTitle, decimal applicationFees)
        {
            ApplicationID = applicationID;
            ApplicationTitle = applicationTitle;
            ApplicationFees = applicationFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDL.GetAllApplicationTypesDL();
        }

        public static clsApplicationTypesBl FindApplicationTypeByID(int id)
        {
            string AppTitle = "";
            decimal Appfees = 0;

            if(clsApplicationTypesDL.FindAppTypeByIdDL(id,ref AppTitle,ref Appfees ))
            {
                return new clsApplicationTypesBl(id, AppTitle, Appfees);
            }else
                return null;

        }


        private bool _UpdateApplicationType()
        {
            if(clsApplicationTypesDL.UpdateApplicationDL(this.ApplicationID,this.ApplicationTitle,this.ApplicationFees))
                return true;
            return false;

        }

        public bool Save()
        {
            if(_UpdateApplicationType())
                return true;
            else
                return false;

        }

    }
}
