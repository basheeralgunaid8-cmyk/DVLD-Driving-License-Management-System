using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_Project;
namespace DVLD_DataAccessLayer1
{
    
 public class ClsUserData
    {

       

        public static int AddNewUser(string userName,string PasswordHash, int PersonID, bool isActive, string fullName )
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"INSERT INTO User_ (UserName,PasswordHash,PersonID,IsActive,FullName)
                             VALUES(@UserName, @PasswordHash, @PersonID, @IsActive, @FullName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 50).Value = userName;
            command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.NVarChar, 50).Value = PasswordHash;
            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@FullName", System.Data.SqlDbType.NVarChar, 200).Value = fullName;
            try
            {
                connection.Open();
              
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    UserID = InsertID;
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
            return UserID;
        }


        //Filter by PersonID
        public static bool FindUserInfoByID(int UserID,ref string UserName, ref string PasswordHash, ref int PersonID, ref bool isActive, ref string fullName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM User_
                                  WHERE UserID=@UserID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    PasswordHash = (string)reader["PasswordHash"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                    fullName = (string)reader["FullName"];
                  
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

        //Filter by National ID
        public static bool FindUserInfoByUserName(ref int UserID,string UserName, ref string PasswordHash, ref int PersonID, ref bool isActive, ref string fullName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM User_
                                  WHERE UserName=@UserName;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar).Value = UserName;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    PasswordHash = (string)reader["PasswordHash"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                    fullName = (string)reader["FullName"];

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
        //Filter by FirstName
      
        public static bool UpdateUserInfo(int UserID, string userName, string PasswordHash, int PersonID, bool isActive, string fullName  )

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"UPDATE User_
                                            SET 
                                                UserName=@UserName,
                                                PasswordHash=@PasswordHash,
                                                PersonID=@PersonID,
                                                IsActive=@IsActive
                                            WHERE UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 50).Value = userName;
            command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.NVarChar, 50).Value = PasswordHash;
            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@FullName", System.Data.SqlDbType.NVarChar, 20).Value = fullName;
           
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

        public static DataTable GetAllUsers()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from User_;";

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

        public static bool IsUserExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from User_ where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"UserID", System.Data.SqlDbType.Int).Value = ID;

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

        public static bool IsUserNameExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from User_ where UserName=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"UserName", System.Data.SqlDbType.NVarChar, 50).Value = UserName;

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

        public static bool IsLoginExist(string UserName,string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from User_ where UserName=@UserName and PasswordHash=@PasswordHash";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"UserName", System.Data.SqlDbType.NVarChar, 50).Value = UserName;
            command.Parameters.Add(@"PasswordHash", System.Data.SqlDbType.NVarChar, 50).Value = Password;
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

        public static bool DeleteUserInfo(int ID)
        {
            int rowAfficted = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Delete from User_
                  where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"UserID", System.Data.SqlDbType.Int).Value = ID;

            try
            {
                connection.Open();
                rowAfficted = command.ExecuteNonQuery();
                if (rowAfficted > 0)
                {
                    return true;
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
            return (rowAfficted > 0);
        }

        public static DataTable SearchUsers(string searchText, string filterColumn)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                  new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string query = "";

                switch (filterColumn)
                {
                    case "All":

                        query = @"SELECT *
                          FROM User_
                          WHERE UserName LIKE @Search
                          OR NationalID LIKE @Search";

                        break;


                       //by Name
                    case "UserName":

                        query = @"SELECT *
                          FROM People
                          WHERE FirstName LIKE @Search";

                        break;
                       //by User ID
                    case "UserID":

                        query = @"SELECT *
                          FROM People
                          WHERE UserID LIKE @Search";
                        break;

                        //by Person ID

                    case "PersonID":

                        query = @"SELECT *
                          FROM People
                          WHERE PersonID LIKE @Search";
                        break;

                    case "IsActive":

                        query = @"SELECT *
                          FROM People
                          WHERE IsActive LIKE @Search";
                        break;

                    // exception for invalid filter

                    default:

                        throw new Exception("Invalid search filter");

                }


                using (SqlCommand command =
                      new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Search",
                        SqlDbType.NVarChar, 100)
                        .Value = "%" + searchText + "%";


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
        
        public static bool LoginUserInfoByUserNameAndPassword(ref int ID, string UserName,  string PasswordHash, ref int PersonID, ref bool isActive, ref string fullName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM User_
                                  WHERE UserName=@UserName AND PasswordHash=@PasswordHash;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 100).Value = UserName;
            command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.NVarChar, 100).Value = PasswordHash;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;


                    ID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    PasswordHash = (string)reader["PasswordHash"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                    fullName = (string)reader["FullName"];

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

        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from User_ where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"PersonID", System.Data.SqlDbType.Int).Value = ID;

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



        public static List<UserDTO> SearchUsersBy(string Search,string filterColumn)
        {
            List<UserDTO> users = new List<UserDTO>();

            SqlConnection connection =
                new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "";

            switch (filterColumn)
            {
                case "All":

                    query = @"
                                SELECT *
                                FROM User_
                                WHERE 
                                UserID LIKE @Search
                                OR UserName LIKE @Search
                                OR PersonID LIKE @Search
                                OR IsActive LIKE @Search";

                    break;


                case "UserID":

                    query = @"
                                    SELECT *
                                    FROM User_
                                    WHERE CAST(UserID AS NVARCHAR) LIKE @Search";

                    break;


                case "Username":

                    query = @"
                                        SELECT *
                                        FROM User_
                                        WHERE UserName LIKE @Search";

                    break;


                case "PersonID":

                    query = @"
                                                SELECT *
                                                FROM User_
                                                WHERE CAST(PersonID AS NVARCHAR) LIKE @Search";

                    break;


                case "IsActive":

                    query = @"
                                                        SELECT *
                                                        FROM User_
                                                        WHERE IsActive = @Search";

                    break;


                default:
                    throw new Exception("Invalid filter");
            }

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("@Search", SqlDbType.NVarChar).Value = Search ;


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                 while (reader.Read())
                {
                    UserDTO user = new UserDTO();

                    user.UserID = (int)reader["UserID"];

                    user.UserName = (string)reader["UserName"];

                    user.PasswordHash = (string)reader["PasswordHash"];

                    user.PersonID = (int)reader["PersonID"];

                    user.IsActive = (bool)reader["IsActive"];

                    user.FullName = reader["FullName"] == DBNull.Value
                 ? ""
                 : (string)reader["FullName"];

                    users.Add(user);
                }
            }
            finally
            {
                connection.Close();
            }


            return users;
        }
    }
}
