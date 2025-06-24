using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsDetainedLicensesDL
    {


        public static bool clsDetainedLicensesDl(int LicenseID)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID and IsReleased=0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (optional)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isFound;
        }

public static bool FindByLicsenseDL(int licensesID, ref int  detainedID , ref DateTime detainDate, ref decimal fineFees, ref int createdByUser, ref int isReleased, ref DateTime releaseDate, ref int releasedByUserID, ref int releaseApplicatoinID)
{
    bool isfound = false;

    using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
    {
        string query = @"
            SELECT * 
            FROM DetainedLicenses 
            WHERE LicenseID = @licensesID and IsReleased=0";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@licensesID", licensesID);

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                detainedID = Convert.ToInt32(reader["DetainID"]);

                detainDate = reader["DetainDate"] != DBNull.Value ? Convert.ToDateTime(reader["DetainDate"]) : DateTime.MinValue;
                fineFees = reader["FineFees"] != DBNull.Value ? Convert.ToDecimal(reader["FineFees"]) : 0;
                createdByUser = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : -1;
                isReleased = reader["IsReleased"] != DBNull.Value ? Convert.ToInt32(reader["IsReleased"]) : 0;
                releaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                releasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
                releaseApplicatoinID = reader["ReleaseApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                        isfound = true;
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    return isfound;
}


        public static int AddnewDetainedLicenseDL(int licensesID, DateTime detainDate, decimal fineFees, int createdByUser, int isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicatoinID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"insert into  DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID)
values (@licensesID,@detainDate,@fineFees,@createdByUser,@isReleased,@releaseDate,@releasedByUserID,@releaseApplicatoinID) select scope_identity()";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@licensesID", licensesID);
            cmd.Parameters.AddWithValue("@detainDate", detainDate);
            cmd.Parameters.AddWithValue("@fineFees", fineFees);
            cmd.Parameters.AddWithValue("@createdByUser", createdByUser);
            cmd.Parameters.AddWithValue("@isReleased", isReleased);
            cmd.Parameters.AddWithValue("@releaseDate", releaseDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@releasedByUserID", releasedByUserID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@releaseApplicatoinID", releaseApplicatoinID ?? (object)DBNull.Value);

            int ID = -1;
            try
            {
                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ID = id;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return ID;
        }


        public static bool UpdateDetailedLicenseDL(int DetainID, int licensesID, DateTime detainDate, decimal fineFees, int createdByUser, int isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicatoinID)
        {
            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            UPDATE DetainedLicenses
            SET 
                LicenseID = @licensesID,
                DetainDate = @detainDate,
                FineFees = @fineFees,
                CreatedByUserID = @createdByUser,
                IsReleased = @isReleased,
                ReleaseDate = @releaseDate,
                ReleasedByUserID = @releasedByUserID,
                ReleaseApplicationID = @releaseApplicatoinID
            WHERE DetainID = @DetainID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@licensesID", licensesID);
                cmd.Parameters.AddWithValue("@detainDate", detainDate);
                cmd.Parameters.AddWithValue("@fineFees", fineFees);
                cmd.Parameters.AddWithValue("@createdByUser", createdByUser);
                cmd.Parameters.AddWithValue("@isReleased", isReleased);
                cmd.Parameters.AddWithValue("@releaseDate", releaseDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@releasedByUserID", releasedByUserID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@releaseApplicatoinID", releaseApplicatoinID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // true if at least one row updated
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


    }
}
