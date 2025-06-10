using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public class clsCountriesDL
    {

        public static bool FindCountryID(int CID , ref string CountryName)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"select *
                           from Countries
                           where CountryID=@CID";
            
            SqlCommand cmd = new SqlCommand(query, conn);

            bool isfound = false;
            cmd.Parameters.AddWithValue("@CID", CID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CountryName = reader["CountryName"].ToString();
                    isfound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isfound;


        }

        public static bool FindCountryName(ref int CID,  string CountryName)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"select *
                           from Countries
                           where CountryName=@CountryName";

            SqlCommand cmd = new SqlCommand(query, conn);

            bool isfound = false;
            cmd.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CID = (int)(reader["CountryID"]);
                    isfound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isfound;


        }

        
        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"select *
                from Countries";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
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
