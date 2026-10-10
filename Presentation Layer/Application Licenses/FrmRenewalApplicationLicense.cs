using DTO_Project;
using DVLD_BusinessLayer1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static DVLD_BusinessLayer1.ClsNewDrivingLicenseApplication;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Application_Licenses
{
    public partial class FrmRenewalApplicationLicense : Form
    {
        private int _LicenseID = 1;
        private int _ApplicationID = -1;
        private int _PersonID = -1;
        public FrmRenewalApplicationLicense()
        {
            InitializeComponent();
            ucFilterApplicationNewLicenseInfo1.SearchClicked += UcFilterApplicationNewLicenseInfo1_SearchClicked;
        }

        private void UcFilterApplicationNewLicenseInfo1_SearchClicked(object sender, ucFilterApplicationNewLicenseInfo.SearchEventArgs e)
        {
           _LicenseID = e.SearchValue;
            _ApplicationID = ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // 1. Find the Local License
            ClsLocalLicense localLicense =  ClsLocalLicense.FindLicenseInfoByLocalLicenseID(_LicenseID);

            if (localLicense == null)
            {
                MessageBox.Show(
                    "Local license not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 2. Check whether the license is expired
            if (localLicense.IsValid())
            {
                MessageBox.Show(
                    "The selected license is still valid and cannot be renewed.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 3. Get the original ApplicationID
            int originalApplicationID = ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);

            if (originalApplicationID == -1)
            {
                MessageBox.Show(
                    "Original application not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 4. Get Application information
            ApplicationBasicInfoDTO licenseApplication =ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(originalApplicationID);

            if (licenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int personID = licenseApplication.PersonID;

            // 5. Find Driver
            ClsDriver driver =ClsDriver.FindByPersonID(personID);

            if (driver == null)
            {
                MessageBox.Show(
                    "Driver not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 6. Check whether a renewal application already exists
            int renewalApplicationID =ClsNewDrivingLicenseApplication.GetRenewalApplicationIDByParentApplicationID(originalApplicationID, 2);
            bool renewalExists = ClsNewDrivingLicenseApplication.IsApplicationTypeExists(  originalApplicationID,  enApplicationType.enRenewal);
            if (renewalExists)
            {
                MessageBox.Show(
                    "A renewal application has already been created for this license.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
       

                return;
            }
           
            // 7. Get Renewal Application Type
            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(2);

            if (applicationType == null)
            {
                MessageBox.Show(
                    "Renewal application type not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 8. Get License Class
            int licenseClassID =  ClsApplicationLicenseClass.GetLicenseClassIDByApplicationID(originalApplicationID);

            if (licenseClassID == -1)
            {
                MessageBox.Show(
                    "License class not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            ClsLicenseClass licenseClass = ClsLicenseClass.FindApplicationTypeByID(licenseClassID);

            if (licenseClass == null)
            {
                MessageBox.Show(
                    "License class not found.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 9. Calculate Renewal Application Fees
            decimal renewalApplicationFees =applicationType._ApplicationFees + 20.0m;


            // 10. Create Renewal Application
            renewalApplicationID = ClsNewDrivingLicenseApplication.CreateRenewalApplication(originalApplicationID,  personID, clsGlobal.userID,renewalApplicationFees);

            if (renewalApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create renewal application.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 11. Create NEW ApplicationLicenseClass
            ClsApplicationLicenseClass applicationLicenseClass = new ClsApplicationLicenseClass();

            applicationLicenseClass._ApplicationID =renewalApplicationID;

            applicationLicenseClass._LicenseClassID = licenseClassID;

            if (!applicationLicenseClass.Save())
            {
                MessageBox.Show(
                    "Failed to create Application License Class.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            int newApplicationLicenseClassID =applicationLicenseClass._ApplicationLicenseClassID;

            if (newApplicationLicenseClassID == -1)
            {
                MessageBox.Show(
                    "Failed to create Application License Class.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int renewalLocalLicenseID = ClsLocalLicense.CreateLocalLicenseBasedOnApplicationType(_LicenseID, driver._DriverID, 
                clsGlobal.userID, newApplicationLicenseClassID, 
                licenseClassID,enApplicationType.enRenewal);

            localLicense._LicenseStatus = "Inactive";
            localLicense.Mode = ClsLocalLicense.enMode.UpdateMode;

            if (!localLicense.Save())
            {
                MessageBox.Show(
                    "Failed to deactivate the old license.",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (renewalLocalLicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to create Local License .",
                    "Renew License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // 15. Mark Renewal Application as Completed
            ClsNewDrivingLicenseApplication renewalApplication = ClsNewDrivingLicenseApplication.Find(renewalApplicationID);
           
            if (renewalApplication != null)
            {
                renewalApplication._ApplicationStatus ="Completed";

                renewalApplication.Mode =ClsNewDrivingLicenseApplication.enMode.UpdateMode;

                if (!renewalApplication.Save())
                {
                    MessageBox.Show(
                        "License was renewed, but the renewal application status could not be updated.",
                        "Renew License",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            // 16. Success
            MessageBox.Show(
                "License renewed successfully.",
                "Renew License",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ucFilterApplicationNewLicenseInfo1.loadInfo(renewalApplicationID, _LicenseID, renewalLocalLicenseID, licenseClassID);
        }

    }   
    
}
