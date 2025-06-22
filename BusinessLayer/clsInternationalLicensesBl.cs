using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsInternationalLicensesBl
    {
     
            enum enMode
            {
            AddNew,
            Update
            }

        enMode Mode;
            public int InternationalLicenseID { get; set; }
            public int ApplicationID { get; set; }
            public int DriverID { get; set; }
            public int IssuedUsingLocalLicenseID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public int CreatedByUserID { get; set; }

            // Default constructor
            public clsInternationalLicensesBl()
            {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            IsActive = true;
            CreatedByUserID = -1;
            Mode=enMode.AddNew;
            }

            // Parameterized constructor
            public clsInternationalLicensesBl(int internationalLicenseID, int applicationID, int driverID,
                                           int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
                                           bool isActive, int createdByUserID)
            {
                InternationalLicenseID = internationalLicenseID;
                ApplicationID = applicationID;
                DriverID = driverID;
                IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
                IssueDate = issueDate;
                ExpirationDate = expirationDate;
                IsActive = isActive;
                CreatedByUserID = createdByUserID;
            Mode=enMode.Update;
            }


        private bool _AddNewInterationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesDL._AddNewInterationalLicenseDL(this.ApplicationID, this.DriverID,this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.CreatedByUserID);
            if (this.InternationalLicenseID != -1)
                return true;
            else return false;

        }

        public static DataTable GetAllInternationalLicnses(int ID)
        {
            return clsInternationalLicensesDL.GetAllInternationalLicnsesDL(ID);
        }

        public static bool isExist(int ID)
        {
            return clsInternationalLicensesDL.isExistDL(ID);
        }


        public bool Save()
        {
            if(_AddNewInterationalLicense())
                return true;    
            return false;

        }
            


        }

   
}
