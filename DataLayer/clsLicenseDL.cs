using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsLicenseDL
    {

        public static bool IsThereAlicenceForApplicatoinDL(int AppID)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select * 
                    from Licenses
                    where  ApplicationID=@AppID";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@AppID", AppID);
            bool isfound = false;

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
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

        public static int AddNewLicenceDL(int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, int issueReason, int createdByUserID)
        {
            int newID = -1;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"INSERT INTO Licenses(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                         VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                         SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
                cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);
                cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@IssueReason", issueReason);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    newID = Convert.ToInt32(result);
                }
            }

            return newID;
        }



        public static bool FindDl(ref int LicenseID,  int applicationID, ref int driverID, ref int licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref decimal paidFees, ref bool isActive, ref int issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"select *
from Licenses
where ApplicationID=@applicationID
";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@applicationID", applicationID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : null;
                    paidFees = (decimal)reader["PaidFees"];
                    isActive = (bool)reader["IsActive"];
                    issueReason = Convert.ToInt32(reader["IssueReason"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }

            return isFound;
        }

        public static bool FindLicenseDl( int LicenseID, ref int applicationID, ref int driverID, ref int licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref decimal paidFees, ref bool isActive, ref int issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection con = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"select *
from Licenses
where LicenseID=@LicenseID;
";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : null;
                    paidFees = (decimal)reader["PaidFees"];
                    isActive = (bool)reader["IsActive"];
                    issueReason = Convert.ToInt32(reader["IssueReason"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }

            return isFound;
        }
        public static DataTable GetAllLocalLicnsesDL(int ID)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select L.LicenseID,L.ApplicationID,Lc.ClassName,L.IssueDate,L.ExpirationDate,L.IsActive
from Licenses L , LicenseClasses Lc	,LocalDrivingLicenseApplications Lo , Applications A
where Lo.ApplicationID=L.ApplicationID and L.LicenseClass=Lc.LicenseClassID and A.ApplicationID =Lo.ApplicationID
and ApplicantPersonID=@ID";

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
                Console.WriteLine(ex.Message);
            }
            finally
            {

            conn.Close(); }
        
        return dt;
        }




    }
}
