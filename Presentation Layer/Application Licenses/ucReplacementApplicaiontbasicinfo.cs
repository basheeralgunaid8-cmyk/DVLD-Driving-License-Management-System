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
    public partial class ucReplacementApplicaiontbasicinfo : UserControl
    {
        public ucReplacementApplicaiontbasicinfo()
        {
            InitializeComponent();
        }

        public void loadInfo(int applicationID,int oldLocalLicenseID,int replacedLicenseID ,int ApplicationTypeID)
        {

            ClsApplicationType applicationType = ClsApplicationType.FindApplicationTypeByID(ApplicationTypeID);

            lblCreatedBy.Text = clsGlobal.Username;
            lblApplicationFees.Text = applicationType._ApplicationFees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/mm/yyyyy");


        }
    }
}
