using DVLD_DataAccessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccessLayer1
{
    public  class ClsApplicationTypeData
    {



        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationName ,decimal ApplicationFees)
        {


            int rowsAffected = 0;
           SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE ApplicationType
                                 SET ApplicationTypeTitle=@ApplicationTypeTitle,
                                   ApplicationFee = @ApplicationFee 
                                       WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ApplicationTypeID", System.Data.SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicationTypeTitle", System.Data.SqlDbType.NVarChar,200).Value = ApplicationName;
            command.Parameters.Add("@ApplicationFee", System.Data.SqlDbType.Decimal).Value = ApplicationFees;


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while updating the application type.", ex);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool FindApplicationTypeByID(int ApplicationID, ref string ApplicationName, ref decimal ApplicationFee)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
           string query = @"SELECT *FROM ApplicationType
                                  WHERE ApplicationTypeID=@ApplicationTypeID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ApplicationTypeID", System.Data.SqlDbType.Int).Value = ApplicationID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationTypeID"];
                    ApplicationName = (string)reader["ApplicationTypeTitle"];
                    ApplicationFee = (decimal)reader["ApplicationFee"];
                    
                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the application type by ID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }
        public static DataTable GetAllApplicationTypes()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from ApplicationType;";

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
