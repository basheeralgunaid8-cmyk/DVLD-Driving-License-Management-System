using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace Project.Application_Licenses
{
    public partial class FrmNewLocalDrivingLicenese : Form
    {

     
        private int _PersonID = -1;
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;

        int _ApplicationID;
        ClsNewDrivingLicenseApplication _DrivingLicenseApplicaiton;
        public FrmNewLocalDrivingLicenese(int ApplicationID)
        {

          
            InitializeComponent();
            personalInfo1.SearchClicked += PersonalInfo_SearchClicked;
            _ApplicationID = ApplicationID;
            if(_ApplicationID ==-1)
            {
                _Mode = Mode.AddNewMode;
                _DrivingLicenseApplicaiton = new ClsNewDrivingLicenseApplication();
            }
            else
            {
                _Mode = Mode.UpdateMode;
                _DrivingLicenseApplicaiton = null;//later we will use it for the update 
            }
        }

        private void _LoadUserData()
        {
            if (_Mode == Mode.AddNewMode)
            {
                _DrivingLicenseApplicaiton = new ClsNewDrivingLicenseApplication();
                return;
            }
            if (_DrivingLicenseApplicaiton == null)
            {
                MessageBox.Show("Application is Not Found");
                this.Close();
                return;
            }

        }
        private void PersonalInfo_SearchClicked(object sender, PersonalInfo.SearchEventArgs e)
        {
            ClsPerson person = e.Person;


            // store it for creating user
            _PersonID = person.PersonID;


        }

        private void _FillAllLicenseClassTypesInComboBox()
        {
            DataTable dt = ClsLicenseClass.GetAllApplicationTypesInfo();

            cmbLicenseClass.DataSource = dt;

            cmbLicenseClass.DisplayMember = "ClassName";

            cmbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _FillAllApplicationTypesInComboBox()
        {
            DataTable dt = ClsApplicationType.GetAllApplicationTypesInfo();

            cmbApplicationType.DataSource = dt;

            cmbApplicationType.DisplayMember = "ApplicationTypeTitle";

            cmbApplicationType.ValueMember = "ApplicationTypeID";
        }
        private void FrmNewLocalDrivingLicenese_Load(object sender, EventArgs e)
        {

            _LoadUserData();
            personalInfo1.SetFilters(new List<string>()
              {
                    "All",
                    "NationalID"
                   
              });

            _FillAllLicenseClassTypesInComboBox();
            _FillAllApplicationTypesInComboBox();
            cmbApplicationStatus.Items.Add("New");
            cmbApplicationStatus.Items.Add("Cancelled");
            cmbApplicationStatus.Items.Add("Completed ");

            cmbApplicationStatus.SelectedIndex = 0;
            lblApplicationFee.Text = "15";
            lblCreatedBy.Text = clsGlobal.Username;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _DrivingLicenseApplicaiton.ApplicationPersonID = _PersonID;

            _DrivingLicenseApplicaiton._ApplicationTypeID =Convert.ToInt32(cmbApplicationType.SelectedValue);

            _DrivingLicenseApplicaiton._ApplicationDate =dtpApplicationDate.Value;

            _DrivingLicenseApplicaiton._ApplicationStatus =
                cmbApplicationStatus.SelectedItem?.ToString();

            _DrivingLicenseApplicaiton._CreatedByUserID =
                clsGlobal.userID;

            _DrivingLicenseApplicaiton._ApplicationFees =
                Convert.ToDecimal(lblApplicationFee.Text);


            int LicenseClassID =
                Convert.ToInt32(cmbLicenseClass.SelectedValue);


            // Check business rule BEFORE creating the new application
            if (_DrivingLicenseApplicaiton.IsLicenseClassExists(
                _DrivingLicenseApplicaiton.ApplicationPersonID,
                LicenseClassID))
            {
                MessageBox.Show(
                    "This person already has this license class.");

                return;
            }


            // Create Application
            if (_DrivingLicenseApplicaiton.Save())
            {
                int ApplicationID =
                    _DrivingLicenseApplicaiton._ApplicationID;

                lblApplicationID.Text =
                    ApplicationID.ToString();


                // Create relationship
                ClsApplicationLicenseClass applicationLicenseClass =
                    new ClsApplicationLicenseClass();

                applicationLicenseClass._ApplicationID =
                    ApplicationID;

                applicationLicenseClass._LicenseClassID =
                    LicenseClassID;


                if (applicationLicenseClass.Save())
                {
                    MessageBox.Show(
                        "A new application saved successfully.");
                }
                else
                {
                    MessageBox.Show(
                        "Application was saved, but the license class could not be saved.");
                }
            }
            else
            {
                MessageBox.Show("Failed to save application.");
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_PersonID == -1)
            {
                MessageBox.Show("Please select a person first.");
                return;
            }
            tabControl1.SelectedTab = tabPage2;
            


        }
    }
}