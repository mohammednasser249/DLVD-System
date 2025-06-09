using System;
using DataLayer;
using System.Data.SqlClient;

namespace DataLayer
{
    public class clsLoginDL
    {

        public static bool LoginDL(string Username , string Password )
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select *
                            from Users
                            where UserName =@Username and Password =@Password and IsActive = 1";
            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);

            bool IsFound = false;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return IsFound;

        }





    }
}
