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
    public partial class frmDetainedlicenseApplication : Form
    {
        private int _LicenseID = -1;
      
        public frmDetainedlicenseApplication()
        {
            InitializeComponent();
            ucFilterDetainApplicationLicense1.SearchClicked += ucFilterDetainApplicationLicense1_SearchClicked;
        }

        private void ucFilterDetainApplicationLicense1_SearchClicked(object sender, ucFilterDetainApplicationLicense.SearchEventArgs e)
        {
            _LicenseID = e.SearchValue;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // 1. Find the Local License
            ClsLocalLicense localLicense = ClsLocalLicense.FindLicenseInfoByLocalLicenseID(_LicenseID);

            if (localLicense == null)
            {
                MessageBox.Show(
                    "Local license not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int originalApplicationID = ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(_LicenseID);

            if (originalApplicationID == -1)
            {
                MessageBox.Show(
                    "Original application not found.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
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
                    "The selected license is inactive and cannot be detained.",
                    "Replace License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            // 5. Determine the selected application type



            // 7. Get Application information
            ApplicationBasicInfoDTO licenseApplication = ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(originalApplicationID);

            if (licenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Detain License",
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
                    "Detain License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
          
                bool isDetained = ClsDetainedLicenseApplicationBlayer.IsLicenseDetained(_LicenseID);
                if (isDetained)
                {
                    MessageBox.Show(
                        "This license is already detained.",
                        "Detain License",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                decimal _FineFees;
                if (!decimal.TryParse(txtFineFees.Text.Trim(), out _FineFees))
                {
                    MessageBox.Show("请输入有效的金额！");
                    return;
                }

                int DetainedID = ClsDetainedLicenseApplicationBlayer.CreateDetainLocalLicense(_LicenseID, _FineFees, isDetained, clsGlobal.userID);
                if (DetainedID == -1)
                {
                    MessageBox.Show(
                        "Failed to create Detain license.",
                        "Detain License",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // 14. Deactivate OLD Local License
                localLicense._LicenseStatus = "Inactive";
                localLicense.Mode = ClsLocalLicense.enMode.UpdateMode;

                if (!localLicense.Save())
                {
                    MessageBox.Show(
                        "Failed to deactivate the old license.",
                        "Replace License",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                ucFilterDetainApplicationLicense1.LoadDetainedInfo(DetainedID, _LicenseID);

                MessageBox.Show(
                   "License detained successfully.",
                   "Detain License",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
