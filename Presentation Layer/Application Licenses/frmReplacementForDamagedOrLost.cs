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
using static Project.Application_Licenses.ucFilterLocalLicenseForLostorDamaged;

namespace Project.Application_Licenses
{
    public partial class frmReplacementForDamagedOrLost : Form
    {

        private int _LicenseID = -1;
        private int _ApplicationID = -1;

      
        public enum enReplacement
        {
            enLost=1,
            enDamaged=2
        }
        public enReplacement replacement { get; set; }
        public frmReplacementForDamagedOrLost()
        {
            InitializeComponent();
            ucFilterLocalLicenseForLostorDamaged1.SearchClicked += ucFilterLocalLicenseForLostorDamaged1_SearchClicked;
            ucFilterLocalLicenseForLostorDamaged1.ReplacementReasonSelected += ucFilterLocalLicenseForLostorDamaged1_ReplacementReasonSelected;
        }

        private void ucFilterLocalLicenseForLostorDamaged1_SearchClicked(object sender, ucFilterLocalLicenseForLostorDamaged.SearchEventArgs e)
        {
            _LicenseID = e.SearchValue;
            _ApplicationID = ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);
 

        }
        private void ucFilterLocalLicenseForLostorDamaged1_ReplacementReasonSelected( object sender, ReplacementReasonEventArgs e)
        {
            
            switch (e.Reason)
            {
                case enReplacementReason.Lost:
                    lblTitle.Text = "Replacement for Lost License";
                    break;
                case enReplacementReason.Damaged:
                    lblTitle.Text = "Replacement for Damaged License ";
                    break;
                default:
                    MessageBox.Show("there is no reasion");
                    break;

            }
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {

            // 1. Find the Local License
            ClsLocalLicense localLicense =ClsLocalLicense.FindLicenseInfoByLocalLicenseID(_LicenseID);

            if (localLicense == null)
            {
                MessageBox.Show(
                    "Local license not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 2. Get the original ApplicationID
            int originalApplicationID =ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);

            if (originalApplicationID == -1)
            {
                MessageBox.Show(
                    "Original application not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 3. Check Driver
            if (localLicense._DriverID == -1)
            {
                MessageBox.Show(
                    "The driver ID of this license does not exist.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

           


            // 4. Check if the license is still Active
            if (!ClsLocalLicense.DoesLicenseStillActive(_LicenseID))
            {
                MessageBox.Show(
                    "The selected license is inactive and cannot be reissued.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 5. Determine the selected application type
            enApplicationType applicationType =  enApplicationType.enLost;   // or enDamaged

            int ApplicationTypeID=(int)applicationType;
            // 6. Check whether this application type already exists
            if (ClsNewDrivingLicenseApplication.IsApplicationTypeExists(
                    originalApplicationID,
                    applicationType))
            {
                MessageBox.Show(
                    "An application of this type has already been created for this license.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // 7. Get Application information
            ApplicationBasicInfoDTO licenseApplication =  ClsNewDrivingLicenseApplication.GetApplicationBasicInfo( originalApplicationID);

            if (licenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int personID = licenseApplication.PersonID;

            ClsDriver driver = ClsDriver.FindByPersonID(personID);

            if (driver == null)
            {
                MessageBox.Show(
                    "Driver not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            // 8. Get Application Type
            ClsApplicationType applicationTypeInfo =ClsApplicationType.FindApplicationTypeByID(  (int)applicationType);

            if (applicationTypeInfo == null)
            {
                MessageBox.Show(
                    "Application type not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 9. Get License Class
            int licenseClassID =  ClsApplicationLicenseClass.GetLicenseClassIDByApplicationID(  originalApplicationID);

            if (licenseClassID == -1)
            {
                MessageBox.Show(
                    "License class not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            ClsLicenseClass licenseClass = ClsLicenseClass.FindApplicationTypeByID(licenseClassID);

            if (licenseClass == null)
            {
                MessageBox.Show(
                    "License class not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 10. Get Replacement Application Fee
            decimal replacementApplicationFees = applicationTypeInfo._ApplicationFees;


            // 11. Create Replacement Application
            int applicationID =  ClsNewDrivingLicenseApplication.CreateDamagedOrLostApplication( originalApplicationID, personID, clsGlobal.userID, applicationType);

            if (applicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create replacement application.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 12. Create NEW ApplicationLicenseClass
            ClsApplicationLicenseClass applicationLicenseClass =   new ClsApplicationLicenseClass();

            applicationLicenseClass._ApplicationID = applicationID;
            applicationLicenseClass._LicenseClassID = licenseClassID;

            if (!applicationLicenseClass.Save())
            {
                MessageBox.Show(
                    "Failed to create Application License Class.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int newApplicationLicenseClassID =    applicationLicenseClass._ApplicationLicenseClassID;

            if (newApplicationLicenseClassID == -1)
            {
                MessageBox.Show(
                    "Failed to create Application License Class.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 13. Create NEW Local License
            int replacementLocalLicenseID = ClsLocalLicense.CreateLocalLicenseBasedOnApplicationType( _LicenseID,   driver._DriverID, clsGlobal.userID,
                    newApplicationLicenseClassID,
                    licenseClassID,
                    enApplicationType.enLost);

            if (replacementLocalLicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to create replacement license.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 14. Deactivate OLD Local License
            localLicense._LicenseStatus = "Inactive";
            localLicense.Mode =ClsLocalLicense.enMode.UpdateMode;

            if (!localLicense.Save())
            {
                MessageBox.Show(
                    "Failed to deactivate the old license.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // 15. Mark Replacement Application as Completed
            ClsNewDrivingLicenseApplication replacementApplication = ClsNewDrivingLicenseApplication.Find(applicationID);

            if (replacementApplication != null)
            {
                replacementApplication._ApplicationStatus =
                    "Completed";

                replacementApplication.Mode =
                    ClsNewDrivingLicenseApplication.enMode.UpdateMode;

                if (!replacementApplication.Save())
                {
                    MessageBox.Show(
                        "License was replaced, but the application status could not be updated.",
                        "Replace License",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }


            // 16. Show the new license information
            ucFilterLocalLicenseForLostorDamaged1.LoadReplacementInfo(applicationID, _LicenseID, replacementLocalLicenseID, ApplicationTypeID);


            // 17. Success
            MessageBox.Show(
                "License replaced successfully.",
                "Replace License",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

       
    }
}
