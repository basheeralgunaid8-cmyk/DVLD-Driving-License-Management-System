using DTO_Project;
using DVLD_BusinessLayer1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Application_Licenses
{
    public partial class ucFilterDetainApplicationLicense : UserControl
    {
        int LocalLicenseID = -1;

        private decimal _fineFee = 0;

       
        public decimal FineFee
        {
            get { return _fineFee; }
        }



        public ucFilterDetainApplicationLicense()
        {
            InitializeComponent();

           
        }
        public class SearchEventArgs : EventArgs
        {
            public int SearchValue { get; set; }
         

        }
        public event EventHandler<SearchEventArgs> SearchClicked;

       
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

            SearchEventArgs args = new SearchEventArgs
            {
                SearchValue = searchValue,

            };
            SearchClicked?.Invoke(this, args);
        }

        public void LoadDetainedInfo(int DetainedID, int LocalLicenseID)
        {
            ucDetaindApplicaitonbasicInfo1.LoadInfo(DetainedID, LocalLicenseID);
        }

        private void ucDetaindApplicaitonbasicInfo1_FineFee_1(object sender, decimal e)
        {
            _fineFee = e;
        }
    }
}