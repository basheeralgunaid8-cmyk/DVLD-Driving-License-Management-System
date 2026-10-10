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
    public partial class frmShowLicenseApplications : Form
    {

        int _ApplicationID;
        public frmShowLicenseApplications(int ApplicaitonID)
        {
            InitializeComponent();
            _ApplicationID = ApplicaitonID;
        }

        private void frmShowLicenseApplications_Load(object sender, EventArgs e)
        {
            ucLicenseApplicationBasicInfo1.LoadApplication(_ApplicationID);
            ucDrivingLicenseApplicationInfo1.LoadDrivingLicenseData(_ApplicationID);
        }
    }
}
