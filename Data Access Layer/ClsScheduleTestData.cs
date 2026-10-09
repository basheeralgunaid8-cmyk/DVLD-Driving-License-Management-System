using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_DataAccessLayer1
{
    public  class ClsScheduleTestData
    {


        public static bool GetScheduleTestInfoData(
       int ApplicationID,
       ref string ClassName,
       ref string FullName)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT 
                Application.ApplicationID,
                LicenseClass.ClassName,
                People.FirstName + ' ' +
                People.SecondName + ' ' +
                People.ThirdName + ' ' +
                People.FourthName AS FullName
              
            FROM Application
            INNER JOIN People
                ON People.PersonID =
                   Application.ApplicationPersonID
            INNER JOIN ApplicationLicenseClass
                ON ApplicationLicenseClass.ApplicationID =
                   Application.ApplicationID
            LEFT JOIN LicenseClass
                ON LicenseClass.LicenseClassID =
                   ApplicationLicenseClass.LicenseClassID
            WHERE Application.ApplicationID = @ApplicationID;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@ApplicationID",
                        SqlDbType.Int).Value = ApplicationID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ClassName =
                                    reader["ClassName"] == DBNull.Value
                                        ? ""
                                        : reader["ClassName"].ToString();

                                FullName =
                                    reader["FullName"] == DBNull.Value
                                        ? ""
                                        : reader["FullName"].ToString();

                               
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool GetScheduleTestInfoOfTestType(int TestTypeID, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                     SELECT *FROM TestType
                          WHERE TestTypeID= @TestTypeID;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@TestTypeID",
                        SqlDbType.Int).Value = TestTypeID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Fees = (decimal)reader["Fees"];
                                    


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsFound;
        }
    }
    }
