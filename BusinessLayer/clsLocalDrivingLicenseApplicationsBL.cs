using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplicationsBL
    {

       public int LocalDrivingLicenseApplicationID {  get; set; }

        public int ApplicationId { get; set; }  

        public int LicenseClassID { get; set; }

        // Default Constructor 

        public clsLocalDrivingLicenseApplicationsBL()
        {
            LocalDrivingLicenseApplicationID = 0;
            ApplicationId = 0;
            LicenseClassID = 0;
        }

        public clsLocalDrivingLicenseApplicationsBL(int localid ,int  appid , int licenceid)
        {
            LocalDrivingLicenseApplicationID = localid;
            ApplicationId = appid;
            LicenseClassID = licenceid;
        }

        // Find 

        public static clsLocalDrivingLicenseApplicationsBL FindbyID(int id)
        {
            int ApplicationID = 0;
            int LicenseClassID = 0;

            if (clsLocalDrivingLicenseApplicationsDL.FindByIDDL(id,ref  ApplicationID,ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplicationsBL(id,ApplicationID, LicenseClassID);
            }
            return null;

        }


        public static DataTable GetLocalDrivingLicenseApplications()
        {

            return clsLocalDrivingLicenseApplicationsDL.GetAllLicenseDrivingLocalApplications();


        }

        private bool _AddNewLocalDrivingLicense()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDL.AddLocalDrivingLicsnse(this.ApplicationId,this.LicenseClassID);
            if (this.LocalDrivingLicenseApplicationID != -1)
                return true;
            else
                return false;
            
        }

        public static int IsExist(int personid, int applicationType)
        {
            int ID = clsLocalDrivingLicenseApplicationsDL.IsExist(personid, applicationType);
            if (ID != -1)
                return ID;
            return -1;
        }


        

        public bool Save()
        {

            if(_AddNewLocalDrivingLicense())
            {
                return true;
            }
            return false;

        }

        public static bool CancelApplication(int ApplicationId)
        {
            return clsLocalDrivingLicenseApplicationsDL.CancelApplication(ApplicationId);
        }

        public static bool DeleteApplicationBL(int ApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsDL.DeleteApplication(ApplicationID);
        }


    }
}
