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

namespace Project.Application_Licenses
{
    public partial class ucFilterApplicaitonDetainLicense : UserControl
    {

        int LocalLicenseID = -1;
        public class SearchEventArgs : EventArgs
        {
            public int SearchValue { get; set; }
            public decimal RenewalApplicationFee { get; set; }


        }
        public event EventHandler<SearchEventArgs> SearchClicked;
        public event EventHandler IssueClicked;

        public ucFilterApplicaitonDetainLicense()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out int searchValue))
            {
                MessageBox.Show(
                    "Please enter a valid license ID.",
                    "Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            int ApplicationID = ClsNewDrivingLicenseApplication.GetApplicationIDByLocalLicenseID(searchValue);
            if (ApplicationID == -1)
            {
                MessageBox.Show(
                    "No application found for the given license ID.",
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }


            LocalLicenseInfoDTO localLicense = ClsLocalLicense.FindLicenseInfoByLocalLicenseID1(searchValue);
            if (localLicense == null)
            {
                MessageBox.Show(
                    "No license found.",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            ucDrivingLicenseInfo1.LoadingLocalLicenseInfo(localLicense);

            SearchEventArgs args = new SearchEventArgs();
            args.SearchValue = searchValue;
            SearchClicked?.Invoke(this, args);
        }

        public void LoadReleaseApplicationInfo(int LocalLicenseID, int ApplicationID, int ApplicationTypeID)
        {
            ucReleaseApplicationBasicInfo1.LoadApplicationBasicInfo(LocalLicenseID, ApplicationID, ApplicationTypeID);
        }
    }
}
