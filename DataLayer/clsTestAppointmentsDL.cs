using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DataLayer
{
    public class clsTestAppointmentsDL
    {


        public static int CountDL(int LID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select COUNT(*)
from TestAppointments
where LocalDrivingLicenseApplicationID=@LID and TestTypeID=1 ";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@LID", LID);
            int Number = -1;

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Total))
                {
                    Number = Total;
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
            return Number;

        }


        public static DataTable GetVisionTestAppointemntsDl(int LID)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);
            string query = @"select *
from TestAppointments
where LocalDrivingLicenseApplicationID=@LID and TestTypeID=1 ";

            DataTable dt = new DataTable(); 
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LID", LID);

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




        public static int AddNewTestAppointment(
            int testTypeID,
            int localDrivingLicenseApplicationID,
            DateTime appointmentDate,
            decimal paidFees,
            int createdByUserID,
            bool isLocked
        )
        {
            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            INSERT INTO TestAppointments
            (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
            VALUES
            (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);

            SELECT SCOPE_IDENTITY(); -- Returns the last inserted identity
        ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                cmd.Parameters.AddWithValue("@IsLocked", isLocked);

                int id = -1;

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if( result != null && int.TryParse(result.ToString(),out int ID ))
                    {
                        id= ID;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error inserting and retrieving TestAppointmentID", ex);
                }
                return id;
            }
        }


        public static bool FindTestAppointmentDL(int testAppointmentID, ref int testTypeID, ref int localDrivingLicenseApplicationID, ref DateTime appointmentDate, ref decimal paidFees, ref int createdByUserID, ref bool isLocked)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select *
from TestAppointments
where LocalDrivingLicenseApplicationID=@testAppointmentID"; 

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            bool isfounded = false;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    testTypeID = (int)reader["TestTypeID"];
                    localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (Decimal)reader["PaidFees"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
                    isfounded = true;
                    
                }
                reader.Close();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return isfounded;

        }





    }

}
