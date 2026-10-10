using DTO_Project;
using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Project.Sechdule_Tests;
using Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Project.People.ucSearchPerson;

namespace Project.Application_Licenses
{
    public partial class FrmManageLocalDrivingLicense : Form
    {

        public enum enTestStatus
        {
            NotTaken,
            Failed,
            Passed
        }
        private int _SelectedApplicationID = -1;
        int selectedApplicationID=-1;
        private int _TestTypeID = -1;
        public FrmManageLocalDrivingLicense()
        {
            InitializeComponent();

            ucSearchPerson1.SearchClicked += ucSearchPerson1_SearchClicked;
            ucSearchPerson1.AddClicked += ucSearchPerson1_AddClicked;

        }

       
        private enTestStatus GetTestStatus(int applicationID, int testTypeID)
        {
            int? result = ClsTestResult.GetLatestTestResult(applicationID, testTypeID);

            if (result == null)
                return enTestStatus.NotTaken;

            if (result == 0)
                return enTestStatus.Failed;

            return enTestStatus.Passed;
        }

        private void _Add()
        {
            FrmNewLocalDrivingLicenese localDrivingLicenese = new FrmNewLocalDrivingLicenese(-1);

            localDrivingLicenese.ShowDialog();

        }

        private void ucSearchPerson1_AddClicked(object sender, EventArgs e)
        {
            _Add();

        }
        private void ucSearchPerson1_SearchClicked(object sender, SearchEventArgs e)
        {

            dgvLocalLicenseApplication.DataSource =
            ClsNewDrivingLicenseApplication.SearchLocalLinceseApplications(
                e.Search,
                e.FilterValue
            );


        }
        private void _LoadLocalLicenseApplicationData()
        {
            dgvLocalLicenseApplication.DataSource = ClsNewDrivingLicenseApplication.GetAllLocalLinceseApplications();
        }

        private void FrmManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            
     

            ucSearchPerson1.SetFilters(new List<string>()
              {
                    "All",
                    "NationalID"
                  
              });

            _LoadLocalLicenseApplicationData();
        }
       
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenseApplication.CurrentRow == null)
            {
                MessageBox.Show("Please select an application.");
                return;
            }

            selectedApplicationID = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
                frmShowLicenseApplications frmShowLicense = new frmShowLicenseApplications(selectedApplicationID);

            frmShowLicense.ShowDialog();
        }

        private void LoadTestStatus()
        {
            int applicationID = _SelectedApplicationID;
            if (applicationID == -1)
            {
                MessageBox.Show($@"ApplicaitonID= {applicationID}");
                return;

            }
            int? visionResult =ClsTestResult.GetLatestTestResult(applicationID, 1);

            int? writtenResult =  ClsTestResult.GetLatestTestResult(applicationID, 2);

            int? streetResult = ClsTestResult.GetLatestTestResult(applicationID, 3);

            // Vision
            scheduleVisionTestToolStripMenuItem.Enabled =visionResult != 1;

            // Written requires Vision to be passed
            scheduleWrittenTestToolStripMenuItem.Enabled =visionResult == 1 && writtenResult != 1;

            // Street requires Written to be passed
            schedulePracticalTestToolStripMenuItem.Enabled = writtenResult == 1 && streetResult != 1;

           
        }
        private void LoadApplicationActions()
        {
           
            if (_SelectedApplicationID == -1)
                return;
          
            bool visionPassed =ClsTestResult.HasPassedTest(_SelectedApplicationID, 1);

            bool writtenPassed = ClsTestResult.HasPassedTest(_SelectedApplicationID, 2);

            bool streetPassed = ClsTestResult.HasPassedTest(_SelectedApplicationID, 3);

            bool allTestsPassed =visionPassed &&writtenPassed &&streetPassed;

            schduleTestsToolStripMenuItem.Enabled= !allTestsPassed;

            bool licenseIssued = ClsLocalLicense.DoesLicenseExistByApplicationID(_SelectedApplicationID);
            // Tests
            scheduleVisionTestToolStripMenuItem.Enabled = !visionPassed;
            scheduleWrittenTestToolStripMenuItem.Enabled = visionPassed && !writtenPassed;
            schedulePracticalTestToolStripMenuItem.Enabled = writtenPassed && !streetPassed;

            // Issue License
            if(allTestsPassed)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
            else
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            if(allTestsPassed&&licenseIssued)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
     
            // License information
            showLicenseInfoToolStripMenuItem.Enabled =licenseIssued;

            // Application operations
            editApplicationToolStripMenuItem.Enabled =!licenseIssued;

            deleteApplicationToolStripMenuItem.Enabled =!licenseIssued;

            cancelApplicationToolStripMenuItem.Enabled =!licenseIssued;

            showApplicationDetailsToolStripMenuItem.Enabled= !licenseIssued;
            
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _TestTypeID = Convert.ToInt32(scheduleVisionTestToolStripMenuItem.Tag);
          int SelectedIndex = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
                frmSechduleVisionTest sechduleVisionTest = new frmSechduleVisionTest(SelectedIndex, _TestTypeID);
                sechduleVisionTest.ShowDialog();

              
        }

        //private void FrmManageLocalDrivingLicense_Shown(object sender, EventArgs e)
        //{
        //    LoadTestStatus();
        //}

        private void dgvLocalLicenseApplication_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                dgvLocalLicenseApplication.ClearSelection();
                dgvLocalLicenseApplication.Rows[e.RowIndex].Selected = true;

                _SelectedApplicationID = Convert.ToInt32(
                    dgvLocalLicenseApplication.Rows[e.RowIndex]
                        .Cells["ApplicationID"].Value);
            }
        }

        private void cmsLocalDrivingLicenseOperation_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalLicenseApplication.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

            _SelectedApplicationID = Convert.ToInt32( dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);

            LoadTestStatus();

            LoadApplicationActions();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedIndex = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
            int TestTypeID = Convert.ToInt32(scheduleWrittenTestToolStripMenuItem.Tag);
            FrmWrittenTestAppointment WrittenTestAppointments = new FrmWrittenTestAppointment(SelectedIndex, TestTypeID);
            WrittenTestAppointments.ShowDialog();
        }

        private void schedulePracticalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedIndex = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
            int TestTypeID = Convert.ToInt32(schedulePracticalTestToolStripMenuItem.Tag);
            FrmStreetTestAppointments streetTestAppointments = new FrmStreetTestAppointments(SelectedIndex, TestTypeID); 
            streetTestAppointments.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedIndex = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
           FrmIssueDrivingLicenseTheFirstTime  issueDrivingLicenseTheFirstTime = new FrmIssueDrivingLicenseTheFirstTime(SelectedIndex);
            issueDrivingLicenseTheFirstTime.ShowDialog();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseID = ClsLocalLicense.GetLocalLicenseIDByApplicationID( _SelectedApplicationID);
            FrmShowLocalLicense showLocalLicense=new FrmShowLocalLicense(localLicenseID);
            showLocalLicense.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedIndex = Convert.ToInt32(dgvLocalLicenseApplication.CurrentRow.Cells["ApplicationID"].Value);
            ClsNewDrivingLicenseApplication licenseApplication =ClsNewDrivingLicenseApplication.Find(SelectedIndex);
            int PersonID = licenseApplication.ApplicationPersonID;
            ClsPerson person=ClsPerson.Find(PersonID);
            FrmLicenseHistory licenseHistory = new FrmLicenseHistory(person.PersonID, SelectedIndex);
            licenseHistory.ShowDialog();
        }

        private void ucSearchPerson1_SearchClicked_1(object sender, SearchEventArgs e)
        {

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


