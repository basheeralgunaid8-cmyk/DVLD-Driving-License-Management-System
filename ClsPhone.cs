using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_BusinessLayer
{
    public class clsPhone
    {
        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;


        public int PhoneID { get; set; }

        public string Phone { get; set; }

        public int PersonID { get; set; }



        public clsPhone()
        {
            PhoneID = -1;
            Phone = string.Empty;
            PersonID = -1;
        }


        public clsPhone(int phoneID, string phone, int personID)
        {
            PhoneID = phoneID;
            Phone = phone;
            PersonID = personID;

            Mode = enMode.UpdateMode;
        }



        private bool _AddNewPhone()
        {
            PhoneID =
                clsPhoneData.AddNewPhone(
                    Phone,
                    PersonID);

            return PhoneID != -1;
        }



        private bool _UpdatePhone()
        {
            return clsPhoneData.UpdatePhoneInfo(
                PhoneID,
                Phone,
                PersonID);
        }



        public bool SavePhone()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPhone())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }

                    return false;


                case enMode.UpdateMode:

                    return _UpdatePhone();
            }

            return false;
        }


        public static List<clsPhone> GetPhonesByPersonID(int PersonID)
        {
            List<clsPhone> phones = new List<clsPhone>();

            DataTable dt = clsPhoneData.GetPhonesByPersonID(PersonID);


            foreach (DataRow row in dt.Rows)
            {
                clsPhone phone = new clsPhone();

                phone.PhoneID = (int)row["PhoneID"];

                phone.Phone = row["Phone"].ToString();

                phone.PersonID = (int)row["PersonID"];

                phone.Mode = enMode.UpdateMode;


                phones.Add(phone);
            }


            return phones;
        }
    }
}
        
    
