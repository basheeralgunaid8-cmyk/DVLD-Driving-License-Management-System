using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_DataAccessLayer1
{
    public  class ClsApplicationLicenseClassData
    {

        public static int AddNewApplicationLicenseClass(int ApplicationID,int LicenseClassID)
        {

            int ApplicaitonLicenseClassID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query= @"INSERT INTO ApplicationLicenseClass (ApplicationID,LicenseClassID)
                             VALUES(@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand commmand = new SqlCommand(query, connection);

            commmand.Parameters.Add("@ApplicationID", System.Data.SqlDbType.Int).Value = ApplicationID;
            commmand.Parameters.Add("@LicenseClassID", System.Data.SqlDbType.Int).Value = LicenseClassID;

            try
            {
                connection.Open();
                object result = commmand.ExecuteScalar();

                if(result !=null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ApplicaitonLicenseClassID = InsertID;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while updating the application type.", ex);
            }
            finally
            {
                connection.Close();
            }

            return ApplicaitonLicenseClassID;
        }

        public static bool FindApplictionLicenseClassByID(int ApplicationID, ref int ApplicationLicenseClassID, ref int licenseClassID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM ApplicationLicenseClass
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


                    ApplicationLicenseClassID = (int)reader["ApplicationLicenseClassID"];
                    licenseClassID = (int )reader["licenseClassID"];

                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the ApplicationLicenseClassID  by ID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }

        public static int GetLicenseClassIDByApplicationID(int ApplicationID)
        {
            int LicenseClassID = -1;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT LicenseClassID
            FROM ApplicationLicenseClass
            WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int)
                        .Value = ApplicationID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            LicenseClassID = Convert.ToInt32(result);
                        }
                    }
                    catch
                    {
                        LicenseClassID = -1;
                    }
                }
            }

            return LicenseClassID;
        }
    }
}
