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
using static Project.People.PersonDetail;

namespace Project.Sechdule_Tests
{
    public partial class ucVisionTest : UserControl
    {
        int _ApplicationID;
        ClsScheduleTest _ScheduleTest;
        private int _TestTypeID = -1;
        ClsTestType _testType;



        public ucVisionTest()
        {
            InitializeComponent();

        }

        public void LoadData(int ApplicationID,    int TestTypeID)
        {
             _ApplicationID= ApplicationID;
            _TestTypeID = TestTypeID;
            _testType = ClsTestType.FindTestTypeByID(_TestTypeID);
            if(_testType == null)
            {
                MessageBox.Show("the test type id  has not been found!");
            }
            _ScheduleTest = ClsScheduleTest.FindDrivingLicenseInfo(_ApplicationID);
            if( _ScheduleTest ==null ) 
            {
                MessageBox.Show("the driving license info has not been found!");
            }
            lblApplicationID.Text = _ApplicationID.ToString();
            lblApplicationType.Text = _ScheduleTest._ClassName;
            lblFullName.Text = _ScheduleTest._FullName;
            lblFees.Text = _testType._Fees.ToString();

        }

        private void gbVisionTest_Enter(object sender, EventArgs e)
        {

        }
    }
    }

