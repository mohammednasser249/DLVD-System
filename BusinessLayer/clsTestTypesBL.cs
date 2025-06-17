using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestTypesBL
    {

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }

        public decimal TestTypeFees {  get; set; }

        public clsTestTypesBL(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }


        public clsTestTypesBL()
        {

        }



        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeDL.GetAllTestTypesDL();
        }

        public static clsTestTypesBL FindTestByID(int id)
        {
            string TestType = "";
            string TestTypeDesc = "";
            decimal TestFees = 0;

            if(clsTestTypeDL.FindTestType(id,ref TestType,ref TestTypeDesc,ref TestFees))
            {
                return new clsTestTypesBL(id,TestType,TestTypeDesc,TestFees);
            }
            return null;

        }


        private bool _UpdateTestType()
        {
            if (clsTestTypeDL.UpdateTestTypeDL(this.TestTypeID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees))
            {
                return true;
            }
            return false;
        }

        public bool Save()
        {

            if(_UpdateTestType())
                return true;
            return false;

        }




    }
}
