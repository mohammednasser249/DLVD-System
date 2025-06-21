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
    public class clsDriverDL
    {

        public static int AddNewDriverDL(int PId, int createdbyid , DateTime createdtime)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"insert into Drivers(PersonID,CreatedByUserID,CreatedDate)
                values(@PId,@createdbyid,@createdtime) select scope_identity()";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            cmd.Parameters.AddWithValue("@PId", PId);
            cmd.Parameters.AddWithValue("@createdbyid", createdbyid);
            cmd.Parameters.AddWithValue("@createdtime", createdtime);
            int ID = -1;

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ID = id;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            conn.Close(); }
        
        return ID;
        
        }


        public static int GetDriverIDDL(int PersonID)
        {
            int driverID = -1;

            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
            {
                string query = @"SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    driverID = Convert.ToInt32(result);
                }
            }

            return driverID;
        }

        public static DataTable GetAllDriversDL()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select *
                    from Drivers_View";

            SqlCommand cmd = new SqlCommand(qurey, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            conn.Close(); }
        return dt;
        }

    }

}

