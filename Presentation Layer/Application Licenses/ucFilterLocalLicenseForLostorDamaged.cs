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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Project.Application_Licenses
{
    public partial class ucFilterLocalLicenseForLostorDamaged : UserControl
    {
        int LocalLicenseID = -1;
        public class SearchEventArgs : EventArgs
        {
            public int SearchValue { get; set; }
         

        }
        public enum enReplacementReason
        {
            Lost,
            Damaged
        }
        public event EventHandler<SearchEventArgs> SearchClicked;
        public class ReplacementReasonEventArgs : EventArgs
        {
            public enReplacementReason Reason { get; }

            public ReplacementReasonEventArgs(
                enReplacementReason reason)
            {
                Reason = reason;
            }
        }
        public event EventHandler<ReplacementReasonEventArgs> ReplacementReasonSelected;

        public ucFilterLocalLicenseForLostorDamaged()
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

        public void loadReplacementInfo(int applicationID,int oldLocalLicenseID,int ReplacedLicenseID,int applicationTypeID)
        {
            ucReplacementApplicaiontbasicinfo1.loadInfo(applicationID, oldLocalLicenseID, ReplacedLicenseID, applicationTypeID);
        }

        private void chLost_CheckedChanged(object sender, EventArgs e)
        {
            if (chLost.Checked)
            {
                chDamaged.Checked = false;
                ReplacementReasonSelected?.Invoke(
                    this,
                    new ReplacementReasonEventArgs(
                        enReplacementReason.Lost));
            }
        }

        private void chDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (chDamaged.Checked)
            {
                chLost.Checked = false;
                ReplacementReasonSelected?.Invoke( this, new ReplacementReasonEventArgs( enReplacementReason.Damaged));
            }
        }

        public void LoadReplacementInfo(int applicationID, int oldLocalLicenseID, int replacedLicenseID, int applicationTypeID)
        {
            ucReplacementApplicaiontbasicinfo1.loadInfo(applicationID, oldLocalLicenseID, replacedLicenseID, applicationTypeID);
        }
    }
}
