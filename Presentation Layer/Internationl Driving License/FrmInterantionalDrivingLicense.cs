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
using Project.Application_Licenses;
namespace Project.Internationl_Driving_License
{
    public partial class FrmInterantionalDrivingLicense : Form
    {
        public FrmInterantionalDrivingLicense()
        {
            InitializeComponent();

            ucFilterDrivingLicense1.SearchClicked += ucFilterDrivingLicense1_SearchClicked;
            ucFilterDrivingLicense1.IssueClicked += ucFilterDrivingLicense1_IssueClicked;
        }


        private void ucFilterDrivingLicense1_SearchClicked(object sender, ucFilterDrivingLicense.SearchEventArgs e)
        {
            int LicenseID = e.SearchValue;
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucFilterDrivingLicense1_IssueClicked(object sender, EventArgs e)
        {

        }
    }
}
