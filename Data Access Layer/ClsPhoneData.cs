using DVLD_DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsPhoneData
    {

        public static int AddNewPhone(string Phone, int PersonID)
        {
            int PhoneID = -1;


            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO Phone(Phone, PersonID)
                                 VALUES(@Phone, @PersonID);
                                 SELECT SCOPE_IDENTITY();";


                using (SqlCommand command =
                        new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Phone",
                        SqlDbType.NVarChar, 50).Value = Phone;

                    command.Parameters.Add("@PersonID",
                        SqlDbType.Int).Value = PersonID;


                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int InsertID))
                        {
                            PhoneID = InsertID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return PhoneID;
        }


        public static bool FindPhoneInfoByID(int PhoneID,
            ref string Phone,
            ref int PersonID)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                   new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"SELECT *
                                 FROM Phone
                                 WHERE PhoneID = @PhoneID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PhoneID",
                        SqlDbType.Int).Value = PhoneID;


                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Phone = (string)reader["Phone"];
                                PersonID = (int)reader["PersonID"];
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


        public static bool DeletePhoneInfo(int PhoneID)
        {
            int rowsAffected = 0;


            using (SqlConnection connection =
                   new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"DELETE FROM Phone
                                 WHERE PhoneID = @PhoneID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PhoneID",
                        SqlDbType.Int).Value = PhoneID;


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


        public static DataTable GetAllPhone()
        {
            DataTable dt = new DataTable();


            using (SqlConnection connection =
                   new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"SELECT *
                                 FROM Phone;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
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


        public static bool IsPhoneExist(int PhoneID)
        {
            using (SqlConnection connection =
                   new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1
                                 FROM Phone
                                 WHERE PhoneID = @PhoneID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PhoneID",
                        SqlDbType.Int).Value = PhoneID;


                    try
                    {
                        connection.Open();

                        return command.ExecuteScalar() != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }


        public static bool UpdatePhoneInfo(int PhoneID,
            string Phone,
            int PersonID)
        {
            int rowsAffected = 0;


            using (SqlConnection connection =
                   new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE Phone
                                 SET Phone = @Phone,
                                     PersonID = @PersonID
                                 WHERE PhoneID = @PhoneID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Phone",
                        SqlDbType.NVarChar, 50).Value = Phone;

                    command.Parameters.Add("@PersonID",
                        SqlDbType.Int).Value = PersonID;

                    command.Parameters.Add("@PhoneID",
                        SqlDbType.Int).Value = PhoneID;


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


        public static DataTable GetPhonesByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();


            using (SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString))
            {

                string query = @"
            SELECT *
            FROM Phone
            WHERE PersonID = @PersonID";


                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {

                    command.Parameters.Add(
                        "@PersonID",
                        SqlDbType.Int).Value = PersonID;


                    connection.Open();


                    SqlDataReader reader =
                        command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }

                }
            }


            return dt;
        }
    }
}