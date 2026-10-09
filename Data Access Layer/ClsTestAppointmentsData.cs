using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccessLayer1
{
    public  class ClsTestAppointmentsData
    {
        public static int AddNewAppointment(DateTime AppointmentDate, decimal PaidFee, bool IsLocked, 
            int TestTypeID, int ApplicationLicenseClassID,int CreatedByUserID)
        {
            int AppointmentID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO TestAppointment (AppointmentDate,PaidFees,IsLocked,TestTypeID,ApplicationLicenseClassID,CreatedByUserID)
                                                   VALUES(@AppointmentDate, @PaidFees, @IsLocked, @TestTypeID, @ApplicationLicenseClassID,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentDate", System.Data.SqlDbType.DateTime).Value = AppointmentDate;
            command.Parameters.Add("@PaidFees", System.Data.SqlDbType.Decimal).Value = PaidFee;
            command.Parameters.Add("@IsLocked", System.Data.SqlDbType.Bit).Value = IsLocked;
            command.Parameters.Add("@TestTypeID", System.Data.SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@ApplicationLicenseClassID", System.Data.SqlDbType.Int).Value = ApplicationLicenseClassID;
            command.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    AppointmentID = InsertID;
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
            return AppointmentID;
        }

        public static DataTable GetAlltestAppointmentDetails()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"
                                  SELECT 
                                    TestAppointment.AppointmentID,
                                    TestAppointment.AppointmentDate,
                                    TestAppointment.PaidFees,
                                    TestAppointment.IsLocked
                                  FROM TestAppointment;";

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
        public static bool FindTestAppointmentIDByApplicationLicenseID(ref int AppointmentID,ref DateTime AppointmentDate, ref decimal PaidFees, ref bool IsLocked, ref int TestTypeID,  int ApplicationLicenseClassID, ref int CreatedByUserID)
        { 
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *
                            FROM TestAppointment
                            WHERE ApplicationLicenseClassID=@ApplicationLicenseClassID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ApplicationLicenseClassID", System.Data.SqlDbType.Int).Value = ApplicationLicenseClassID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    AppointmentID = (int)reader["AppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsLocked = (bool)reader["IsLocked"];
                    TestTypeID = (int)reader["TestTypeID"];
                  
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the Appointment ID  by ApplicationLicenseClassID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }

        public static bool FindTestAppointmentIDByID( int AppointmentID, ref DateTime AppointmentDate, ref decimal PaidFees, ref bool IsLocked, ref int TestTypeID, ref int ApplicationLicenseClassID, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *
                            FROM TestAppointment
                            WHERE AppointmentID=@AppointmentID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@AppointmentID", System.Data.SqlDbType.Int).Value = AppointmentID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationLicenseClassID = (int)reader["ApplicationLicenseClassID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsLocked = (bool)reader["IsLocked"];
                    TestTypeID = (int)reader["TestTypeID"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the Appointment ID  by ID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }
        public static bool IsAppointmentDataExist(int AppointmentID )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from TestAppointment where AppointmentID=@AppointmentID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"AppointmentID", System.Data.SqlDbType.Int).Value = AppointmentID;
           

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
        public static bool UpdateTestAppointmentInfo(int AppointmentID,DateTime AppointmentDate)
        {
            int rowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            UPDATE TestAppointment
            SET AppointmentDate = @AppointmentDate
            WHERE AppointmentID = @AppointmentID;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@AppointmentID",
                        SqlDbType.Int).Value = AppointmentID;

                    command.Parameters.Add(
                        "@AppointmentDate",
                        SqlDbType.DateTime).Value = AppointmentDate;

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool DoesPersonHaveActiveAppointment(int PersonID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1
                                    FROM People P
                                    INNER JOIN Application A
                                        ON A.ApplicationPersonID = P.PersonID
                                    INNER JOIN ApplicationLicenseClass ALC
                                        ON ALC.ApplicationID = A.ApplicationID
                                    INNER JOIN TestAppointment TA
                                        ON TA.ApplicationLicenseClassID =
                                           ALC.ApplicationLicenseClassID
                                                WHERE P.PersonID = @PersonID
                                                   AND TA.TestTypeID = @TestTypeID
                                                       AND TA.IsLocked = 0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@TestTypeID",  SqlDbType.Int).Value = TestTypeID;

            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
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

        public static bool UpdateTestAppointmentInfoBylocking(int AppointmentID, bool IsLock)
        {
            int rowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            UPDATE TestAppointment
            SET IsLocked = @IsLocked
            WHERE AppointmentID = @AppointmentID;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@AppointmentID",
                        SqlDbType.Int).Value = AppointmentID;

                    command.Parameters.Add(
                        "@IsLocked",
                        SqlDbType.Bit).Value = IsLock;

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAlltestWrittenTestAppointmentDetails(int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            
            string query = @"
                                  SELECT 
                                       TA.AppointmentID,
                                         TA.AppointmentDate,
                                            TA.PaidFees,
                                               TA.IsLocked
                                                  FROM TestAppointment TA
                                INNER JOIN TestType TT ON TT.TestTypeID=TA.TestTypeID
                                WHERE TT.TestTypeID=@TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
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


    }
}




