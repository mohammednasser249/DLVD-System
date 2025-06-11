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


    }
}
