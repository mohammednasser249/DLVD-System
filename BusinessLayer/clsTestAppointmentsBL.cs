using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestAppointmentsBL
    {

        enum enMode
        {
            AddNew,
            Update
        }

        enMode Mode;
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        // Default constructor
        public clsTestAppointmentsBL()
        {
            TestAppointmentID = 0;
            TestTypeID = 0;
            LocalDrivingLicenseApplicationID = 0;
            AppointmentDate = DateTime.MinValue;
            PaidFees = 0.0m;
            CreatedByUserID = 0;
            IsLocked = false;
            Mode = enMode.AddNew;
        }



        // Parameterized constructor
        public clsTestAppointmentsBL(int testAppointmentID, int testTypeID, int localAppID,
                                   DateTime appointmentDate, decimal paidFees,
                                   int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            Mode = enMode.Update;
        }


        public static clsTestAppointmentsBL FindById(int  testAppointmentID)
        {
            int TestTypeID = 0;
            int LocalDrivingLicenseApplicationID = 0;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0.0m;
            int CreatedByUserID = 0;
            bool IsLocked = false;

            if(clsTestAppointmentsDL.FindTestAppointmentDL(testAppointmentID,ref TestTypeID,ref LocalDrivingLicenseApplicationID,ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked))
            {
                return new clsTestAppointmentsBL(testAppointmentID, TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked);
            }
            else
                return null;

        }


        public static int isExist(int LicenceID)
        {
            return clsTestAppointmentsDL.CountDL(LicenceID);
        }

        public static DataTable GetVisionTestAppointemnts(int LicenceID)
        {
            return clsTestAppointmentsDL.GetVisionTestAppointemntsDl(LicenceID) ;      
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsDL.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
            if (this.TestAppointmentID != -1)
            {
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;


            }
            return false ;
        }


    }
}
