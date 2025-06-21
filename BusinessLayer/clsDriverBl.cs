using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDriver
    {

        enum enMode
        {
            Addnew,
            Update
        }

        enMode Mode;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.MinValue;
            Mode = enMode.Addnew;
        }

        public clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Mode = enMode.Update;
        }


        private bool _AddNewDriverBL()
        {
            this.DriverID = clsDriverDL.AddNewDriverDL(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            if (this.DriverID != -1)
            {
                return true;
            }
            else
                return false;
        }

        public static int GetDriverId(int personID)
        {
            return clsDriverDL.GetDriverIDDL(personID);
        }


        public bool Save()
        {

            if(_AddNewDriverBL())
                return true;
            return false;
        }

    }
}