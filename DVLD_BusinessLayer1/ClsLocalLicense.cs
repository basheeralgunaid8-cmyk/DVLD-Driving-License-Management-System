using DTO_Project;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BusinessLayer1.ClsNewDrivingLicenseApplication;

namespace DVLD_BusinessLayer1
{
    public class ClsLocalLicense
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;

        public string LicenseClass { get; set; } = string.Empty;
        public int _LocalLicenseID { get; set; }
        public  string _LicenseNumber { get; set; }

        public int _DriverID { get; set; }
        public int _ApplicationLicenseClassID { get; set; }
        public DateTime _IssueDate { get; set; } = DateTime.MinValue;
        public DateTime ExpiredDate { get; set; } = DateTime.MaxValue;
        public string _LicenseStatus { get; set; } = string.Empty;
        public int _CreatedByUserID { get; set; }

        public int ? _ParentLocalLicenseID { get; set; }

        public string _Notes { get; set; }

        public string _IssueReason { get; set; }


        public ClsLocalLicense()
        {
            this._LocalLicenseID = -1;
            this._LicenseNumber = string.Empty;
            this._ParentLocalLicenseID = -1;
            this._DriverID = -1;
            this._ApplicationLicenseClassID = -1;
            this._IssueDate = DateTime.MinValue;
            this.ExpiredDate = DateTime.MaxValue;
            this._LicenseStatus = string.Empty;
            this._CreatedByUserID = -1;
            this._Notes = string.Empty;
            this._IssueReason = string.Empty;

            Mode = enMode.AddNew;
          
        }

        public ClsLocalLicense(int LocalLicenseID, string LicenseNumber, int DriverID, int ApplicationLicenseClassID,
            DateTime IssueDate, DateTime ExpiredDate, string LicenseStatus, int CreatedByUserID,
            string Notes,string IssueReason, int? ParentLocalLicenseID)
        {
            this._LocalLicenseID = LocalLicenseID;
            this._LicenseNumber = LicenseNumber;
            this._ParentLocalLicenseID = ParentLocalLicenseID; 
            this._DriverID = DriverID;
            this._ApplicationLicenseClassID = ApplicationLicenseClassID;
            this._IssueDate = IssueDate;
            this.ExpiredDate = ExpiredDate;
            this._LicenseStatus = LicenseStatus;
            this._CreatedByUserID = CreatedByUserID;
            this._Notes = Notes;
            this._IssueReason= IssueReason;
            Mode = enMode.UpdateMode;
        }

        private bool _AddNewLocalLicense()
        {
            this._LocalLicenseID = ClsLocalLicenseClassData.AddNewLocalLicense(this._LicenseNumber, this._DriverID, this._ApplicationLicenseClassID,
                this._IssueDate, this.ExpiredDate, this._LicenseStatus, this._CreatedByUserID,this._IssueReason,this._Notes,this._ParentLocalLicenseID);
            return (this._LocalLicenseID != -1);
        }

