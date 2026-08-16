using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public class ClsCountries
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CountryID { get; set; }
        public string CountryName { get; set; }
       

        public ClsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";

            Mode = enMode.AddNew;

        }

        private ClsCountries(int countryID, string CountryName)

        {
            this.CountryID = countryID;
            this.CountryName = CountryName;
           
            Mode = enMode.Update;
        }

        //private bool _AddNewCountry()
        //{
        //    this.CountryID = clsCountry.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);
        //    return (CountryID != -1);
        //}
        public static ClsCountries Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountry.FindCountryInfoByID(CountryID, ref CountryName))
                return new ClsCountries(CountryID, CountryName);
            else
                return null;
        }
        public static ClsCountries Find(string CountryName)
        {

            int ID = -1;
           


            if (clsCountry.GetCountryInfoByName(CountryName, ref ID))

                return new ClsCountries(ID, CountryName);
            else
                return null;

        }

        //public static bool DeleteCountry(int ID)
        //{
        //    return (clsCountry.DeleteCountry(ID));
        //}

        //private bool _UpdateCountry()
        //{
        //    return clsCountry.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);
        //}

        //public bool SaveCountry()
        //{



        //    switch (Mode)
        //    {
        //        case enMode.AddNew:
        //            if (_AddNewCountry())
        //            {

        //                Mode = enMode.Update;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        case enMode.Update:
        //            return _UpdateCountry();
        //    }

        //    return false;
        //}

        public static DataTable GetAllCountries()
        {
            return clsCountry.GetAllCountries();
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountry.IsCountryExist(ID);
        }


    }
}
