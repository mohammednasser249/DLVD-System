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

            SqlCommand cmd = new SqlCommand(qurey,conn);

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

        public static int AddNewUserDL(int PersonID , string UserName , string Password , int IsActive)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"insert into Users(PersonID,UserName,Password,IsActive)
                            values(@PersonID,@UserName,@Password,@IsActive)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query,conn);

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

    }
}
