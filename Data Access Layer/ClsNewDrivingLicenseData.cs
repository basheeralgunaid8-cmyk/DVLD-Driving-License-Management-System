using DTO_Project;
using DVLD_DataAccessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_DataAccessLayer1
{
    public  class ClsNewDrivingLicenseData
    {

        public static int AddNewDrivingLicense( int ApplicationPersonID, int ApplicationTypeID, DateTime ApplicationDate, decimal PaidAmount, string ApplicationStatus, int CreatedByUserID,int? ParentApplicationID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Application (ApplicationPersonID,ApplicationTypeID,ApplicationDate,PaidAmount,ApplicationStatus,CreatedByUserID,ParentApplicationID)
                             VALUES(@ApplicationPersonID, @ApplicationTypeID, @ApplicationDate, @PaidAmount, @ApplicationStatus, @CreatedByUserID,@ParentApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ApplicationPersonID", System.Data.SqlDbType.Int).Value = ApplicationPersonID;
            command.Parameters.Add("@ApplicationTypeID", System.Data.SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicationDate", System.Data.SqlDbType.DateTime).Value = ApplicationDate;
            command.Parameters.Add("@PaidAmount", System.Data.SqlDbType.Decimal).Value = PaidAmount;
            command.Parameters.Add("@ApplicationStatus", System.Data.SqlDbType.NVarChar, 50).Value = ApplicationStatus;
            command.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@ParentApplicationID", SqlDbType.Int).Value =(object)ParentApplicationID ?? DBNull.Value;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ApplicationID = InsertID;
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
            return ApplicationID;
        }
        public static bool FindApplicationInfoByID(int ApplicationID, ref int ApplicationPersonID, ref int ApplicationTypeID,ref  DateTime ApplicationDate,
            ref Decimal PaidAmount,ref  string ApplicationStatus, ref int CreatedByUserID,ref int? ParentApplicationID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM Application
                                  WHERE ApplicationID=@ApplicationID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ApplicationID", System.Data.SqlDbType.Int).Value = ApplicationID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicationPersonID = (int)reader["ApplicationPersonID"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PaidAmount = (Decimal)reader["PaidAmount"];
                    ApplicationStatus = (string)reader["ApplicationStatus"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ParentApplicationID =  reader["ParentApplicationID"] == DBNull.Value ? (int?)null: Convert.ToInt32(reader["ParentApplicationID"]);
                                                             

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


        public static bool UpdateNewDrivingLicenseInfo(int ApplicationID, int ApplicationPersonID, int ApplicationTypeID, DateTime ApplicationDate,
            Decimal PaidAmount, string ApplicationStatus, int CreatedByUserID)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE Application
                                            SET 
                                                ApplicationPersonID=@ApplicationPersonID,
                                                ApplicationTypeID=@ApplicationTypeID,
                                                ApplicationDate=@ApplicationDate,
                                                PaidAmount=@PaidAmount,
                                                ApplicationStatus=@ApplicationStatus,
                                                CreatedByUserID=@CreatedByUserID
                                                WHERE ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ApplicationID", System.Data.SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@ApplicationPersonID", System.Data.SqlDbType.Int).Value = ApplicationPersonID;
            command.Parameters.Add("@ApplicationTypeID", System.Data.SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicationDate", System.Data.SqlDbType.DateTime).Value = ApplicationDate;
            command.Parameters.Add("@PaidAmount", System.Data.SqlDbType.Decimal).Value = PaidAmount;
            command.Parameters.Add("@ApplicationStatus", System.Data.SqlDbType.NVarChar, 50).Value = ApplicationStatus;
            command.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;

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

         public static bool  DoesPersonAlreadyHaveLicenseClass(int PersonID,int  LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1
                                            FROM Application A
                                            INNER JOIN ApplicationLicenseClass ALC
                                                ON A.ApplicationID = ALC.ApplicationID
                                            INNER JOIN LicenseClass LC
                                                ON ALC.LicenseClassID = LC.LicenseClassID
                                            WHERE A.ApplicationPersonID = @ApplicationPersonID
                                              AND LC.LicenseClassID = @LicenseClassID; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"LicenseClassID", System.Data.SqlDbType.Int).Value = LicenseClassID;
            command.Parameters.Add("@ApplicationPersonID", System.Data.SqlDbType.Int).Value = PersonID;
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

        //public static DataTable SearchNewDrivingLicense(string searchText, string filterColumn)
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection connection =
        //          new SqlConnection(DataAccessSetting.ConnectionString))
        //    {
        //        string query = "";

        //        switch (filterColumn)
        //        {
        //            case "All":

        //                query = @"SELECT *
        //                  FROM Application
        //                  WHERE UserName LIKE @Search
        //                  OR NationalID LIKE @Search";

        //                break;


        //            //by Name
        //            case "ApplicationStatus":

        //                query = @"SELECT *
        //                  FROM Application
        //                  WHERE ApplicationStatus LIKE @Search";

        //                break;
        //            //by User ID
        //            case "UserID":

        //                query = @" SELECT *
        //                            FROM User_
        //                            WHERE CAST(UserID AS NVARCHAR) LIKE @Search";
        //                break;

        //            //by Person ID

        //            case "PersonID":

        //                query = @" SELECT *
        //                            FROM User_
        //                            WHERE CAST(UserID AS NVARCHAR) LIKE @Search";
        //                break;

        //            case "IsActive":

        //                query = @"SELECT *
        //                  FROM People
        //                  WHERE IsActive LIKE @Search";
        //                break;

        //            // exception for invalid filter

        //            default:

        //                throw new Exception("Invalid search filter");

        //        }


        //        using (SqlCommand command =
        //              new SqlCommand(query, connection))
        //        {
        //            command.Parameters.Add("@Search",
        //                SqlDbType.NVarChar, 100)
        //                .Value = "%" + searchText + "%";


        //            connection.Open();


        //            using (SqlDataReader reader =
        //                  command.ExecuteReader())
        //            {
        //                dt.Load(reader);
        //            }
        //        }
        //    }


        //    return dt;
        //}

        public static DataTable GetAllLocalLicenseApplication()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                                  SELECT
                                    A.ApplicationID,
                                    LC.ClassName,
                                    P.NationalID,
                                    CONCAT(
                                        P.FirstName, ' ',
                                        P.SecondName, ' ',
                                        P.ThirdName, ' ',
                                        P.FourthName
                                    ) AS FullName,
                                    A.ApplicationDate,

                                    CASE
                                        WHEN
                                            COUNT(TR.TestResultID) = 3
                                            AND SUM(CASE WHEN TR.Result = 1 THEN 1 ELSE 0 END) = 3
                                        THEN 1
                                        ELSE 0
                                    END AS Result,

                                    A.ApplicationStatus

                                FROM Application A

                                INNER JOIN ApplicationLicenseClass ALC
                                    ON ALC.ApplicationID = A.ApplicationID

                                INNER JOIN LicenseClass LC
                                    ON LC.LicenseClassID = ALC.LicenseClassID

                                INNER JOIN People P
                                    ON P.PersonID = A.ApplicationPersonID

                                LEFT JOIN TestAppointment TA
                                    ON TA.ApplicationLicenseClassID =
                                       ALC.ApplicationLicenseClassID

                                LEFT JOIN TestResult TR
                                    ON TR.AppointmentID = TA.AppointmentID

                                GROUP BY
                                    A.ApplicationID,
                                    LC.ClassName,
                                    P.NationalID,
                                    P.FirstName,
                                    P.SecondName,
                                    P.ThirdName,
                                    P.FourthName,
                                    A.ApplicationDate,
                                    A.ApplicationStatus;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
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

        public static DataTable SearchLocalLicenseApplication(string Search, string filterColumn)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                  new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = "";

                switch (filterColumn)
                {
                  
                    case "NationalID":

                        query = @"
            SELECT
                Application.ApplicationID,
                LicenseClass.ClassName,
                People.NationalID,
                CONCAT(
                    People.FirstName, ' ',
                    People.SecondName, ' ',
                    People.ThirdName, ' ',
                    People.FourthName
                ) AS FullName,
                Application.ApplicationDate,
                TestResult.Result,
                Application.ApplicationStatus
            FROM Application
            INNER JOIN ApplicationLicenseClass
                ON ApplicationLicenseClass.ApplicationID =
                   Application.ApplicationID

            INNER JOIN LicenseClass
                ON LicenseClass.LicenseClassID =
                   ApplicationLicenseClass.LicenseClassID

            INNER JOIN People
                ON People.PersonID =
                   Application.ApplicationPersonID

            LEFT JOIN TestAppointment
                ON TestAppointment.ApplicationLicenseClassID =
                   ApplicationLicenseClass.ApplicationLicenseClassID

            LEFT JOIN TestResult
                ON TestResult.AppointmentID =
                   TestAppointment.AppointmentID
               WHERE NationalID  LIKE @Search;";

                        break;


                    default:

                        throw new Exception("Invalid search filter");

                }


                using (SqlCommand command =
                      new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Search",
                        SqlDbType.NVarChar, 100)
                        .Value = "%" + Search + "%";


                    connection.Open();


                    using (SqlDataReader reader =
                          command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }


            return dt;
        }

        public static ApplicationBasicInfoDTO GetApplicationBasicInfoData(int applicationID)
        {
            ApplicationBasicInfoDTO dto = null;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                                        SELECT
                                            A.ApplicationID,
                                            A.ApplicationPersonID,
                                            AT.ApplicationTypeTitle,
                                            CONCAT(
                                                P.FirstName, ' ',
                                                P.SecondName, ' ',
                                                P.ThirdName, ' ',
                                                P.FourthName
                                            ) AS ApplicantFullName,
                                            A.ApplicationStatus,
                                            A.PaidAmount,
                                            A.ApplicationDate,
                                            U.UserName AS CreatedByUserName,
                                            A.CreatedByUserID,
                                            A.ParentApplicationID
                                        FROM Application A
                                        INNER JOIN ApplicationType AT
                                            ON A.ApplicationTypeID = AT.ApplicationTypeID
                                        INNER JOIN People P
                                            ON P.PersonID = A.ApplicationPersonID
                                        INNER JOIN User_ U
                                            ON U.UserID = A.CreatedByUserID
                                        WHERE A.ApplicationID = @ApplicationID;";


                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@ApplicationID",
                        SqlDbType.Int).Value = applicationID;


                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            dto = new ApplicationBasicInfoDTO(
                                                   (int)reader["ApplicationID"],
                                                   (int)reader["ApplicationPersonID"],
                                                   reader["ApplicationTypeTitle"].ToString(),
                                                   reader["ApplicantFullName"].ToString(),
                                                   reader["ApplicationStatus"].ToString(),
                                                   (decimal)reader["PaidAmount"],
                                                   (DateTime)reader["ApplicationDate"],
                                                   reader["CreatedByUserName"].ToString(),
                                                   (int)reader["CreatedByUserID"],
                                                   ParentApplicationID:
                                                       reader["ParentApplicationID"] == DBNull.Value
                                                           ? (int?)null
                                                           : Convert.ToInt32(reader["ParentApplicationID"])
                                                             );

                        }
                    }
                }
            }

            return dto;
        }

        public static  bool GetDrivingLicenseInfo(int ApplicationID, ref string ClassName,ref int Result)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 
                                        Application.ApplicationID,
                                        LicenseClass.ClassName,
                                        TestResult.Result
                                    FROM Application
                                    INNER JOIN ApplicationLicenseClass
                                        ON ApplicationLicenseClass.ApplicationID =
                                           Application.ApplicationID
                                    INNER JOIN LicenseClass
                                        ON LicenseClass.LicenseClassID =
                                           ApplicationLicenseClass.LicenseClassID
                                    LEFT JOIN TestAppointment
                                        ON TestAppointment.ApplicationLicenseClassID =
                                           ApplicationLicenseClass.ApplicationLicenseClassID
                                    LEFT JOIN TestResult
                                        ON TestResult.AppointmentID =
                                           TestAppointment.AppointmentID
                                    WHERE Application.ApplicationID = @ApplicationID;";
           

            SqlCommand command =new SqlCommand(query, connection);

            command.Parameters.Add( "@ApplicationID", SqlDbType.Int).Value = ApplicationID;
          
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    ClassName = (string)reader["ClassName"];
                    Result = reader["Result"] == DBNull.Value? 0: Convert.ToInt32(reader["Result"]);

                }
            }
            catch (Exception ex)
            {
                   //throw Exception(" this point happens in error while returning the License Class Info",ex)
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }

    
        public static int GetApplicationIDByLocalLicenseID(int LocalLicenseID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT  ALC.ApplicationID
            FROM LocalLicense LL
            INNER JOIN ApplicationLicenseClass ALC
                ON ALC.ApplicationLicenseClassID =
                   LL.ApplicationLicenseClassID
            WHERE  LL.LocalLicenseID = @LocalLicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LocalLicenseID", SqlDbType.Int).Value = LocalLicenseID;
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            ApplicationID = Convert.ToInt32(result);
                    }
                    catch
                    {
                        ApplicationID = -1;
                    }
                }
            }

            return ApplicationID;
        }      
        public static int GetRenewalApplicationIDByParentApplicationID(int ParentApplicationID, int ApplicationTypeID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                     IF EXISTS
                        (
                            SELECT 1
                            FROM Application
                            WHERE ParentApplicationID = @OriginalApplicationID
                              AND ApplicationTypeID = @ApplicationTypeID
                        );";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ParentApplicationID", SqlDbType.Int).Value = ParentApplicationID;
                    command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            ApplicationID = Convert.ToInt32(result);
                    }
                    catch
                    {
                        ApplicationID = -1;
                    }
                }
            }

            return ApplicationID;
        }
        public static bool IsApplicationTypeExists(  int ParentApplicationID, int ApplicationTypeID)
        {
            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                                            SELECT CASE
                                        WHEN EXISTS (
                                            SELECT 1
                                            FROM Application
                                            WHERE ParentApplicationID = @ParentApplicationID
                                              AND ApplicationTypeID = @ApplicationTypeID
                                        )
                                        THEN CAST(1 AS BIT)
                                        ELSE CAST(0 AS BIT)
                                    END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ParentApplicationID", SqlDbType.Int) .Value = ParentApplicationID;

                    command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;

                    try
                    {
                        connection.Open();

                        bool exists = (bool)command.ExecuteScalar();

                        return exists;
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
