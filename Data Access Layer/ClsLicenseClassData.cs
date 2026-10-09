using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DVLD_DataAccessLayer1
{
    public  class ClsLicenseClassData
    {

        public static bool UpdateLicenseClassType(int LicenseClassID, string ClassName, int MinimumAllowedAge,int ValidityLength, decimal ClassFee)
        {


            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE LicenseClass
                                 SET ClassName=@ClassName,
                                   MinimumAllowedAge=@MinimumAllowedAge,
                                   ValidityLength = @ValidityLength,
                                       ClassFee = @ClassFee,
                                       WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LicenseClassID", System.Data.SqlDbType.Int).Value = LicenseClassID;
            command.Parameters.Add("@ClassName", System.Data.SqlDbType.NVarChar, 200).Value = ClassName;
            command.Parameters.Add("@MinimumAllowedAge", System.Data.SqlDbType.Int).Value = MinimumAllowedAge;
            command.Parameters.Add("@ValidityLength", System.Data.SqlDbType.Int).Value = ValidityLength;
            command.Parameters.Add("@ClassFee", System.Data.SqlDbType.Decimal).Value = ClassFee;
          

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while updating the License Class.", ex);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool FindLicenseClassByID(int LicenseClassID, ref string ClassName,  ref int MinimumAllowedAge, ref int ValidityLength, ref decimal ClassFee)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM LicenseClass
                                  WHERE LicenseClassID=@LicenseClassID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@LicenseClassID", System.Data.SqlDbType.Int).Value = LicenseClassID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassName = (string)reader["ClassName"];
                    ValidityLength = (int)reader["ValidityLength"];
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    ClassFee = (decimal)reader["ClassFee"];

                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the license Class by ID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }

        public static DataTable GetAllLicenseClasses()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from LicenseClass;";

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
    }
}
