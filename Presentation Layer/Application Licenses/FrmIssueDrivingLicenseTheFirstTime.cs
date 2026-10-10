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

namespace Project.Application_Licenses
{
    public partial class FrmIssueDrivingLicenseTheFirstTime : Form
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }
        public static class ApplicationStatus
        {
            public const string New = "New";
            public const string Cancelled = "Cancelled";
            public const string Completed = "Completed";
        }

        public enMode _Mode = enMode.AddNew;

        private int _ApplicationID;
        public FrmIssueDrivingLicenseTheFirstTime(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void FrmIssueDrivingLicenseTheFirstTime_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseApplicationInfo1.LoadDrivingLicenseData(_ApplicationID);
            ucLicenseApplicationBasicInfo1.LoadApplication(_ApplicationID);
        }


        private void _ApplicationStatus()
        {
            ClsNewDrivingLicenseApplication application =ClsNewDrivingLicenseApplication.Find(_ApplicationID);

            if (application != null)
            {
                application._ApplicationStatus = ApplicationStatus.Completed;

                if (!application.Save())
                {
                    MessageBox.Show(
                        "License was issued, but application status could not be updated.");
                    return;
                }
            }

            if (application._ApplicationStatus == "Cancelled")
            {
                // Disable all processing actions
            }
            else if (application._ApplicationStatus == "Completed")
            {
                // Disable scheduling/issue/edit
                // Allow viewing license
            }
            else if (application._ApplicationStatus == "New")
            {
                // Normal test/application actions
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            ApplicationBasicInfoDTO application = ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(_ApplicationID);

            if (application == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }

            int personID = application.PersonID;

            // 1. Find or create Driver
            ClsDriver driver = ClsDriver.FindByPersonID(personID);

            if (driver == null)
            {
                driver = new ClsDriver();

                driver._PersonID = personID;
                driver.DriverNumber = "DRV-" + personID.ToString("D6");
                driver.DriverStatus = "Active";
                driver.CreatedDate = DateTime.Now;
                driver.CreatedByUserID = clsGlobal.userID;
                driver._Mode = ClsDriver.enMode.AddNew;

                if (!driver.Save())
                {
                    MessageBox.Show("Failed to create driver.");
                    return;
                }
            }

            int driverID = driver._DriverID;


            // 2. Get ApplicationLicenseClass
            ClsApplicationLicenseClass applicationLicenseClass =ClsApplicationLicenseClass.FindApplicationLicenseByApplicationID(_ApplicationID);

            if (applicationLicenseClass == null)
            {
                MessageBox.Show("Application License Class not found.");
                return;
            }

            int applicationLicenseClassID = applicationLicenseClass._ApplicationLicenseClassID;

            int licenseClassID = applicationLicenseClass._LicenseClassID;


            // 3. Get LicenseClass
            ClsLicenseClass licenseClass =  ClsLicenseClass.FindApplicationTypeByID(licenseClassID);

            if (licenseClass == null)
            {
                MessageBox.Show("License Class not found.");
                return;
            }


            // 4. Calculate dates
            DateTime issueDate = DateTime.Now;

            DateTime expirationDate =issueDate.AddYears(licenseClass._ValidityLength);


            // 5. Create LocalLicense
            ClsLocalLicense localLicense = new ClsLocalLicense();
            Random random = new Random();

            localLicense._LicenseNumber =random.Next(100000, 999999).ToString();
            localLicense._CreatedByUserID = clsGlobal.userID;
            localLicense._DriverID = driverID;
            localLicense._ApplicationLicenseClassID = applicationLicenseClassID;
            localLicense._IssueDate = issueDate;
            localLicense.ExpiredDate = expirationDate;
            localLicense._LicenseStatus = "Active";
            localLicense.Mode = ClsLocalLicense.enMode.AddNew;
            localLicense._Notes = txtNotes.Text;
            localLicense._IssueReason = "First Time";
      

            if (localLicense.Save())
            {
                _ApplicationStatus();
                MessageBox.Show("Driving license issued successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Failed to issue driving license.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}