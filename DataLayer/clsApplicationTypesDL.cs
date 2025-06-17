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
    public class clsApplicationTypesDL
    {


        public static DataTable GetAllApplicationTypesDL()
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);
            DataTable dt = new DataTable();

            string qurey = @"use DLVD
                            select *
                            from ApplicationTypes";

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

        public static bool FindAppTypeByIdDL(int id , ref string Title,  ref decimal Fees)
        {
            SqlConnection con = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select *
                            from ApplicationTypes
                            where ApplicationTypeID =@id";
            SqlCommand cmd = new SqlCommand(qurey , con);
            cmd.Parameters.AddWithValue("@id", id);

            bool isfound = false;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];
                    isfound = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isfound;

            

        }

        public static bool UpdateApplicationDL(int Id , string Title , decimal Fees)
        {
            SqlConnection con = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"update ApplicationTypes
                        set ApplicationTypeTitle =@Title , ApplicationFees =@Fees
                        where ApplicationTypeID =@Id";

            SqlCommand cmd = new SqlCommand(qurey, con);

            bool isupdated = false;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                con.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected > 0) {
                    isupdated = true;
                }


            }catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
            finally
            {

            con.Close(); }
        return isupdated;
        
        }


        }


    }


