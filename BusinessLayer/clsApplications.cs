using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplications
    {

        enum enMode
        {
            AddNew,
            Update
        }

        enMode Mode;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        // Default constructor (initializes fields to default values)
        public clsApplications()
        {
            ApplicationID = 0;
            ApplicantPersonID = 0;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeID = 0;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserID = 0;
            Mode = enMode.AddNew;
        }

        // Parameterized constructor
        public clsApplications(int applicationID, int applicantPersonID, DateTime applicationDate,
                               int applicationTypeID, int applicationStatus, DateTime lastStatusDate,
                               int paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;

        }


        private  bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDL._AddNewApplicationDL(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            if (this.ApplicationID!=-1)
            {
                return true;
            }
            return false;

        }

    }

}
