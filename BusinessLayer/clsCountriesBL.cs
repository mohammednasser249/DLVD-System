using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsCountriesBL
    {

        public int CountryID {  get; set; }
        public string CountryName { get; set; } 


        clsCountriesBL (int CID , string CountryName)
        {
            CountryID = CID;
            this.CountryName = CountryName;
        }

        public static clsCountriesBL FindCountry(int CID )
        {
            string CName =""; 

            if(clsCountriesDL.FindCountryID(CID, ref CName))
            {
                return new clsCountriesBL(CID, CName);
            }else
                return null;
        }
        public static clsCountriesBL FindCountryByNameBL( string Name)
        {
            int CID = 0;

            if (clsCountriesDL.FindCountryName(ref CID, Name))
            {
                return new clsCountriesBL(CID, Name);
            }
            else
                return null;
        }


        public static DataTable GetAllCountriesBL()
        {
            return clsCountriesDL.GetAllCountries();
        }

    }
}
