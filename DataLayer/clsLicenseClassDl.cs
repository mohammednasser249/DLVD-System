﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer
{
    public class clsLicenseClassDl
    {


        public static DataTable GetAllLicenseClassesDL()
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            DataTable dataTable = new DataTable();
            string query = @"
            select *
            from LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, conn);

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


        public static int GetDefaultValidLength(int licenceid)
        {

            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);


            string query = @"select DefaultValidityLength
from LicenseClasses
where LicenseClassID=@licenceid";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@licenceid", licenceid);

            int length = -1;

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int len))
                {
                    length = len;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                conn.Close(); }

            return length;

        }
    
        public static bool GetClassNameDl(ref string ClassName,int ClassID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select ClassName
from LicenseClasses
where LicenseClassID=@ClassID";

            SqlCommand cmd = new SqlCommand(qurey, conn);
            cmd.Parameters.AddWithValue("@ClassID",ClassID);

            bool found = false;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    found = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            conn.Close(); }
        return found;
        }

        public static bool GetClassFeesDl(ref decimal ClassFees, int ClassID)
        {
            SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection);

            string qurey = @"select ClassFees
from LicenseClasses
where LicenseClassID=@ClassID";

            SqlCommand cmd = new SqlCommand(qurey, conn);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

            bool found = false;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ClassFees = (decimal)reader["ClassFees"];
                    found = true;
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
            return found;
        }


    }
}
