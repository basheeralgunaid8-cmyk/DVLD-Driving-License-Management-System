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

namespace Project.Sechdule_Tests
{
    public partial class FrmWrittenTestAppointment : Form
    {

        private int _PersonID = -1;
        private int _ApplicationID = -1;
        private int _TestTypeID = -1;
        private ClsAppointments _appointments;
        int _SelectedIndex = -1;
        private int applicationIDToSchedule = -1;
        public FrmWrittenTestAppointment(int ApplicationID, int testTypeID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            _TestTypeID = testTypeID;
        }
        private void _LoadTestAppointmentData()
        {
            dgvAppointmens.DataSource = ClsAppointments.GetWrittenTestAppointmentData(_TestTypeID);
        }

        private void FrmWrittenTestAppointment_Load(object sender, EventArgs e)
        {
            ucLicenseApplicationBasicInfo1.LoadApplication(_ApplicationID);
            ucDrivingLicenseApplicationInfo1.LoadDrivingLicenseData(_ApplicationID);

            _LoadTestAppointmentData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplicationBasicInfoDTO licenseApplication = ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(_ApplicationID);

            if (licenseApplication == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }
            _PersonID = licenseApplication.PersonID;


            // 1. Check for an active appointment
            if (ClsAppointments.DoesPersonHaveActiveAppointment(_PersonID, _TestTypeID))
            {
                MessageBox.Show(
                    "This person already has an active appointment for this test.");

                return;
            }
            // 2. Check whether this test was failed before
            bool hasFailedTest = ClsTestResult.HasFailedTest(_ApplicationID, _TestTypeID);

            int applicationIDToSchedule = -1;

            // 3. If failed before, create a NEW retake application
            if (hasFailedTest)
            {
                decimal retakeApplicationFee = 5;

                int licenseClassID = ClsApplicationLicenseClass.GetLicenseClassIDByApplicationID(_ApplicationID);

                // 2. Create NEW retake application
                int newApplicationID = ClsNewDrivingLicenseApplication.CreateRetakeApplication(_ApplicationID, _PersonID, clsGlobal.userID, retakeApplicationFee);

                if (newApplicationID == -1)
                {
                    MessageBox.Show("Failed to create retake application.");
                    return;
                }

                // 3. Create NEW ApplicationLicenseClass
                ClsApplicationLicenseClass applicationLicenseClass = new ClsApplicationLicenseClass();

                applicationLicenseClass._ApplicationID = newApplicationID;
                applicationLicenseClass._LicenseClassID = licenseClassID;

                if (!applicationLicenseClass.Save())
                {
                    MessageBox.Show(
                        "Failed to create Application License Class.");
                    return;
                }

                // 4. Now we have the new relationship ID
                int newApplicationLicenseClassID = applicationLicenseClass._ApplicationLicenseClassID;

                if (newApplicationLicenseClassID == -1)
                {
                    MessageBox.Show(
                        "Failed to create Application License Class.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                applicationIDToSchedule = newApplicationID;
            }
            bool hasPassedTest = ClsTestResult.HasPassedTest(_ApplicationID, _TestTypeID);
            if (hasPassedTest)
            {
                MessageBox.Show("This person has already passed this test. No retake is allowed.");
                return;
            }
            frmScheduleTest scheduleTest = new frmScheduleTest(_ApplicationID, _TestTypeID, 0, applicationIDToSchedule);
            scheduleTest.ShowDialog();


            _LoadTestAppointmentData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int SelectedIndex = Convert.ToInt32(dgvAppointmens.CurrentRow.Cells[0].Value);
              FrmTakeWrittenTest frmTake = new FrmTakeWrittenTest(_ApplicationID, _TestTypeID, SelectedIndex);
            frmTake.ShowDialog();

        }

        private void EditTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsNewDrivingLicenseApplication licenseApplication = ClsNewDrivingLicenseApplication.Find(_ApplicationID);
            int? newApplicationID = -1;
            if (licenseApplication != null)
            {
                newApplicationID = licenseApplication.ParentApplicationID;
            }
            if (newApplicationID == null)
            {
                MessageBox.Show("No retake application found.");
             
            }

            int SelectedIndex = Convert.ToInt32(dgvAppointmens.CurrentRow.Cells[0].Value);
            FrmUpdateWrittenTestAppointment updateWrittenTestAppointment  = new FrmUpdateWrittenTestAppointment(SelectedIndex, _ApplicationID, _TestTypeID, newApplicationID.Value);
            updateWrittenTestAppointment.ShowDialog();
        }
    }
}