        public static ClsLocalLicense FindLicenseInfoByLocalLicenseID(int LocalLicenseID)
        {


            string LicenseNumber = "";
            int DriverID = -1;
            int ApplicationLicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string LicenseStatus = "";
            int CreatedByUserID = -1;
            string Notes = "";
            string IssueReason = "";
            int ? ParentLocalLicenseID = -1;
            if (ClsLocalLicenseClassData.FindLicenseInfoByLocalLicenseID(
                  LocalLicenseID,
                ref LicenseNumber,
                ref DriverID,
                ref ApplicationLicenseClassID,
                ref IssueDate,
                ref ExpirationDate,
                ref LicenseStatus,
                ref CreatedByUserID,
                ref Notes,
                ref IssueReason,
                ref ParentLocalLicenseID))
            {   return new ClsLocalLicense(LocalLicenseID, LicenseNumber, DriverID, ApplicationLicenseClassID,
                    IssueDate, ExpirationDate, LicenseStatus, CreatedByUserID, Notes, IssueReason, ParentLocalLicenseID);
            }

          

            return null;
        }
        public static LocalLicenseInfoDTO GetApplicationBasicInfo(int LocalLicenseID)
        {

            var dto = ClsLocalLicenseClassData.GetLocalLicenseInfoData(LocalLicenseID);

            return dto;

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewLocalLicense();
                case enMode.UpdateMode:
                   return ClsLocalLicenseClassData.DeactivateLicense( _LocalLicenseID,_LicenseStatus);

            }
            return false;
        }


          public static bool  DoesLicenseExist(int ID)
        {
            return ClsLocalLicenseClassData.DoesLicenseExist(ID);
        }

        public static bool DoesLicenseExistByApplicationID(int applicationID)
        {
            return ClsLocalLicenseClassData.DoesLicenseExistByApplicationID(applicationID);
        }
        public static bool DoesLicenseExistByLocalLicenseID(int LocalLicenseID)
        {
            return ClsLocalLicenseClassData.DoesLicenseExistByLocalLicenseID(LocalLicenseID);
        }

        public static int GetLocalLicenseIDByApplicationID(int ApplicationID)
        {
            return ClsLocalLicenseClassData.GetLocalLicenseIDByApplicationID(ApplicationID);
        }

        public static LocalLicenseInfoDTO FindLicenseInfoByLocalLicenseID1(int localLicenseID)
        {
            return ClsLocalLicenseClassData.FindLicenseInfoByLocalLicenseID(localLicenseID);
        }

        public static DataTable GetLocalLicenseInfo(int applicaitonID)
        {
            return ClsLocalLicenseClassData.GetAllLocalLicenseInfo(applicaitonID);
        }
        public bool IsValid()
        {
            return ExpiredDate > DateTime.Now;
        }
        public static bool DeactivateLicense(int LocalLicenseID)
        {
            return ClsLocalLicenseClassData.DeactivateLicense(  LocalLicenseID,  "Inactive");
        }
        //public static int CreateRenewalLocalLicense(int parentLocalLicense, int DriverID, int createdByUserID, int ApplicationLicenseClassID,int LicenseClassID)
        //{
        //    ClsLicenseClass licenseClass = ClsLicenseClass.FindApplicationTypeByID(LicenseClassID);
        //    if (licenseClass == null)
        //        return -1;

        //    DateTime issueDate = DateTime.Now;
        //    DateTime expirationDate = issueDate.AddYears(licenseClass._ValidityLength);

        //    ClsLocalLicense localLicense = new ClsLocalLicense();
        //    Random random = new Random();

        //    localLicense._LicenseNumber = random.Next(100000, 999999).ToString();
        //    localLicense._DriverID = DriverID;
        //    localLicense._ApplicationLicenseClassID = ApplicationLicenseClassID;
        //    localLicense._IssueDate = issueDate;
        //    localLicense.ExpiredDate = expirationDate;
        //    localLicense._LicenseStatus = "Active";
        //    localLicense._CreatedByUserID = createdByUserID;
        //    localLicense._IssueReason = "Renewal";
        //    localLicense._Notes = "License renewed.";
        //    localLicense._ParentLocalLicenseID = parentLocalLicense;
        //    localLicense.Mode = ClsLocalLicense.enMode.AddNew;

         

        //    if (localLicense.Save())
        //        return localLicense._LocalLicenseID;

        //    return -1;
        //}
        public static int CreateLocalLicenseBasedOnApplicationType(  int parentLocalLicense, int driverID,   int createdByUserID,
     int applicationLicenseClassID,
     int licenseClassID,
     enApplicationType applicationType)
        {
            ClsLicenseClass licenseClass =  ClsLicenseClass.FindApplicationTypeByID(licenseClassID);

            if (licenseClass == null)
                return -1;

            string issueReason;

            switch (applicationType)
            {
                case enApplicationType.enLost:
                    issueReason = "Lost";
                    break;

                case enApplicationType.enDamaged:
                    issueReason = "Damaged";
                    break;
                case enApplicationType.enRenewal:
                    issueReason = "Renewal";
                    break;

                default:
                    return -1;
            }

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate =issueDate.AddYears(licenseClass._ValidityLength);
            ClsLocalLicense localLicense =  new ClsLocalLicense();
            Random random = new Random();
            localLicense._LicenseNumber =  random.Next(100000, 999999).ToString();
            localLicense._DriverID =    driverID;
            localLicense._ApplicationLicenseClassID =   applicationLicenseClassID;
            localLicense._IssueDate =  issueDate;
            localLicense.ExpiredDate =   expirationDate;
            localLicense._LicenseStatus =      "Active";
            localLicense._CreatedByUserID =  createdByUserID;
            localLicense._IssueReason =  issueReason;
            localLicense._Notes ="License " + issueReason;
            localLicense._ParentLocalLicenseID = parentLocalLicense;
            localLicense.Mode =   ClsLocalLicense.enMode.AddNew;
            if (localLicense.Save())
                return localLicense._LocalLicenseID;

            return -1;
        }
        public static bool DoesLicenseStillActive(int LocalLicenseID)
        {
            return ClsLocalLicenseClassData.DoesLicenseStillActive(LocalLicenseID);
        }
    }
}
