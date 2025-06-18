using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsclsLocalDrivingLicnseViewDl
    {

       
            public static bool FindByID(
                int licenseID,
                ref string className,
                ref string nationalNo,
                ref string fullName,
                ref DateTime applicationDate,
                ref int passedTestCount,
                ref string status
            )
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.StringConnection))
                {
                    string query = @"
                SELECT * 
                FROM LocalDrivingLicenseApplications_View 
                WHERE LocalDrivingLicenseApplicationID = @LicenseID;
            ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            className = reader["ClassName"].ToString();
                            nationalNo = reader["NationalNo"].ToString();
                            fullName = reader["FullName"].ToString();
                            applicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            passedTestCount = Convert.ToInt32(reader["PassedTestCount"]);
                            status = reader["Status"].ToString();

                            return true;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Data retrieval failed in FindByID", ex);
                    }
                }

                return false;
            }
        }

    }

