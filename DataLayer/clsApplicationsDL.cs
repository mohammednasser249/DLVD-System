using System;
using System.Collections.Generic;
using System.Data;
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





        public static bool FindApplicationByLicenseIDDL(
    int licenseID,
    ref int applicationID,
    ref int applicantPersonID,
    ref DateTime applicationDate,
    ref int applicationTypeID,
    ref int applicationStatus,
    ref DateTime lastStatusDate,
    ref int paidFees,
    ref int createdByUserID
)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            SELECT A.ApplicationID, A.ApplicationStatus, A.PaidFees,
                   A.ApplicationTypeID, A.ApplicantPersonID,
                   A.ApplicationDate, A.LastStatusDate, A.CreatedByUserID
            FROM Applications A, LocalDrivingLicenseApplications L
            WHERE A.ApplicationID = L.ApplicationID
              AND L.LocalDrivingLicenseApplicationID = @LicenseID;
        ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationID = Convert.ToInt32(reader["ApplicationID"]);
                        applicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                        paidFees = Convert.ToInt32(reader["PaidFees"]);
                        applicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                        applicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                        applicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                        lastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                        createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error finding application by LicenseID", ex);
                }
            }

            return isFound;
        }

        public static bool FindByIDDL(
int licenseID,
ref int applicationID,
ref int applicantPersonID,
ref DateTime applicationDate,
ref int applicationTypeID,
ref int applicationStatus,
ref DateTime lastStatusDate,
ref int paidFees,
ref int createdByUserID
)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
select *
from Applications
where ApplicationID=@licenseID
";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                        paidFees = Convert.ToInt32(reader["PaidFees"]);
                        applicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                        applicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                        applicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                        lastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                        createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error finding application by LicenseID", ex);
                }
            }

            return isFound;
        }





    }
}