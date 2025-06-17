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
    public class clsTestTypeDL
    {


        public static DataTable GetAllTestTypesDL()
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            DataTable dt = new DataTable();

            string qurey = @"select *
                        from TestTypes";

            SqlCommand cmd = new SqlCommand(qurey, conn);

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

        public static bool FindTestType(int testTypeID,ref  string testTypeTitle, ref string testTypeDescription,ref decimal testTypeFees)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            bool isfouned = false;
            string query = @"select *
                from TestTypes
                where TestTypeID =@testTypeID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isfouned = true;
                    testTypeTitle = (string)reader["TestTypeTitle"];
                    testTypeDescription = (string)reader["TestTypeDescription"];
                    testTypeFees = (decimal)reader["TestTypeFees"];


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
            return isfouned;


        }


        public static bool UpdateTestTypeDL(int testTypeID,  string testTypeTitle,  string testTypeDescription,  decimal testTypeFees)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"update TestTypes
            set TestTypeTitle =@testTypeTitle , TestTypeDescription =@testTypeDescription , TestTypeFees =@testTypeFees
                        where TestTypeID =@testTypeID";

            SqlCommand cmd = new SqlCommand(query, conn);
            bool isupdated = false;
            cmd.Parameters.AddWithValue("@testTypeID", testTypeID);
            cmd.Parameters.AddWithValue("@testTypeTitle", testTypeTitle);
            cmd.Parameters.AddWithValue("@testTypeDescription", testTypeDescription);

            cmd.Parameters.AddWithValue("@testTypeFees", testTypeFees);


            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    isupdated = true;
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
            return isupdated;

        }
    }
}
