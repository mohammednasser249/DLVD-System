using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDrivingLicnseViewBl
    {

        public int LocalDrivingLicenseApplicationID { get; set; }
        public string ClassName { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PassedTestCount { get; set; }
        public string Status { get; set; }

        // Default constructor
        public clsLocalDrivingLicnseViewBl()
        {
            LocalDrivingLicenseApplicationID = 0;
            ClassName = "";
            NationalNo = "";
            FullName = "";
            ApplicationDate = DateTime.MinValue;
            PassedTestCount = 0;
            Status = "";
        }

        // Parameterized constructor
        public clsLocalDrivingLicnseViewBl(int id, string className, string nationalNo, string fullName,
                                                 DateTime applicationDate, int passedTestCount, string status)
        {
            LocalDrivingLicenseApplicationID = id;
            ClassName = className;
            NationalNo = nationalNo;
            FullName = fullName;
            ApplicationDate = applicationDate;
            PassedTestCount = passedTestCount;
            Status = status;
        }

        public static clsLocalDrivingLicnseViewBl FindByLicenseID(int licenseID)
        {
            // Variables to be filled by Data Layer
            string className = "";
            string nationalNo = "";
            string fullName = "";
            DateTime applicationDate = DateTime.MinValue;
            int passedTestCount = 0;
            string status = "";

            // Call the Data Layer method
            bool isFound = clsclsLocalDrivingLicnseViewDl.FindByID(
                licenseID,
                ref className,
                ref nationalNo,
                ref fullName,
                ref applicationDate,
                ref passedTestCount,
                ref status
            );

            if (isFound)
            {
                return new clsLocalDrivingLicnseViewBl(
                    licenseID,
                    className,
                    nationalNo,
                    fullName,
                    applicationDate,
                    passedTestCount,
                    status
                );
            }

            // Not found
            return null;
        }





    }
}
