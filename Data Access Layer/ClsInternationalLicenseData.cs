using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer1
{
    public  class ClsInternationalLicenseData
    {

        public static int AddNewInternationalLicense(int LocalLicenseID , string InternationalLicenseNumber,DateTime IssueDate,
            decimal IssueFees, string LicenseStatus,int CreatedByUserID, DateTime ExpirationDate)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO InternationalLicense (LocalLicenseID, InternationalLicenseNumber, IssueDate, IssueFees, LicenseStatus, CreatedByUserID,ExpirationDate)
                                                        VALUES(@LocalLicenseID, @InternationalLicenseNumber, @IssueDate, @IssueFees, @LicenseStatus, @CreatedByUserID, @ExpirationDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LocalLicenseID", System.Data.SqlDbType.Int).Value = LocalLicenseID;
            command.Parameters.Add("@InternationalLicenseNumber", System.Data.SqlDbType.NVarChar, 50).Value = InternationalLicenseNumber;
            command.Parameters.Add("@IssueDate", System.Data.SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@IssueFees", System.Data.SqlDbType.Decimal).Value = IssueFees;
            command.Parameters.Add("@LicenseStatus", System.Data.SqlDbType.NVarChar, 50).Value = LicenseStatus;
            command.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@ExpirationDate", System.Data.SqlDbType.DateTime).Value = ExpirationDate;

         
            try
            {
                connection.Open();
                Console.WriteLine(connection.Database);
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    InternationalLicenseID = InsertID;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }


        public static bool DoesInternationalLicenseExistByLocalLicenseID(int LocalLicenseID)
        {
            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT CASE
                WHEN EXISTS
                (
                    SELECT 1
                    FROM InternationalLicense
                    WHERE LocalLicenseID = @LocalLicenseID
                )
                THEN 1
                ELSE 0
            END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", SqlDbType.Int).Value = LocalLicenseID;

                    try
                    {
                        connection.Open();
                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable GetInternationalLicenseInfoByApplicationID( int ApplicationID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                                    SELECT
                                        IL.InternationalLicenseID,
                                        ALC.ApplicationID,
                                        IL.LocalLicenseID,
                                        IL.IssueDate,
                                        IL.ExpirationDate,
                                        IL.LicenseStatus
                                    FROM InternationalLicense IL

                                    INNER JOIN LocalLicense LL
                                        ON LL.LocalLicenseID = IL.LocalLicenseID

                                    INNER JOIN ApplicationLicenseClass ALC
                                        ON ALC.ApplicationLicenseClassID =
                                           LL.ApplicationLicenseClassID

                                    WHERE ALC.ApplicationID = @ApplicationID;";

                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int)
                                      .Value = ApplicationID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader =
                               command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetAllInterantionalLicense1()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from InternationalLicense;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int GetLocalLicenseIDByApplicationID(int ApplicationID)
        {
            int LocalLicenseID = -1;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT LL.LocalLicenseID
            FROM LocalLicense LL
            INNER JOIN ApplicationLicenseClass ALC
                ON ALC.ApplicationLicenseClassID =
                   LL.ApplicationLicenseClassID
            WHERE ALC.ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            LocalLicenseID = Convert.ToInt32(result);
                    }
                    catch
                    {
                        LocalLicenseID = -1;
                    }
                }
            }

            return LocalLicenseID;
        }
    }
}
