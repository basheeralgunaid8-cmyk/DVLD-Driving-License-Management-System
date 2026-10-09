using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public  class clsGlobal
    {
        public static int userID { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }
        public static int PersonID { get; set; }

        public static bool IsActive { get; set; }
        public static bool IsLoggedIn()
        {
            return userID > 0;
        }

        public static void Logout()
        {
            userID = -1;
            PersonID = -1;
            Username = "";
            Password = " ";
            IsActive = false;
        }
    }

}
