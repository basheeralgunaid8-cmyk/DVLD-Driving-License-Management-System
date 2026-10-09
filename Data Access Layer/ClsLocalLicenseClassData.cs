using DTO_Project;
using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer1
{
    public  class ClsLocalLicenseClassData
    {


        public static int AddNewLocalLicense(string LicenseNumber, int DriverID, int ApplicationLicenseClassID, DateTime IssueDate,
             DateTime ExpirationDate , string LicenseStatus, int CreatedByUserID,string IssueReason, string Notes,int? ParenLocalLicenseID)
        {
            int LocalLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO LocalLicense (LicenseNumber, DriverID, ApplicationLicenseClassID, IssueDate, ExpirationDate, LicenseStatus, CreatedByUserID,IssueReason,Notes, ParenLocalLicenseID)
                             VALUES(@LicenseNumber, @DriverID, @ApplicationLicenseClassID, @IssueDate, @ExpirationDate, @LicenseStatus, @CreatedByUserID,@IssueReason,@Notes,@ParenLocalLicenseID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LicenseNumber", System.Data.SqlDbType.NVarChar, 50).Value = LicenseNumber;
            command.Parameters.Add("@DriverID", System.Data.SqlDbType.Int).Value = DriverID;
            command.Parameters.Add("@ApplicationLicenseClassID", System.Data.SqlDbType.Int).Value = ApplicationLicenseClassID;
            command.Parameters.Add("@IssueDate", System.Data.SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@ExpirationDate", System.Data.SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@LicenseStatus", System.Data.SqlDbType.NVarChar, 50).Value = LicenseStatus;
            command.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@IssueReason", System.Data.SqlDbType.NVarChar, 50).Value = IssueReason;
            command.Parameters.Add("@Notes", System.Data.SqlDbType.NVarChar, 50).Value = Notes;
            command.Parameters.Add("@ParenLocalLicenseID", SqlDbType.Int).Value = (object)ParenLocalLicenseID ?? DBNull.Value;

            try
            {
                connection.Open();
             
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    LocalLicenseID = InsertID;
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
            return LocalLicenseID;
        }

        public static LocalLicenseInfoDTO GetLocalLicenseInfoData(int LocalLicenseID)
        {
            LocalLicenseInfoDTO dto = null;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                                    SELECT
                                                LL.LocalLicenseID,
                                                LL.LicenseNumber,

                                               CONCAT_WS(' ',
                                                    P.FirstName,                                                   
                                                    P.FourthName
                                                ) AS FullName,

                                                LC.ClassName AS LicenseClassName,

                                                P.NationalID,
                                                P.DateOfBirth,
                                                P.Gender,

                                                LL.IssueDate,
                                                LL.ExpirationDate,
                                                LL.LicenseStatus,
                                                LL.IssueReason,
                                                LL.Notes,
                                                P.ImagePath,
                                                D.DriverID

                                            FROM LocalLicense LL

                                            INNER JOIN Driver D
                                                ON D.DriverID = LL.DriverID

                                            INNER JOIN People P
                                                ON P.PersonID = D.PersonID

                                            INNER JOIN ApplicationLicenseClass ALC
                                                ON ALC.ApplicationLicenseClassID =
                                                   LL.ApplicationLicenseClassID

                                            INNER JOIN LicenseClass LC
                                                ON LC.LicenseClassID =
                                                   ALC.LicenseClassID

                                            WHERE LL.LocalLicenseID = @LocalLicenseID;";


                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@LocalLicenseID",
                        SqlDbType.Int).Value = LocalLicenseID;


                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            dto = new LocalLicenseInfoDTO(
                                                   (int)reader["LocalLicenseID"],
                                                   reader["LicenseNumber"].ToString(),
                                                   reader["FullName"].ToString(),
                                                   reader["LicenseClassName"].ToString(),
                                                   reader["NationalID"].ToString(),
                                                   (DateTime)reader["IssueDate"],
                                                   (DateTime)reader["DateOfBirth"],
                                                   reader["Gender"].ToString(),
                                                   (DateTime)reader["ExpirationDate"],
                                                   reader["LicenseStatus"].ToString(),
                                                   reader["IssueReason"].ToString(),
                                                   reader["Notes"].ToString(),
                                                   (int)reader["DriverID"],
                                                   reader["ImagePath"].ToString()
                                                   );

                        }
                    }
                }
            }

            return dto;
        }

        public static bool DoesLicenseExist(int LocalLicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from LocalLicense where LocalLicenseID=@LocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"LocalLicenseID", System.Data.SqlDbType.Int).Value = LocalLicenseID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

            }
            catch
            {

                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool DoesLicenseExistByApplicationID(int applicationID)
        {
            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT
                CASE
                    WHEN EXISTS
                    (
                        SELECT 1
                        FROM LocalLicense LL
                        INNER JOIN ApplicationLicenseClass ALC
                            ON ALC.ApplicationLicenseClassID =
                               LL.ApplicationLicenseClassID
                        WHERE ALC.ApplicationID = @ApplicationID
                    )
                    THEN 1
                    ELSE 0
                END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;

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
        public static bool DoesLicenseExistByLocalLicenseID(int localLicenseID)
        {
            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT CASE
                WHEN EXISTS
                (
                    SELECT 1
                    FROM LocalLicense
                    WHERE LocalLicenseID = @LocalLicenseID
                )
                THEN 1
                ELSE 0
            END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", SqlDbType.Int)
                                      .Value = localLicenseID;

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
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int) .Value = ApplicationID;

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

        public static bool FindLicenseInfoByLocalLicenseID(int LocalLicenseID, ref string LicenseNumber, ref int DriverID, ref int ApplicationLicenseClassID, ref DateTime IssueDate,
            ref  DateTime ExpirationDate, ref string LicenseStatus,ref  int CreatedByUserID,ref string IssueReason,ref  string Notes, ref int? ParenLocalLicenseID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM LocalLicense
                                  WHERE LocalLicenseID=@LocalLicenseID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LocalLicenseID", System.Data.SqlDbType.Int).Value = LocalLicenseID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)reader["DriverID"];
                  
                    LicenseNumber = (string)reader["LicenseNumber"];
                    ApplicationLicenseClassID = (int )reader["ApplicationLicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    LicenseStatus = (string)reader["LicenseStatus"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueReason = (string)reader["IssueReason"];
                    Notes = (string)reader["Notes"];
                    ParenLocalLicenseID = reader["ParenLocalLicenseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ParenLocalLicenseID"]);
                    
                    
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
            return IsFound;
        }
        public static LocalLicenseInfoDTO FindLicenseInfoByLocalLicenseID(  int LocalLicenseID)
        {
            LocalLicenseInfoDTO dto = null;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT
                LL.LocalLicenseID,
                LL.LicenseNumber,
                P.FirstName + ' ' +
                P.SecondName + ' ' +
                P.ThirdName + ' ' +
                P.FourthName AS FullName,
                LC.ClassName AS LicenseClassName,
                P.NationalID,
                LL.IssueDate,
                P.DateOfBirth,
                P.Gender,
                LL.ExpirationDate,
                LL.LicenseStatus,
                LL.IssueReason,
                LL.Notes,
                D.DriverID,
                P.ImagePath

            FROM LocalLicense LL

            INNER JOIN Driver D
                ON D.DriverID = LL.DriverID

            INNER JOIN People P
                ON P.PersonID = D.PersonID

            INNER JOIN ApplicationLicenseClass ALC
                ON ALC.ApplicationLicenseClassID =
                   LL.ApplicationLicenseClassID

            INNER JOIN LicenseClass LC
                ON LC.LicenseClassID = ALC.LicenseClassID

            WHERE LL.LocalLicenseID = @LocalLicenseID;";

                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", SqlDbType.Int) .Value = LocalLicenseID;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LocalLicenseInfoDTO
                            {
                                LocalLicenseID = Convert.ToInt32(reader["LocalLicenseID"]),
                                LicenseNumber = reader["LicenseNumber"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                LicenseClassName = reader["LicenseClassName"].ToString(),
                                NationalNo = reader["NationalID"].ToString(),
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Gender = reader["Gender"].ToString(),
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                                LicenseStatus = reader["LicenseStatus"].ToString(),
                                IssueReason = reader["IssueReason"].ToString(),
                                Notes = reader["Notes"].ToString(),
                                DriverID = Convert.ToInt32(reader["DriverID"]),
                                ImagePath = reader["ImagePath"].ToString()
                            };
                        }
                    }
                }
            }

            return dto;
        }

        public static DataTable GetAllLocalLicenseInfo(int ApplicationID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT
                LL.LocalLicenseID,
                AP.ApplicationID,
                LC.ClassName,
                LL.IssueDate,
                LL.ExpirationDate,
                LL.LicenseStatus,
                LL.IssueReason,
                LL.ParenLocalLicenseID
            FROM LocalLicense LL

            INNER JOIN Driver D
                ON D.DriverID = LL.DriverID

            INNER JOIN People P
                ON P.PersonID = D.PersonID

            INNER JOIN ApplicationLicenseClass ALC
                ON ALC.ApplicationLicenseClassID =
                   LL.ApplicationLicenseClassID

            INNER JOIN Application AP
                ON AP.ApplicationID = ALC.ApplicationID

            INNER JOIN LicenseClass LC
                ON LC.LicenseClassID = ALC.LicenseClassID

            WHERE D.PersonID =
            (
                SELECT ApplicationPersonID
                FROM Application
                WHERE ApplicationID = @ApplicationID
            )

            ORDER BY LL.LocalLicenseID;";

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
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
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

        public static bool DeactivateLicense(int LocalLicenseID, string LicenseStatus)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE LocalLicense
                     SET LicenseStatus = @LicenseStatus
                     WHERE LocalLicenseID = @LocalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LocalLicenseID", SqlDbType.Int).Value =  LocalLicenseID;

            command.Parameters.Add("@LicenseStatus", SqlDbType.NVarChar, 50).Value =LicenseStatus;

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DoesLicenseStillActive(int LocalLicenseID)
        {
            using (SqlConnection connection =  new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT
                CAST(
                    CASE
                        WHEN LicenseStatus = 'Active' THEN 1
                        ELSE 0
                    END
                AS BIT)
            FROM LocalLicense
            WHERE LocalLicenseID = @LocalLicenseID;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", SqlDbType.Int).Value = LocalLicenseID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return false;

                        return Convert.ToBoolean(result);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

    }
}
