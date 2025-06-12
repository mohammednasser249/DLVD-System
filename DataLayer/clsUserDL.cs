using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsUserDL
    {

        public static DataTable GetAllUsersDL()
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            DataTable dataTable = new DataTable();

            string qurey = @"select U.UserID,U.PersonID,FullName =P.FirstName +' '+P.SecondName+' '+P.ThirdName +' '+P.LastName , U.UserName,U.IsActive
                            from Users U , People P
                            where U.PersonID = P.PersonID";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

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

        public static int AddNewUserDL(int PersonID, string UserName, string Password, int IsActive)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"insert into Users(PersonID,UserName,Password,IsActive)
                            values(@PersonID,@UserName,@Password,@IsActive)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int UID = 0;

            try
            {
                conn.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int personID))
                {
                    UID = personID;
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

            return UID;


        }


        public static bool DeleteUser(int UserID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"delete from Users Where UserID =@UserID";

            SqlCommand cmd = new SqlCommand(qurey, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            bool isdeleted = false;
            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
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
                conn.Close();
            }
            return isdeleted;
        }

        public static bool FindUserByIDDL(int userID, ref int personId, ref string username, ref string password, ref int isActive)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = "SELECT PersonID, UserName, Password, IsActive FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personId = Convert.ToInt32(reader["PersonID"]);
                            username = reader["UserName"].ToString();
                            password = reader["Password"].ToString();
                            isActive = Convert.ToInt32(reader["IsActive"]);
                            isFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in FindUserByIDDL: " + ex.Message);
                }
            }

            return isFound;
        }


        public static bool UpdateUserDL(int UserID, string Username, string Password, int IsActive)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);
            string qurey = @"update Users
            set UserName= @Username , Password =@Password , IsActive = @IsActive
            where UserID =@UserID";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            bool isupdated = false;

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
