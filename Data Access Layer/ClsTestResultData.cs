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
    public  class ClsTestResultData
    {
        public static int AddNewTestResult(int AppointmentID, bool Result, string Notes)
        {
            int TestTypeID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO TestResult (AppointmentID,Result,Notes)
                             VALUES(@AppointmentID, @Result, @Notes);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", System.Data.SqlDbType.Int).Value = AppointmentID;
      
            command.Parameters.Add("@Result", System.Data.SqlDbType.Bit).Value = Result;
            command.Parameters.Add("@Notes", System.Data.SqlDbType.NVarChar, 200).Value = Notes;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    TestTypeID = InsertID;
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
            return TestTypeID;
        }

        public static bool HasFailedTest(int ApplicationID, int TestTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            IF EXISTS
            (
                SELECT 1
                FROM ApplicationLicenseClass ALC
                INNER JOIN TestAppointment TA
                    ON TA.ApplicationLicenseClassID = ALC.ApplicationLicenseClassID
                INNER JOIN TestResult TR
                    ON TR.AppointmentID = TA.AppointmentID
                WHERE ALC.ApplicationID = @ApplicationID
                  AND TA.TestTypeID = @TestTypeID
                  AND TR.Result = 0
            )
                SELECT 1;
            ELSE
                SELECT 0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID",
                        SqlDbType.Int).Value = ApplicationID;

                    command.Parameters.Add("@TestTypeID",
                        SqlDbType.Int).Value = TestTypeID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        isFound = Convert.ToInt32(result) == 1;
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool HasPassedTest(int ApplicationID, int TestTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT 1
            FROM ApplicationLicenseClass ALC
            INNER JOIN TestAppointment TA
                ON TA.ApplicationLicenseClassID = ALC.ApplicationLicenseClassID
            INNER JOIN TestResult TR
                ON TR.AppointmentID = TA.AppointmentID
            WHERE ALC.ApplicationID = @ApplicationID
              AND TA.TestTypeID = @TestTypeID
              AND TR.Result = 1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int)
                        .Value = ApplicationID;

                    command.Parameters.Add("@TestTypeID", SqlDbType.Int)
                        .Value = TestTypeID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        isFound = result != null;
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int? GetLatestTestResult(int ApplicationID, int TestTypeID)
        {
            using (SqlConnection connection =new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
                            SELECT TOP 1 TR.Result
                            FROM ApplicationLicenseClass ALC
                            INNER JOIN TestAppointment TA
                                ON TA.ApplicationLicenseClassID =
                                   ALC.ApplicationLicenseClassID
                            INNER JOIN TestResult TR
                                ON TR.AppointmentID = TA.AppointmentID
                            WHERE ALC.ApplicationID = @ApplicationID
                              AND TA.TestTypeID = @TestTypeID
                            ORDER BY TA.AppointmentID DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return null;

                        return Convert.ToInt32(result);
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}
