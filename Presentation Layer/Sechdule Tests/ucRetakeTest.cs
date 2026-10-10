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
    public partial class ucRetakeTest : UserControl
    {

        int _TestTypeID = -1;
        public ucRetakeTest()
        {
            InitializeComponent();
        }

        public  void loadData(int RTestApplicationID)
        {
            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(6);
            ClsTestType testType = ClsTestType.FindTestTypeByID(1);
            if (RTestApplicationID > 0)
            {
                lblRAppFees.Text = applicationType._ApplicationFees.ToString();
                lblTotalFee.Text = (applicationType._ApplicationFees + testType._Fees).ToString();
                lblRTestAppID.Text = RTestApplicationID.ToString();
            }
            else
            {
                lblRAppFees.Text = applicationType._ApplicationFees.ToString();
                lblTotalFee.Text = (applicationType._ApplicationFees + testType._Fees).ToString();
                lblRTestAppID.Text = "N/A";
            }
        }

      
    }
}
//stop here the problem is how to send manage if the user has failed the test and
//how to manage the retake test fees and
//how to manage the retake test application id
//if it is failed then the test fee should be 0 and the retake test application id should be 0
//Otherwise the test fee should be the test fee and the retake test application id should be the retake test application id

