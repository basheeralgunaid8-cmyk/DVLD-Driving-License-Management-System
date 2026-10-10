using DTO_Project;
using DVLD_BusinessLayer1;
using Project.People;
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
    public partial class ucFilterDrivingLicense : UserControl
    {

        int InternationalLicenseID = -1;
        public class SearchEventArgs : EventArgs
        {
            public int  SearchValue { get; set; }

    
        }
        public event EventHandler<SearchEventArgs> SearchClicked;
        public event EventHandler IssueClicked;

        public ucFilterDrivingLicense()
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

            LocalLicenseInfoDTO localLicense =  ClsLocalLicense.FindLicenseInfoByLocalLicenseID1(searchValue);
            ucInternationalInfo1.LoadInternationalLicenseInfo(searchValue);
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

        private void btnIssue_Click(object sender, EventArgs e)
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
         
            bool exists = ClsLocalLicense.DoesLicenseExistByLocalLicenseID(searchValue);
            if(!exists)
            {
                MessageBox.Show(
                    "No license found.",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            ClsLocalLicense localLicense = ClsLocalLicense.FindLicenseInfoByLocalLicenseID(searchValue);

            if (localLicense == null)
            {
                MessageBox.Show("License not found.");
                return;
            }

            bool IsExists=ClsInternationalLicense.DoesInternationalLicenseExistByLocalLicenseID(searchValue);
            if(IsExists)
            {
                MessageBox.Show("International license already issued for this local license.");
                return;
            }
            DateTime issueDate = DateTime.Now;

            DateTime expirationDate = issueDate.AddYears(1);
            Random random = new Random();
            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(7);
            ClsInternationalLicense internationalLicense = new ClsInternationalLicense();
            internationalLicense.LocalLicenseID = searchValue;
            internationalLicense.IssueDate = issueDate;
            internationalLicense.ExpirationDate = expirationDate;
            internationalLicense.LicenseStatus = "Active";
            internationalLicense.CreatedByUserID = clsGlobal.userID;
            internationalLicense.IssueFees = applicationType._ApplicationFees;
            internationalLicense.InternationalLicenseNumber = "INTL-" + random.Next(100000, 999999).ToString();
            internationalLicense.Mode = ClsInternationalLicense.enMode.AddNew;

            bool success = internationalLicense.Save();
            if (success)
            {
                InternationalLicenseID= internationalLicense.InternationalLicenseID;

                MessageBox.Show("International license issued successfully.");
                MessageBox.Show($"International License ID= {InternationalLicenseID}");
                ucInternationalInfo1.LoadInternationalLicenseInfo2(InternationalLicenseID);
                IssueClicked?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Failed to issue international license.");
            }



        }
    }
}
