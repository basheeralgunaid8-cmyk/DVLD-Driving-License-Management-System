using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BusinessLayer1.ClsNewDrivingLicenseApplication;

namespace DVLD_BusinessLayer1
{
    public class ClsDetainedLicenseApplicationBlayer
    {


        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;
        public int _DetainedID { get; set; }

        public int _LicenseID { get; set; } = -1;
        public DateTime _DetainedDate { get; set; } = DateTime.Now;
        public decimal _FineFees { get; set; } = 0;
        public bool _IsReleased { get; set; } = false;
        public DateTime _ReleaseDate { get; set; } = DateTime.Now;
        public int _CreatedByUserID { get; set; } = -1;
        public int ?_ReleasedByUserID { get; set; } = -1;

        ClsDetainedLicenseApplicationBlayer(int DetainedID, int LicenseID, DateTime DetainedDate,decimal finefees ,bool IsReleased, DateTime ReleaseDate, int CreatedByUserID, int? ReleasedByUserID)
        {
            this._DetainedID = DetainedID;
            this._LicenseID = LicenseID;
            this._DetainedDate = DetainedDate;
            this._FineFees = finefees;
            this._IsReleased = IsReleased;
            this._ReleaseDate = ReleaseDate;
            this._CreatedByUserID = CreatedByUserID;
            this._ReleasedByUserID = ReleasedByUserID;
            Mode = enMode.UpdateMode;
        }

        ClsDetainedLicenseApplicationBlayer()
        {
            this._DetainedID = -1;
            this._LicenseID = -1;
            this._DetainedDate = DateTime.Now;
            this._FineFees = 0;
            this._IsReleased = false;
            this._ReleaseDate = DateTime.Now;
            this._CreatedByUserID = -1;
            this._ReleasedByUserID = null;
            Mode = enMode.AddNew;
        }

        private bool _AddNewDetainedLicense()
        {
            _DetainedID = ClsDetainedLicenseDataALayer.AddNewDetainedLicense(_LicenseID, _DetainedDate, _FineFees, _IsReleased, _ReleaseDate, _CreatedByUserID, _ReleasedByUserID);
            return (_DetainedID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            return ClsDetainedLicenseDataALayer.UpdateReleaseInfo(_DetainedID, _ReleaseDate,_IsReleased, _ReleasedByUserID ?? -1);
        }
        
        public static ClsDetainedLicenseApplicationBlayer Find(int LocalLicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int CreatedByUserID = -1;
            int ReleasedByUserID = -1;

            if (ClsDetainedLicenseDataALayer.FindDetainInfobyLocalLicenseID(
                ref DetainID,
                LocalLicenseID,
                ref DetainDate,
                ref FineFees,
                ref IsReleased,
                ref ReleaseDate,
                ref CreatedByUserID,
                ref ReleasedByUserID))
            {
                ClsDetainedLicenseApplicationBlayer detainedLicense =
                    new ClsDetainedLicenseApplicationBlayer(
                        DetainID,
                        LocalLicenseID,
                        DetainDate,
                        FineFees,
                        IsReleased,
                        ReleaseDate,
                        CreatedByUserID,
                        ReleasedByUserID
                    );

                return detainedLicense;
            }

            return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                   
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdateDetainedLicense();
            }
            return false;


        }
        public static int CreateDetainLocalLicense(int LocalLicenseID,decimal FineFees,bool IsReleased,int createdByUserID)


        { 
            DateTime DetainDate = DateTime.Now;
            ClsDetainedLicenseApplicationBlayer detainedLicenseApplicationBlayer   = new ClsDetainedLicenseApplicationBlayer();
            detainedLicenseApplicationBlayer._LicenseID= LocalLicenseID;
            detainedLicenseApplicationBlayer._DetainedDate= DetainDate;
            detainedLicenseApplicationBlayer._FineFees= FineFees;
            detainedLicenseApplicationBlayer._IsReleased= IsReleased;
            detainedLicenseApplicationBlayer._CreatedByUserID = createdByUserID;
            detainedLicenseApplicationBlayer._ReleasedByUserID = null;
            detainedLicenseApplicationBlayer.Mode = enMode.AddNew;


            if (detainedLicenseApplicationBlayer.Save())
                return detainedLicenseApplicationBlayer._DetainedID;

            return -1;
        }
       public static bool IsLicenseDetained(int licenseID)
        {
            return ClsDetainedLicenseDataALayer.IsLicenseDetained(licenseID);
        }
    }
}
