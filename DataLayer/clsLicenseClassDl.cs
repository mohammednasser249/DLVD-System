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
    



    }
}
