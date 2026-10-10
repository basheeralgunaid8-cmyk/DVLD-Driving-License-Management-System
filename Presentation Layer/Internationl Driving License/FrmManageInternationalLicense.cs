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

namespace Project.Internationl_Driving_License
{
    public partial class FrmManageInternationalLicense : Form
    {
        public FrmManageInternationalLicense()
        {
            InitializeComponent();
            ucSearchPerson1.SearchClicked += ucSearchPerson1_SearchClicked;
        }

        private void _LoadInternationalLicenseInfo()
        {
            dgvInternationalLicenseApplication.DataSource = ClsInternationalLicense.GetAllInterantionalLicense();
        }

        private void FrmManageInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicenseInfo();
        }

        private void ucSearchPerson1_SearchClicked(object sender, People.ucSearchPerson.SearchEventArgs e)
        {

        }
    }
}
