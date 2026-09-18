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
   
    public class ClsTestTypeData
    {

        public static bool UpdateTestType(int TestTypeID, string Title ,string Description, decimal Fees)
        {


            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE TestType
                                 SET Title=@Title,
                                   Description=@Description,
                                   Fees = @Fees 
                                       WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@TestTypeID", System.Data.SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar, 200).Value = Title;
            command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 200).Value = Description;
            command.Parameters.Add("@Fees", System.Data.SqlDbType.Decimal).Value = Fees;


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception("An error occurred while updating the Test type.", ex);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool FindTestTypeByID(int TestTypeID,ref string Title, ref string Description, ref decimal Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM TestType
                                  WHERE TestTypeID=@TestTypeID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@TestTypeID", System.Data.SqlDbType.Int).Value = TestTypeID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    Title = (string)reader["Title"];
                    Description = (string)reader["Description"];
                    Fees = (decimal)reader["Fees"];

                }

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while finding the Tes type by ID.", ex);
            }

            finally
            {
                connection.Close();

            }
            return IsFound;
        }

        public static DataTable GetAllTestTypes()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from TestType;";

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
