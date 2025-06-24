using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{


    public class clsLicenseBL
    {
        enum enMode
        {
            AddNew,
            Update
        }

        enMode Mode;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }



        public clsLicenseBL()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = null;
            PaidFees = 0.0m;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;
            Mode = enMode.AddNew;
        }

        public clsLicenseBL(int licenseID, int applicationID, int driverID, int licenseClass,
                       DateTime issueDate, DateTime expirationDate, string notes,
                       decimal paidFees, bool isActive, int issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }


        // Find function 

        public static clsLicenseBL FindLicnseInfoByApplicationID(int ApplicationID)
        {
           int licenseid = 0;
            int DriverID = 0;
           int  LicenseClass = 0;
           DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
           string Notes = null;
            decimal PaidFees = 0.0m;
           bool IsActive = false;
           int IssueReason = 0;
          int  CreatedByUserID = 0;

            if(clsLicenseDL.FindDl(ref licenseid,   ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes,ref PaidFees,ref IsActive,ref IssueReason,ref CreatedByUserID))
            {
                return new clsLicenseBL(licenseid, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            return null;



        }

        public static clsLicenseBL FindByD(int LicenseID)
        {
            int ApplicatoinID = 0;
            int DriverID = 0;
            int LicenseClass = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = null;
            decimal PaidFees = 0.0m;
            bool IsActive = false;
            int IssueReason = 0;
            int CreatedByUserID = 0;

            if (clsLicenseDL.FindLicenseDl(LicenseID, ref ApplicatoinID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenseBL(LicenseID, ApplicatoinID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            return null;



        }


        // check if there is licence for a specific application 

        public static bool IsThereAlicenceForApplicatoin(int ApplicationId)
        {


            return clsLicenseDL.IsThereAlicenceForApplicatoinDL(ApplicationId);


        }

        // Get All local Licnses 

        public static DataTable GetAllLocalLicnses(int ID)
        {
          return  clsLicenseDL.GetAllLocalLicnsesDL(ID);
        }



        private bool _AddNewLicence()
        {
            this.LicenseID = clsLicenseDL.AddNewLicenceDL(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            if (this.LicenseID != -1)
                return true;
            return false;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseDL.UpdateLicenseDL(this.LicenseID,this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }


        public bool Save()
        {

            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLicence())
                    {
                        
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLicense();
                

            }

            
            return false;
        }



    }


    }

