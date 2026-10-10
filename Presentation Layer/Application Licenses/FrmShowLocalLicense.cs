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
    public partial class FrmShowLocalLicense : Form
    {

        int _LocalLicenseID;
        public FrmShowLocalLicense(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
        }

        private void FrmShowLocalLicense_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseInfo1.LoadDrivingLicenseDataByID(_LocalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
