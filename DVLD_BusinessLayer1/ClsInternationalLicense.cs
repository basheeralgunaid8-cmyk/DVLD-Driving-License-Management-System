using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public  class ClsInternationalLicense
    {

                public enum enMode
                {
                    AddNew,
                    UpdateMode
                }


           public enMode Mode = enMode.AddNew;
           public int InternationalLicenseID { get; set; }

            public int LocalLicenseID { get; set; }
            public string InternationalLicenseNumber { get; set; } = string.Empty;
            public DateTime IssueDate { get; set; } = DateTime.MinValue;
            public decimal IssueFees { get; set; }
            public string LicenseStatus { get; set; } = string.Empty;
            public int CreatedByUserID { get; set; }
            public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;


            // ───────── Constructor 1: parameterless ─────────
            public ClsInternationalLicense()
            {
                InternationalLicenseID = -1;
                LocalLicenseID = -1;
                InternationalLicenseNumber = string.Empty;
                IssueDate = DateTime.MinValue;
                IssueFees = 0m;
                LicenseStatus = string.Empty;
                CreatedByUserID = 0;
                ExpirationDate = DateTime.MaxValue;
                Mode = enMode.AddNew;

            }
 

        public ClsInternationalLicense(int internationalLicenseID, int localLicenseID,   string internationalLicenseNumber, DateTime issueDate, decimal issueFees,
                string licenseStatus,int createdByUserID,  DateTime expirationDate)
            {
                this.InternationalLicenseID = internationalLicenseID;
                this.LocalLicenseID = localLicenseID;
                this.InternationalLicenseNumber = internationalLicenseNumber;
                this.IssueDate = issueDate;
                this.IssueFees = issueFees;
                this.LicenseStatus = licenseStatus;
                this.CreatedByUserID = createdByUserID;
                this.ExpirationDate = expirationDate;
                Mode = enMode.UpdateMode;
  
        }

        private bool _AddNewInternationalLicense()
        {
            InternationalLicenseID = ClsInternationalLicenseData.AddNewInternationalLicense(this.LocalLicenseID, this.InternationalLicenseNumber, this.IssueDate, this.IssueFees,
                this.LicenseStatus, this.CreatedByUserID, this.ExpirationDate);
            return (InternationalLicenseID != -1);
        }

      public static bool DoesInternationalLicenseExistByLocalLicenseID(int LicenseID)
        {
            return ClsInternationalLicenseData.DoesInternationalLicenseExistByLocalLicenseID(LicenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return false;
            }
            return false;
        }

        public static DataTable GetInternationalLicenseInfo(int ApplicationId)
        {
            return ClsInternationalLicenseData.GetInternationalLicenseInfoByApplicationID(ApplicationId);
        }

        public static DataTable GetAllInterantionalLicense()
        {
            return ClsInternationalLicenseData.GetAllInterantionalLicense1();
        }
    }
}
