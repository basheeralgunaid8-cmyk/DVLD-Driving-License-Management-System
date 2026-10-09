using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DVLD_DataAccessLayer1
{
    public class ClsDriverData
    {

        public static int AddNewDriver(int PersonID, string DriverNumber,DateTime CreatedDate, string DriverStatus, int CreatedByUserID)
        {

            int DriverID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO Driver
                                                            (
                                                                DriverNumber,
                                                                DriverStatus,
                                                                CreatedDate,
                                                                CreatedByUserID,
                                                                PersonID
                                                            )
                                                            VALUES
                                                            (
                                                                @DriverNumber,
                                                                @DriverStatus,
                                                                @CreatedDate,
                                                                @CreatedByUserID,
                                                                @PersonID
                                                            );
                             SELECT SCOPE_IDENTITY();";

            SqlCommand commmand = new SqlCommand(query, connection);

            commmand.Parameters.Add("@DriverNumber", System.Data.SqlDbType.NVarChar).Value = DriverNumber;
            commmand.Parameters.Add("@DriverStatus", System.Data.SqlDbType.NVarChar).Value = DriverStatus;
            commmand.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime).Value = CreatedDate;
            commmand.Parameters.Add("@CreatedByUserID", System.Data.SqlDbType.Int).Value = CreatedByUserID;
            commmand.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;

            try
            {
                connection.Open();
                object result = commmand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    DriverID = InsertID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the driver data.", ex);
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }


        public static bool FindDriverByPersonID( ref int DriverID, ref string DriverNumber, ref string DriverStatus, ref DateTime CreatedTime, ref int CreatedByUserID, int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM Driver
                                  WHERE PersonID=@PersonID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    DriverID = (int)reader["DriverID"];
                    DriverNumber = (string)reader["DriverNumber"];
                    DriverStatus = (string)reader["DriverStatus"];
                    CreatedTime = (DateTime)reader["CreatedDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the driver by PersonID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }
    }
}
