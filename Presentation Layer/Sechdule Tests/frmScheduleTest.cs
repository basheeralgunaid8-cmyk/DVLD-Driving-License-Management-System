using DTO_Project;
using DVLD_BusinessLayer1;
using Microsoft.VisualBasic;
using Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.People.PersonDetail;
using static Project.Sechdule_Tests.ucVisionTest;

namespace Project.Sechdule_Tests
{
    public partial class frmScheduleTest : Form
    {
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;

        int _ApplicationID;
        ClsScheduleTest _ScheduleTest;
        private int _TestTypeID=-1;
        ClsTestType _testType;
        private ApplicationBasicInfoDTO licenseApplication;
        ClsNewDrivingLicenseApplication DrivingLicenseApplication;
        ClsAppointments appointments;
        private int _AppointmentID;
        private int _RTestApplicationID = -1;
        public frmScheduleTest(int ApplicationID,int TestTypeID,int Appointment,int RTestApplicationID)
        {
            InitializeComponent();
            _ApplicationID= ApplicationID;
            _TestTypeID= TestTypeID;
            _RTestApplicationID = RTestApplicationID;
            ucRetakeTest1.Enabled = false;
            _AppointmentID = Appointment;
            if (_AppointmentID > 0)
            {
                _Mode = Mode.UpdateMode;
                appointments = ClsAppointments.FindAppointmentID(_AppointmentID);

            }
        }

    
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

            ucVisionTest1.LoadData(_ApplicationID, _TestTypeID);
            bool hasFailedTest =ClsTestResult.HasFailedTest(_ApplicationID, _TestTypeID);

            if (hasFailedTest)
            {
                ucRetakeTest1.Enabled = hasFailedTest;
                lblTitle.Text = "Retake Test";
            
            }
            ucRetakeTest1.loadData(_RTestApplicationID);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _testType = ClsTestType.FindTestTypeByID(_TestTypeID);
            licenseApplication = ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(_ApplicationID);
            ClsApplicationLicenseClass _ApplicationLicenseClass = ClsApplicationLicenseClass.FindApplicationLicenseByApplicationID(_ApplicationID);
            appointments = new ClsAppointments();
            appointments._PaidFee = _testType._Fees;
            appointments._IsLocked = false;
            appointments._TestTypeID = _TestTypeID;
            appointments._AppointmentDate = dtpAppointmentDate.Value;
            appointments.CreatedByUserID = licenseApplication._CreatedByUserID;

            appointments._ApplicationLicenseClassID = _ApplicationLicenseClass._ApplicationLicenseClassID;



            if (appointments.Save())
            {
                int appointmentID = appointments._AppointmentID;

                MessageBox.Show(
                    "Appointment saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Appointment could not be saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ucVisionTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
