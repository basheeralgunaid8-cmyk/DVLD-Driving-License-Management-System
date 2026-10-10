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
    public partial class ucReleaseApplicationBasicInfo : UserControl
    {
        public ucReleaseApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationBasicInfo(int LocalLicenseID,int ApplicationID,int ApplicationTypeID)
        {
            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(ApplicationTypeID);
            ClsDetainedLicenseApplicationBlayer detainedLicenseApplication= ClsDetainedLicenseApplicationBlayer.Find(LocalLicenseID);
            lblCreatedBy.Text = detainedLicenseApplication._CreatedByUserID.ToString();
            lblDetainDate.Text = detainedLicenseApplication._DetainedDate.ToString("dd/MM/yyyy");
            lblID.Text= detainedLicenseApplication._DetainedID.ToString();
            lblFineFees.Text= detainedLicenseApplication._FineFees.ToString("N2");
            lblOldLicneseID.Text= detainedLicenseApplication._LicenseID.ToString();
            lblApplicationFees.Text= applicationType._ApplicationFees.ToString("N2");
            lblTotlalFees.Text= (detainedLicenseApplication._FineFees + applicationType._ApplicationFees).ToString("N2");
            lblApplicaiontID.Text= ApplicationID.ToString();
        }
    }
}
