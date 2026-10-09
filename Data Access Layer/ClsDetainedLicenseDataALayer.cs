using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccessLayer1
{
    public class ClsDetainedLicenseDataALayer
    {

        public static int AddNewDetainedLicense(int LocalLicenseID, DateTime DetainDate, decimal FineFees, bool IsReleased, DateTime ReleaseDate, int CreatedByUserID, int ?ReleasedByUserID)
        {
            int DetainedLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"INSERT INTO DetainedLicense
                                                        (
                                                            LocalLicenseID,
                                                            DetainDate,
                                                            FineFees,
                                                            IsReleased,
                                                            ReleaseDate,
                                                            CreatedByUserID,
                                                            ReleasedByUserID
                                                        )
                                                        VALUES
                                                        (
                                                            @LocalLicenseID,
                                                            @DetainDate,
                                                            @FineFees,
                                                            @IsReleased,
                                                            @ReleaseDate,
                                                            @CreatedByUserID,
                                                            @ReleasedByUserID
                                                        );
                                 SELECT SCOPE_IDENTITY();";
            SqlCommand commmand = new SqlCommand(query, connection);
            commmand.Parameters.Add("@LocalLicenseID", System.Data.SqlDbType.Int).Value = LocalLicenseID;
            commmand.Parameters.Add("@DetainDate", System.Data.SqlDbType.DateTime).Value = DetainDate;
            commmand.Parameters.Add("@FineFees", System.Data.SqlDbType.Decimal).Value = FineFees;
            commmand.Parameters.Add("@IsReleased", System.Data.SqlDbType.Bit).Value = IsReleased;
            commmand.Parameters.Add("@ReleaseDate", System.Data.SqlDbType.DateTime).Value = ReleaseDate;
            commmand.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            commmand.Parameters.Add("@ReleasedByUserID", System.Data.SqlDbType.Int).Value = (object)ReleasedByUserID ?? DBNull.Value;

            try
            {
                connection.Open();
                object result = commmand.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    DetainedLicenseID = InsertID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the detained license data.", ex);
            }
            finally
            {
                connection.Close();
            }
            return DetainedLicenseID;
        }

        public static bool IsLicenseDetained(int LocalLicenseID)
        {
            bool isDetained = false;

            string query = @"SELECT CASE 
                        WHEN EXISTS (
                            SELECT 1 
                            FROM DetainedLicense 
                            WHERE LocalLicenseID = @LocalLicenseID AND IsReleased = 0
                        ) THEN CAST(1 AS BIT)
                        ELSE CAST(0 AS BIT)
                    END";

            using (SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && bool.TryParse(result.ToString(), out bool status))
                    {
                        isDetained = status;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while Checking the detained license data.", ex);
                }
                finally
                {
                    connection.Close();
                }

                return isDetained;
            }
        }

        public static bool FindDetainInfobyLocalLicenseID(
       ref int DetainID,
       int LocalLicenseID,
       ref DateTime DetainDate,
       ref decimal FineFees,
       ref bool IsReleased,
       ref DateTime ReleaseDate,
       ref int CreatedByUserID,
       ref int ReleasedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM DetainedLicense
                         WHERE LocalLicenseID = @LocalLicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", System.Data.SqlDbType.Int).Value = LocalLicenseID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                IsReleased = (bool)reader["IsReleased"];

                                if (reader["ReleaseDate"] != DBNull.Value)
                                    ReleaseDate = (DateTime)reader["ReleaseDate"];

                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                if (reader["ReleasedByUserID"] != DBNull.Value)
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];
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

        public static bool UpdateReleaseInfo(int DetainID, DateTime ReleaseDate,bool IsReleased, int ReleasedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE DetainedLicense
                      SET ReleaseDate = @ReleaseDate,
                         ReleasedByUserID = @ReleasedByUserID,
                         IsReleased= @IsReleased
                           WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@DetainID", System.Data.SqlDbType.Int).Value = DetainID;
            command.Parameters.Add("@IsReleased", System.Data.SqlDbType.Bit).Value = IsReleased;
            command.Parameters.Add("@ReleaseDate", System.Data.SqlDbType.DateTime).Value = ReleaseDate;
            command.Parameters.Add("@ReleasedByUserID", System.Data.SqlDbType.Int).Value = ReleasedByUserID;

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }
    }
}