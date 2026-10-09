using DVLD_BusinessLayer;
using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using DTO_Project;
namespace DVLD_BusinessLayer1
{
    public class ClsUser
    {
        public enum enMode
        {
            AddNew = 0,
            UpdateMode = 1
        }


        public enMode Mode { get; set; }


        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PasswordHash { get; set; }

        public bool IsActive { get; set; }

        // Relationship: One Person -> Many Phones
        public List<clsPhone> Phones { get; set; }

        public ClsUser()
        {
            UserID = -1;
            PersonID = -1;
            FullName = string.Empty;
            UserName = string.Empty;
            PasswordHash = string.Empty;
            IsActive = false;
            Mode = enMode.AddNew;
        }


        public ClsUser(
            int userID,
            string userName,
            string passwordHash,
            int personID,
            bool isActive,
            string fullName
            )
        {

            UserID = userID;

            UserName = userName;

            PasswordHash = passwordHash;

            PersonID = personID;

            IsActive = isActive;

            FullName = fullName;

            Mode = enMode.UpdateMode;
        }

        private bool _AddNewUser()
        {

            UserID =
                ClsUserData.AddNewUser(
                    UserName,
                    PasswordHash,
                    PersonID,
                    IsActive,
                    FullName
                );


            return UserID != -1;
        }


        private bool _UpdateUser()
        {
            return ClsUserData.UpdateUserInfo(
                    UserID,
                    UserName,
                    PasswordHash,
                    PersonID,
                    IsActive,
                    FullName
            );
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewUser())
                    {
                        Mode = enMode.UpdateMode;

                        return true;
                    }

                    return false;



                case enMode.UpdateMode:

                    return _UpdateUser();

            }


            return false;
        }

        public static ClsUser Find(int ID)
        {
            bool isActive = false;
            string UserName = "";
            string passwordHash = "";
            string fullName = "";
            

            int personId= -1;

            if (ClsUserData.FindUserInfoByID(
                ID,
                ref UserName,
                ref passwordHash,
                ref personId,
                ref isActive,
                ref fullName))
            {
                return new ClsUser(ID, UserName, passwordHash, personId, isActive, fullName);

               
            }


            return null;
        }
        public static ClsUser FindbyUserName(string UserName)
        {
            bool isActive = false;
          
            string passwordHash = "";
            string fullName = "";

            int UserID = -1;
            int personId = -1;

            if (ClsUserData.FindUserInfoByUserName(
                ref UserID,
                UserName,
                ref passwordHash,
                ref personId,
                ref isActive,
                ref fullName))
            {
                return new ClsUser(UserID, UserName, passwordHash, personId, isActive, fullName);


            }


            return null;
        }

        public static ClsUser Login(string UserName, string passwordHash)
        {
            bool isActive = false;
          
            string fullName = "";


            int personId = -1;
            int ID = -1;





            if (ClsUserData.LoginUserInfoByUserNameAndPassword(
               ref  ID,
                 UserName,
                 passwordHash,
                ref personId,
                ref isActive,
                ref fullName))
            {
                return new ClsUser(ID, UserName, passwordHash, personId, isActive, fullName);


            }


            return null;
        }

        public static DataTable GetAllUsersInfo()
        {
            return  ClsUserData.GetAllUsers();
        }

        public static bool IsUserExists(int ID)
        {
            return ClsUserData.IsUserExist(ID);
        }

        public static bool IsLoginUserExists(string username ,string password)
        {
            return ClsUserData.IsLoginExist(username, password);
        }

        public static bool IsPersonExistsInUserTable(int ID)
        {
            return ClsUserData.IsPersonExist(ID);
        }
        public static bool DeleteUser(int ID)
        {
            return ClsUserData.DeleteUserInfo(ID);
        }

        //instead of returning a DataTable, we can return a List<UserDTO> for better type safety and easier manipulation in the business layer.
        public static  List<UserDTO> Search(string search, string filterColumn)
        {
            return ClsUserData.SearchUsersBy(search, filterColumn);
        }

      
    }
}
