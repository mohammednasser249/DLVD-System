using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDetainedLicensesBl
    {


        enum enMode
        {
            AddNew,
            Update
        }

        enMode Mode;
        public int DetainedID { get; set; }
        public int LicensesID { get; set; }

        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }

        public int CreatedByUser { get; set; }
        public int isReleased { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicatoinID { get; set; }


        public clsDetainedLicensesBl()
        {
            DetainedID = -1;
            LicensesID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0m;
            CreatedByUser = -1;
            isReleased = 0; // 0 for not released, 1 for released
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicatoinID = -1;
            Mode = enMode.AddNew;

        }

        public clsDetainedLicensesBl(int detainedID, int licensesID, DateTime detainDate, decimal fineFees, int createdByUser, int isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicatoinID)
        {
            DetainedID = detainedID;
            LicensesID = licensesID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUser = createdByUser;
            this.isReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicatoinID = releaseApplicatoinID;
            Mode = enMode.Update;
        }

        public static bool isLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesDL.clsDetainedLicensesDl(LicenseID);
        }


        private bool _AddNewDetainedLicsnse()
        {

            this.DetainedID = clsDetainedLicensesDL.AddnewDetainedLicenseDL(this.LicensesID, this.DetainDate, this.FineFees, this.CreatedByUser, this.isReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicatoinID);

            if (this.DetainedID != -1)
            {
                return true;
            }
            return false;

        }


        private bool _UpdateDetainedLicsnes()
        {

            if (clsDetainedLicensesDL.UpdateDetailedLicenseDL(this.DetainedID, this.LicensesID, this.DetainDate, this.FineFees, this.CreatedByUser, this.isReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicatoinID))
            {

                return true;
            }
            return false;
        }

    
           
           public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesDL.GetAllDetainedLicensesDL();
        }
        

        public static clsDetainedLicensesBl FindByLicenseID(int LicenseID)
        {
          int DetainedID = 0;
          DateTime DetainDate = DateTime.Now;
          decimal FineFees = 0m;
          int  CreatedByUser = -1;
          int isReleased = 0;
          DateTime ReleaseDate = DateTime.Now;
          int ReleasedByUserID = 0;
          int ReleaseApplicatoinID = 0;

            if(clsDetainedLicensesDL.FindByLicsenseDL(LicenseID,ref DetainedID, ref DetainDate, ref FineFees,ref CreatedByUser,ref isReleased,ref ReleaseDate,ref ReleasedByUserID,ref ReleaseApplicatoinID))
            {
                return new clsDetainedLicensesBl(DetainedID, LicenseID, DetainDate, FineFees, CreatedByUser,isReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicatoinID);
            }
            return null;    


        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicsnse())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateDetainedLicsnes();
                    break;
            }
            return false;









        }
    }
}