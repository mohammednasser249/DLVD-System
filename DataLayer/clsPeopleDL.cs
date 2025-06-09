using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsPeopleDL
    {


        public static DataTable GetAllPeopleDL()
        {

            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select P.PersonID , P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,P.LastName,P.Gendor,C.CountryName,P.Phone,P.Email
                                from People P , Countries C
                                where P.NationalityCountryID=C.CountryID";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                    dt.Load(reader);
            

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

    }
}
