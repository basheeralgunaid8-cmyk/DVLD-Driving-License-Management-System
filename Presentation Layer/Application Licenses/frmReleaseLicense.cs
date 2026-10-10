using DTO_Project;
using DVLD_BusinessLayer1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BusinessLayer1.ClsNewDrivingLicenseApplication;

namespace Project.Application_Licenses
{
    public partial class frmReleaseLicense : Form
    {

        private int _LicenseID = -1;
        public frmReleaseLicense()
        {
            InitializeComponent();
            ucFilterApplicaitonDetainLicense1.SearchClicked += ucFilterApplicaitonDetainLicense1_SearchClicked;
        }
        private void ucFilterApplicaitonDetainLicense1_SearchClicked(object sender, ucFilterApplicaitonDetainLicense.SearchEventArgs e)
        {
            _LicenseID = e.SearchValue;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // 1. Find the Local License
            ClsLocalLicense localLicense =
                ClsLocalLicense.FindLicenseInfoByLocalLicenseID(_LicenseID);

            if (localLicense == null)
            {
                MessageBox.Show(
                    "Local license not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Check whether the license is detained
            bool isDetained = ClsDetainedLicenseApplicationBlayer.IsLicenseDetained(_LicenseID);

            if (!isDetained)
            {
                MessageBox.Show(
                    "The selected license is not detained and cannot be released.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 3. Check the Driver ID
            if (localLicense._DriverID == -1)
            {
                MessageBox.Show(
                    "The driver ID of this license does not exist.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 4. Get the Original Application ID
            int originalApplicationID =    ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);

            if (originalApplicationID == -1)
            {
                MessageBox.Show(
                    "Original application not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 5. Get Application Information
            ApplicationBasicInfoDTO licenseApplication =
                ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(originalApplicationID);

            if (licenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int personID = licenseApplication.PersonID;

            // 6. Check Driver
            ClsDriver driver = ClsDriver.FindByPersonID(personID);

            if (driver == null)
            {
                MessageBox.Show(
                    "Driver not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 7. Check Whether a Release Application Already Exists
            enApplicationType applicationType = enApplicationType.enRelease;

            if (ClsNewDrivingLicenseApplication.IsApplicationTypeExists(
                    originalApplicationID,
                    applicationType))
            {
                MessageBox.Show(
                    "A release application has already been created for this license.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // 8. Get Application Type Information
            ClsApplicationType applicationTypeInfo =
                ClsApplicationType.FindApplicationTypeByID((int)applicationType);

            if (applicationTypeInfo == null)
            {
                MessageBox.Show(
                    "Application type not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 9. Find the Detained License Record
            ClsDetainedLicenseApplicationBlayer detainedLicenseApplication =
                ClsDetainedLicenseApplicationBlayer.Find(_LicenseID);

            if (detainedLicenseApplication == null)
            {
                MessageBox.Show(
                    "Detained license record not found.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal ReleaseApplicationID = applicationTypeInfo._ApplicationFees+detainedLicenseApplication._FineFees;


           // 10. Create the Release Application
            int releaseApplicationID =
                ClsNewDrivingLicenseApplication.CreateReleaseLicenseApplication(
                    originalApplicationID,
                    personID,
                    clsGlobal.userID,
                  ReleaseApplicationID,
                    applicationType);

            if (releaseApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create the release application.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 11. Update the Local License Status
            localLicense._LicenseStatus = "Active";
            localLicense.Mode = ClsLocalLicense.enMode.UpdateMode;

            if (!localLicense.Save())
            {
                MessageBox.Show(
                    "Failed to update the license status.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 12. Update the Detained License Record
            detainedLicenseApplication._ReleasedByUserID = clsGlobal.userID;
            detainedLicenseApplication._ReleaseDate = DateTime.Now;
            detainedLicenseApplication._IsReleased = true;

            detainedLicenseApplication.Mode =
                ClsDetainedLicenseApplicationBlayer.enMode.UpdateMode;

            if (!detainedLicenseApplication.Save())
            {
                MessageBox.Show(
                    "Failed to update the detained license release information.",
                    "Release License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 13. Display the Release Application Information
            ucFilterApplicaitonDetainLicense1.LoadReleaseApplicationInfo(
                _LicenseID,
                releaseApplicationID,
                (int)applicationType);

            MessageBox.Show(
               "'Release License successfully.",
               "Release License",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }


    }
}
