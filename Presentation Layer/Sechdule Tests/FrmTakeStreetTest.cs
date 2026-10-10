using DTO_Project;
using DVLD_BusinessLayer1;
using Microsoft.VisualBasic;
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
    public partial class FrmTakeStreetTest : Form
    {
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;

        int _ApplicationID;
        ClsScheduleTest _ScheduleTest;
        private int _TestTypeID = -1;
        ClsTestType _testType;
        private ApplicationBasicInfoDTO licenseApplication;

        ClsAppointments appointments;
        private int _AppointmentID;
        public FrmTakeStreetTest(int ApplicationID, int TestTypeID, int AppointmentID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }
        private void FindAppointmentByID(int AppointmentID)
        {
            appointments = ClsAppointments.FindAppointmentIDByID(AppointmentID);
        }

        private void FrmTakeStreetTest_Load(object sender, EventArgs e)
        {
            ucStreetTest1.LoadData(_ApplicationID, _TestTypeID);
            FindAppointmentByID(_AppointmentID);
            dtpDate.Value = appointments._AppointmentDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsTestResult testResult = new ClsTestResult();
            FindAppointmentByID(_AppointmentID);
            testResult._Appointment = _AppointmentID;

            if (chPass.Checked)
            {
                testResult.Result = true;

            }
            else
            {
                testResult.Result = false;

            }

            testResult._Notes = txtNotes.Text;
            testResult.Mode = ClsTestResult.enMode.AddNew;

            if (testResult.Save())
            {
                appointments._IsLocked = true;

                if (!appointments.LockAppointment())
                {

                    MessageBox.Show(
                        "Test result was saved, but the appointment could not be locked.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Test Result Saved Successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
        
    }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
