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
    public partial class ucInternationalInfo : UserControl
    {
        public ucInternationalInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo (int LocalLicenseID)
        {
            DateTime issueDate = DateTime.Now;

            DateTime expirationDate = issueDate.AddYears(1);

            lblLocalLicneseID.Text = LocalLicenseID.ToString();
            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(7);
            lblFees.Text = applicationType._ApplicationFees.ToString();
            lblIssueDate.Text = issueDate.ToString();
            lblExpirationDate.Text = expirationDate.ToString();
            lblCreatedBy.Text = clsGlobal.Username;
        }
        public void LoadInternationalLicenseInfo2(int InternationalID)
        {
            lblILLicenseID.Text = InternationalID.ToString();
        }
    }
}
