using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsPeopleDL
    {


        public static DataTable GetAllPeopleDL()
        {

            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select P.PersonID , P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,P.LastName,Gender =

                                Case 
                                when P.Gendor =0 then 'Male'
                                else 'Female'
                                End 
                                ,C.CountryName,P.Phone,P.Email
                                 from People P , Countries C
                            where P.NationalityCountryID=C.CountryID";

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

        public static bool AddPersonDL( string NationalNo, string FirstName, string SecondName,
          string ThirdName, string LastName, int Gender,string Address, DateTime DateOfBirth,
           string Phone, string Email,int NationalityCountryID,string ImagePath)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);


            string query = @"INSERT INTO People(
                NationalNo, FirstName, SecondName, ThirdName, LastName, 
                DateOfBirth, Gendor, Address, Phone, Email, 
                NationalityCountryID, ImagePath)
               VALUES (
                @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, 
                @DateOfBirth, @Gender, @Address, @Phone, @Email, 
                @NationalityCountryID, @ImagePath)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

            bool IsAdded = false;
            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    IsAdded= true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return IsAdded;


        }



        public static bool FindPersonDL(int ID,ref string NationalNo, ref string FirstName,ref string SecondName,
          ref string ThirdName, ref string LastName, ref int Gender, ref string Address, ref DateTime DateOfBirth,
          ref  string Phone, ref string Email, ref int NationalityCountryID,ref string ImagePath)
        {


            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string query = @"
            SELECT NationalNo, FirstName, SecondName, ThirdName, LastName, Gendor, Address, 
                   DateOfBirth, Phone, Email, NationalityCountryID, ImagePath
            FROM People
            WHERE PersonID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);

            bool IsFound = false;
            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NationalNo = reader["NationalNo"]?.ToString();
                    FirstName = reader["FirstName"]?.ToString();
                    SecondName = reader["SecondName"]?.ToString();
                    ThirdName = reader["ThirdName"]?.ToString();
                    LastName = reader["LastName"]?.ToString();
                    Gender = Convert.ToInt32(reader["Gendor"]);
                    Address = reader["Address"]?.ToString();
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Phone = reader["Phone"]?.ToString();
                    Email = reader["Email"]?.ToString();
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = reader["ImagePath"]?.ToString();
                    IsFound = true;
                }
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
            return IsFound;


            }
    }
}
