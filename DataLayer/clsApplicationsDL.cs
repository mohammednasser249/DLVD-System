using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsApplicationsDL
    {


        public static int _AddNewApplicationDL(int PersonId, DateTime ApplicationDate, int ApplicationTypeID,
                                         int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"
        INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        VALUES (@PersonId, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);

        SELECT SCOPE_IDENTITY();
    ";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            int newID = -1;
            try
            {
                conn.Open();
                // ExecuteScalar returns the identity (new ApplicationID)
                newID = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                // Log or handle the error here if needed
                throw new Exception("Error while inserting application: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newID;
        }



        public static int IsExist(int personid, int applicationtype)
        {
            int applicationId = -1;

            string query = @"
        SELECT ApplicationID
        FROM Applications
        WHERE ApplicantPersonID = @personid AND ApplicationTypeID = @applicationtype";

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@personid", personid);
                command.Parameters.AddWithValue("@applicationtype", applicationtype);

                try
                {
                    conn.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                        applicationId = id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return applicationId;
        }






    }
}