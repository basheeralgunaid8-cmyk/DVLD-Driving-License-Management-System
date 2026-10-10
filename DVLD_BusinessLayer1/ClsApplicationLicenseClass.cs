using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public  class ClsApplicationLicenseClass
    {


        public enum enMode
        {
            AddNew,
            UpdateMode
        }

        public int _ApplicationID { get; set; }
        public int _LicenseClassID { get; set; }

        public int _ApplicationLicenseClassID { get; set; }



        public enMode Mode = enMode.AddNew;

         public    ClsApplicationLicenseClass()
        {
            _ApplicationID = -1;
            _LicenseClassID = -1;
            _ApplicationLicenseClassID = -1;
            Mode= enMode.AddNew;
        }
        public ClsApplicationLicenseClass(int applicationID, int applicationLicenseID,int LicenseID)
        {
            this._ApplicationID=applicationID;
            this._ApplicationLicenseClassID = applicationLicenseID;
            this._LicenseClassID = LicenseID;
        }


        private bool _AddNewApplicationLicenseClass()
        {
            _ApplicationLicenseClassID= ClsApplicationLicenseClassData.AddNewApplicationLicenseClass(_ApplicationID, _LicenseClassID);

            return _ApplicationLicenseClassID != -1;


        }

        public static ClsApplicationLicenseClass FindApplicationLicenseByApplicationID(int ID)
        {
            int applicationLicenseID = -1;
            int licenseClassID = -1;
            if(ClsApplicationLicenseClassData.FindApplictionLicenseClassByID(ID,ref applicationLicenseID,ref licenseClassID))
            {
                return new ClsApplicationLicenseClass(ID, applicationLicenseID, licenseClassID);
            }
            return null;
        }
        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:


                    if (_AddNewApplicationLicenseClass())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }

                    return false;


                case enMode.UpdateMode:

                    return false;

            }


            return false;
        }

        public static int GetLicenseClassIDByApplicationID(int ApplicationID)
        {
            return ClsApplicationLicenseClassData
                .GetLicenseClassIDByApplicationID(ApplicationID);
        }
    }
}
