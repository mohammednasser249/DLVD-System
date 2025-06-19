using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestBL
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public int TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        // Default constructor
        public clsTestBL()
        {
        }

        // Parameterized constructor
        public clsTestBL(int testID, int testAppointmentID, int testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }

        public static clsTestBL FindTestByID(int testID)
        {
            int TestAppointmentID = 0;
           int  TestResult =0;
           string Notes = "";
           int CreatedByUserID = 0;

            if(clsTestDL.FindTestByID(testID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
                return  new clsTestBL (testID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return null;
        }


        private bool _AddNewTest()
        {
            this.TestID = clsTestDL.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            if(this.TestID!=-1)
                return true;
            return false;
        }


        public bool Save()
        {

            if (_AddNewTest())
                return true;
            return false;
        }
    }
}
