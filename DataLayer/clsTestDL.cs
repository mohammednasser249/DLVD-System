using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsTestDL
    {

        public static int AddNewTest(int testAppointmentID, int testResult, string notes, int createdByUserID)
        {

            int newTestID = -1;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
            VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    cmd.Parameters.AddWithValue("@TestResult", testResult);
                    cmd.Parameters.AddWithValue("@Notes", notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out newTestID);
                    }
                }
            }

            return newTestID;



        }


        public static bool FindTestByID(int testID, ref int testAppointmentID, ref int testResult, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"
            SELECT *
            FROM Tests
            WHERE TestAppointmentID = @TestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestID", testID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            testAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                            testResult = Convert.ToInt32(reader["TestResult"]);
                            notes = reader["Notes"].ToString();
                            createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }



    }
}
