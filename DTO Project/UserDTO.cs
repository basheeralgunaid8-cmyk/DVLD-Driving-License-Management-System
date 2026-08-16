using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Project
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int PersonID { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }
    }
}
