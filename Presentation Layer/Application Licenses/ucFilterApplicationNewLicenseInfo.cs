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
using System.Web.SessionState;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Application_Licenses
{
    public partial class ucFilterApplicationNewLicenseInfo : UserControl
    {

        int LocalLicenseID = -1;
        public class SearchEventArgs : EventArgs
        {
            public int SearchValue { get; set; }
            public decimal RenewalApplicationFee { get; set; }


        }
        public event EventHandler<SearchEventArgs> SearchClicked;
        public event EventHandler IssueClicked;

    
        public ucFilterApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        public void loadInfo(int applicationInfo,int localLicense,int RenewallocallicensedID,int locallicenseID)
        {
            ucNewApplicationBasicInfo1.LoadingApplicationBasicInfo(applicationInfo, localLicense, RenewallocallicensedID,locallicenseID);
        }

        private void ucDrivingLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}