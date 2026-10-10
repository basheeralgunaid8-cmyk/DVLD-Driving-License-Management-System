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
    public partial class FrmUpdateWrittenTestAppointment : Form
    {

        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;
        private int _AppointmentID;
        private ClsAppointments _appointments;
        private int _ApplicationID;
        private int _TestTypeID;
        private int _RTestApplicationID = -1;
        ClsTestType _testType;
        public FrmUpdateWrittenTestAppointment(int appointmentID, int applicationid, int TesttypeID, int RTestApplicationID)
        {
            _AppointmentID = appointmentID;
            _ApplicationID = applicationid;
            _TestTypeID = TesttypeID;
            _RTestApplicationID = RTestApplicationID;
            InitializeComponent();

            if (_AppointmentID > 0)
            {
                _Mode = Mode.UpdateMode;

                _appointments =
                    ClsAppointments.FindAppointmentIDByID(_AppointmentID);
            }
            else
            {
                _Mode = Mode.AddNewMode;

                _appointments =
                    new ClsAppointments();
            }
        }

        private void _LoadAppointmentData()
        {

            ucWrittenTest1.LoadData(_ApplicationID, _TestTypeID);

            if (_appointments == null)
                return;

            if (_appointments._IsLocked)
            {
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                lblNote.Text = "Please already sat for this test,this appointment is already locked.";
            }

            bool hasFailedTest = ClsTestResult.HasFailedTest(_ApplicationID, _TestTypeID);
            if (hasFailedTest)
            {
                ucRetakeTest1.Enabled = hasFailedTest;
            }

            ucRetakeTest1.loadData(_RTestApplicationID);
        }

        private void FrmUpdateWrittenTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadAppointmentData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_appointments == null)
            {
                MessageBox.Show("Appointment not found.");
                return;
            }

            if (_appointments._IsLocked)
            {
                MessageBox.Show("This appointment is already locked.");
                return;
            }

            _appointments._AppointmentDate = dtpDate.Value;

            if (_appointments.Save())
            {
                MessageBox.Show(
                    "Appointment updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _LoadAppointmentData();
            }
            else
            {
                MessageBox.Show(
                    "Appointment could not be updated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            _LoadAppointmentData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
