using DTO_Project;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_BusinessLayer1
{
    public class ClsNewDrivingLicenseApplication
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }

        public enum enApplicationType
        {
            enRenewal=2,
            enLost=3,
            enDamaged=4,
            enRelease=5
        }
        public enMode ApplicationType { get; set; }
        public int _ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public int _ApplicationTypeID { get; set; }
        public DateTime _ApplicationDate { get; set; } = DateTime.Now;
        public decimal _ApplicationFees { get; set; }
        public string _ApplicationStatus { get; set; }
        public int _CreatedByUserID { get; set; }
        public string _ClassName { get; set; }
        public int _Result { get; set; }
        public enMode Mode { get; set; }
        public int? ParentApplicationID { get; set; }
        ClsNewDrivingLicenseApplication(int ApplicationID,int ApplicationPersonID,int ApplicationTypeID, DateTime dateTime, decimal ApplicationFees, string ApplicationStatus, int  CreatedByUserID,int ? parentApplicationID)
        {
            this._ApplicationID = ApplicationID;
             this.ApplicationPersonID = ApplicationPersonID;
            this._ApplicationTypeID = ApplicationTypeID;
            this._ApplicationDate = dateTime;
            this._ApplicationFees = ApplicationFees;
            this._ApplicationStatus = ApplicationStatus;
            this._CreatedByUserID = CreatedByUserID;
            this.ParentApplicationID = parentApplicationID;
            Mode = enMode.UpdateMode;
        }
        ClsNewDrivingLicenseApplication(int ApplicaitonID,string ClassName,int Result)
        {
            this._ApplicationID = ApplicaitonID;
            this._ClassName= ClassName;
            this._Result = Result;
            Mode = enMode.UpdateMode;
        }
        public ClsNewDrivingLicenseApplication()
        {
            _ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this._ApplicationTypeID = -1;
            this._ApplicationDate =DateTime.Now;
            this._ApplicationFees = 0;
            this._ApplicationStatus = string.Empty;
            this._CreatedByUserID = -1;
            ParentApplicationID = null;
            Mode = enMode.AddNew;
        }
        private bool _AddNewDrivingLicense()
        {
            _ApplicationID =
                ClsNewDrivingLicenseData.AddNewDrivingLicense(
                    this.ApplicationPersonID,
                    this._ApplicationTypeID,
                    this._ApplicationDate,
                    this._ApplicationFees,
                    this._ApplicationStatus,
                    this._CreatedByUserID,
                    this.ParentApplicationID);

            return _ApplicationID != -1;
        }
        private bool _UpdateDrivingLicense()
        {
            return ClsNewDrivingLicenseData.UpdateNewDrivingLicenseInfo(this._ApplicationID, this.ApplicationPersonID, this._ApplicationTypeID, this._ApplicationDate, this._ApplicationFees, this._ApplicationStatus, this._CreatedByUserID);
        }
        public static ClsNewDrivingLicenseApplication Find(int ID)
        {
            int applicationPersonID = -1;
            int ApplicationTypeid = -1;
            DateTime ApplicationDate = DateTime.Now;
            string applicationStatus = "";
            decimal ApplicationFees = 0;
            int createdbyUser = -1;
            int? parentApplicationTypeID = null;




            if (ClsNewDrivingLicenseData.FindApplicationInfoByID(
                ID,
                ref applicationPersonID,
                ref ApplicationTypeid,
                ref ApplicationDate,
                ref ApplicationFees,
                ref applicationStatus,
                ref createdbyUser,
                ref parentApplicationTypeID))
            {
                return new ClsNewDrivingLicenseApplication(ID, applicationPersonID, ApplicationTypeid, ApplicationDate, ApplicationFees, applicationStatus, createdbyUser, parentApplicationTypeID);


            }


            return null;
        }
        public static ClsNewDrivingLicenseApplication FindDrivingLicenseInfo(int ID)
        {
            int Result = 0;
            string ClassName = "";
           




            if (ClsNewDrivingLicenseData.GetDrivingLicenseInfo(
                ID,
                ref ClassName,
                ref Result))
            {
                return new ClsNewDrivingLicenseApplication(ID, ClassName, Result);


            }


            return null;
        }
        public static ApplicationBasicInfoDTO GetApplicationBasicInfo(int applicationID)
        {
       
            var dto = ClsNewDrivingLicenseData.GetApplicationBasicInfoData(applicationID);
          
            return dto;

        }
        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewDrivingLicense())
                    {
                        Mode = enMode.UpdateMode;

                        return true;
                    }

                    return false;



                case enMode.UpdateMode:

                    return _UpdateDrivingLicense();

            }


            return false;
        }
        public bool IsLicenseClassExists(int ApplicationID, int licenseClassID)
        {
            return ClsNewDrivingLicenseData.DoesPersonAlreadyHaveLicenseClass(ApplicationID, licenseClassID);
        }
        public static DataTable GetAllLocalLinceseApplications()
        {
            return ClsNewDrivingLicenseData.GetAllLocalLicenseApplication();
        }
        public static DataTable SearchLocalLinceseApplications(string search, string filterColumn)
        {
            if (string.IsNullOrEmpty(search))
            {
                return ClsNewDrivingLicenseData.GetAllLocalLicenseApplication();
            }
            return ClsNewDrivingLicenseData.SearchLocalLicenseApplication( search, filterColumn); ;
        }
        public static int GetApplicationIDByLocalLicenseID(int LocalLicenseID)
        {
            return ClsNewDrivingLicenseData.GetApplicationIDByLocalLicenseID(LocalLicenseID);
        }
        public static int GetRenewalApplicationIDByParentApplicationID(int OriginalApplicationID, int RenewalApplicationTypeID)
        {
            return ClsNewDrivingLicenseData.GetRenewalApplicationIDByParentApplicationID(OriginalApplicationID, RenewalApplicationTypeID);
        }
        public static int CreateRetakeApplication( int parentApplicationID, int personID, int createdByUserID, decimal retakeApplicationFee)
        {
            ClsNewDrivingLicenseApplication application =new ClsNewDrivingLicenseApplication();

            application.ApplicationPersonID = personID;
            application._ApplicationTypeID = 6;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = "New";
            application._CreatedByUserID = createdByUserID;
            application._ApplicationFees = retakeApplicationFee;

            application.ParentApplicationID = parentApplicationID;

            application.Mode =
                ClsNewDrivingLicenseApplication.enMode.AddNew;

            if (application.Save())
                return application._ApplicationID;

            return -1;
        }
        public static int CreateRenewalApplication(int parentApplicationID, int personID, int createdByUserID, decimal renewalApplicationFee)
        {
            ClsNewDrivingLicenseApplication application = new ClsNewDrivingLicenseApplication();

            application.ApplicationPersonID = personID;
            application._ApplicationTypeID = 2;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = "New";
            application._CreatedByUserID = createdByUserID;
            application._ApplicationFees = renewalApplicationFee;

            application.ParentApplicationID = parentApplicationID;

            application.Mode = ClsNewDrivingLicenseApplication.enMode.AddNew;

            if (application.Save())
                return application._ApplicationID;

            return -1;
        }

        //solution 1
        //private static int DetermineApplicaitonType(enApplicationType applicationType)
        //{
        //    int ApplicationTypeID = -1;
        //    switch (applicationType)
        //    {

        //        case enApplicationType.enRenewal:
        //            ApplicationTypeID = (int )enApplicationType.enRenewal;
        //            break;
        //        case enApplicationType.enLost:
        //            ApplicationTypeID = (int)enApplicationType.enLost;
        //            break;
        //        case enApplicationType.enDamaged:
        //            ApplicationTypeID = (int)enApplicationType.enDamaged;
        //            break;
        //        case enApplicationType.enDetained:
        //            ApplicationTypeID = (int)enApplicationType.enDetained;
        //            break;


        //    }
        //    return ApplicationTypeID;
        //}

        //solution 2
        public static bool IsApplicationTypeExists(int OriginalApplicationID, enApplicationType applicationType)
        {
            return ClsNewDrivingLicenseData.IsApplicationTypeExists( OriginalApplicationID, (int)applicationType);
        }
        //solution 3
        //private static int DetermineApplicationType(enApplicationType applicationType)
        //{
        //    return (int)applicationType;
        //}
        //public static bool IsApplicationTypeExists( int OriginalApplicationID, enApplicationType applicationType)
        //{
        //    int ApplicationTypeID = DetermineApplicaitonType(applicationType);
        //    return ClsNewDrivingLicenseData.IsApplicationTypeExists( OriginalApplicationID, ApplicationTypeID);
        //}
        public static int CreateDamagedOrLostApplication(int parentApplicationID, int personID, int createdByUserID, enApplicationType applicationType)
        {
            ClsNewDrivingLicenseApplication application = new ClsNewDrivingLicenseApplication();

            ClsApplicationType applicationType1= ClsApplicationType.FindApplicationTypeByID((int)applicationType);
            if (applicationType1 == null)
                return -1;
            application.ApplicationPersonID = personID;
            application._ApplicationTypeID = (int)applicationType;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = "New";
            application._CreatedByUserID = createdByUserID;
            application._ApplicationFees = applicationType1._ApplicationFees;

            application.ParentApplicationID = parentApplicationID;

            application.Mode = ClsNewDrivingLicenseApplication.enMode.AddNew;

            if (application.Save())
                return application._ApplicationID;

            return -1;
        }

        public static int CreateReleaseLicenseApplication(int parentApplicationID, int personID, int createdByUserID,decimal ReleaseApplicationFees ,enApplicationType applicationType)
        {
            ClsNewDrivingLicenseApplication application = new ClsNewDrivingLicenseApplication();

            ClsApplicationType applicationType1 = ClsApplicationType.FindApplicationTypeByID((int)applicationType);
            if (applicationType1 == null)
                return -1;
            application.ApplicationPersonID = personID;
            application._ApplicationTypeID = (int)applicationType;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = "New";
            application._CreatedByUserID = createdByUserID;
            application._ApplicationFees = ReleaseApplicationFees;

            application.ParentApplicationID = parentApplicationID;

            application.Mode = ClsNewDrivingLicenseApplication.enMode.AddNew;

            if (application.Save())
                return application._ApplicationID;

            return -1;
        }

    }
}
