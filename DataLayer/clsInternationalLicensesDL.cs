using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsInternationalLicensesDL
    {

        public static int _AddNewInterationalLicenseDL(int applicationId, int driverID, int issuedLocalLicenseID,
                                              DateTime issueDate, DateTime expirationDate, int createdByUserID)
        {
            int newID = -1;

            string query = @"
        INSERT INTO InternationalLicenses 
        (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
        VALUES (@ApplicationID, @DriverID, @IssuedLocalLicenseID, @IssueDate, @ExpirationDate, 1, @CreatedByUserID);
        SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@IssuedLocalLicenseID", issuedLocalLicenseID);
                cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        newID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                   Console.WriteLine("Error inserting license: " + ex.Message);
                }
            }

            return newID;
        }


        public static DataTable GetAllInternationalLicnsesDL(int ID)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            DataTable dt = new DataTable();

            string qurey = @"select I.InternationalLicenseID,A.ApplicationID,L.LicenseID,I.IssueDate,I.ExpirationDate,L.IsActive
	from InternationalLicenses I , Applications A , People P , Licenses L 
	where I.ApplicationID=A.ApplicationID and P.PersonID=A.ApplicantPersonID and L.DriverID=I.DriverID
	and P.PersonID=@ID";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static bool isExistDL(int ID)
        {
            bool exists = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            SELECT 1
            FROM InternationalLicenses I
            JOIN Applications A ON I.ApplicationID = A.ApplicationID
            JOIN People P ON P.PersonID = A.ApplicantPersonID
            JOIN Licenses L ON L.DriverID = I.DriverID
            WHERE P.PersonID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    exists = reader.HasRows; // returns true if at least one record exists
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                }
            }

            return exists;
        }


    }
}
