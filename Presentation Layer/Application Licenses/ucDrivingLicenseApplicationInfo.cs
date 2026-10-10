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
    public partial class ucDrivingLicenseApplicationInfo : UserControl
    {

        int _ApplicationID = -1;
        ClsNewDrivingLicenseApplication _DrivingLicenseApplication;
        public ucDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDrivingLicenseData(int applicationID)
        {
            _ApplicationID = applicationID;
            _LoadData();
        }

       private void _LoadData()
        {
            _DrivingLicenseApplication = ClsNewDrivingLicenseApplication.FindDrivingLicenseInfo(_ApplicationID);
            lblDLApplicationID.Text = _ApplicationID.ToString();
            lblAppliedForLicense.Text = _DrivingLicenseApplication._ClassName;
            if(_DrivingLicenseApplication._Result ==null)
            {
               
                lblPassedTest.Text = $"0/3";
            }
           else
            {
                lblPassedTest.Text =  $"{_DrivingLicenseApplication._Result}/3";
            }

        }
    }
}


