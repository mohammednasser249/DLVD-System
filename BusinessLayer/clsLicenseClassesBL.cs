using DataLayer;
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

    }
}
