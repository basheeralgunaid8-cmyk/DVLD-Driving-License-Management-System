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
    public partial class ucNewApplicationBasicInfo : UserControl
    {
        int _ApplicationID = -1;
       
        public ucNewApplicationBasicInfo()
        {
            InitializeComponent();
        
        }

        public void LoadingApplicationBasicInfo(int ApplicationID, int OldLocalLicense,int RenewedLicenseID,int LicenseClassID)
        {
            ClsLicenseClass licenseClass = ClsLicenseClass.FindApplicationTypeByID(LicenseClassID);
              if (licenseClass == null)
                return;

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(licenseClass._ValidityLength);

            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(2);
            int localLicenseID = ClsLocalLicense.GetLocalLicenseIDByApplicationID(ApplicationID);

            lblApplicationFees.Text = applicationType._ApplicationFees.ToString();
            lblOldLicneseID.Text = localLicenseID.ToString();
            if (decimal.TryParse(lblLicenseFees.Text, out decimal licenseFee))
            {
                decimal totalFees =applicationType._ApplicationFees + licenseFee;

                lblTotalFees.Text = totalFees.ToString("0.00");
            }
            lblCreatedBy.Text = clsGlobal.Username;
            lblID.Text = ApplicationID.ToString();
            lblOldLicneseID.Text = OldLocalLicense.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yy");
            lblRenewedLicenseID.Text = RenewedLicenseID.ToString();
            lblIssueDate.Text = issueDate.ToString();
            lblExpirationDate.Text = expirationDate.ToString();

        }
        private void ucNewApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
