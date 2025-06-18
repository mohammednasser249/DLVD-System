using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsLocalDrivingLicenseApplicationsDL
    {

        public static DataTable GetAllLicenseDrivingLocalApplications()
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            DataTable dataTable = new DataTable();

            string query = @"select *
                        from LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);

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
            return dataTable;


        }


        public static int AddLocalDrivingLicsnse(int applicationID , int LicenseID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                VALUES (@applicationID, @LicenseID)
                Select Scope_Identity()";

            SqlCommand cmd = new SqlCommand(qurey,conn);

            cmd.Parameters.AddWithValue("@applicationID", applicationID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            int ID = -1;

            try
            {
                conn.Open();
               object result = cmd.ExecuteScalar(); 

                if(result != null && int.TryParse(result.ToString(),out int id))
                {
                    ID = id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            conn.Close(); }
        return ID;
        
        }


        public static int IsExist(int personid, int LicenseID)
        {
            int applicationId = -1;

            string query = @"select L.LocalDrivingLicenseApplicationID
from LocalDrivingLicenseApplications L , Applications A , People P, LocalDrivingLicenseApplications_View LV
where L.ApplicationID=A.ApplicationID and A.ApplicantPersonID = P.PersonID and L.LicenseClassID=@LicenseID
and A.ApplicantPersonID=@personid  and LV.Status='New' and Lv.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
";

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@personid", personid);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

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


        public static bool CancelApplication(int ApplicationID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);


            string query = @"update A 
set A.ApplicationStatus=2
from Applications A , LocalDrivingLicenseApplications L
where A.ApplicationID =L.ApplicationID and L.LocalDrivingLicenseApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, conn);

            bool isupdated = false;

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0) {
                    isupdated = true;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

           }
        
        return isupdated;
        
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"delete from LocalDrivingLicenseApplications
where LocalDrivingLicenseApplicationID =@ApplicationID";


            SqlCommand command = new SqlCommand(qurey, conn);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool isdeleted = false;

            try
            {
                conn.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    isdeleted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

          }
        return isdeleted;
        
        }

        }

        }

    


