﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLicenseClassesBL
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClassesBL()
        {
        }

        public clsLicenseClassesBL(int licenseClassID, string className, string classDescription,
                               int minimumAllowedAge, int defaultValidityLength, decimal classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }


        public static DataTable GetAllLicenseClasses()
        {

            return clsLicenseClassDl.GetAllLicenseClassesDL();
        }

        public static int GetDefaultValidLength(int licenceid)
        {
           return clsLicenseClassDl.GetDefaultValidLength(licenceid);
        }


        public static string GetClassName(int ClassID)
        {
            string Classname = "";

            if (clsLicenseClassDl.GetClassNameDl(ref Classname, ClassID))
            {
                return Classname;
            }
            else
                return "";
        }

        public static decimal GetClassFees(int ClassID)
        {
            decimal ClassFees = 0;

            if (clsLicenseClassDl.GetClassFeesDl(ref ClassFees, ClassID))
            {
                return ClassFees;
            }
            else
                return -1;
        }


    }
}
