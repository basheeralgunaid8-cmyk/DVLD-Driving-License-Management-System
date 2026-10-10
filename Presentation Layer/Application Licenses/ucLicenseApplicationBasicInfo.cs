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

namespace Project.Application_Licenses
{
    public partial class ucLicenseApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;

        private ApplicationBasicInfoDTO _basicInfoDTO;

        public ucLicenseApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public void LoadApplication(int applicationID)
        {
            _ApplicationID = applicationID;

            _LoadApplicationBasicInfo();
        }
        private void _LoadApplicationBasicInfo()
        {
            _basicInfoDTO =ClsNewDrivingLicenseApplication.GetApplicationBasicInfo(_ApplicationID);

            if (_basicInfoDTO == null)
                return;

            lblApplicatn.Text = _basicInfoDTO.ApplicantFullName;

            lblCreateBy.Text =_basicInfoDTO.UserName;

            lblStatus.Text =_basicInfoDTO.ApplicationStatus;

            lblStatusDate.Text =_basicInfoDTO.ApplicationDate.ToString();

            lblFees.Text =_basicInfoDTO.PaidAmount.ToString();

            lblTypes.Text =_basicInfoDTO.ApplicationTypeTitle;

            lblID.Text =_basicInfoDTO.PersonID.ToString();
        }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(_basicInfoDTO.PersonID);
            personDetails.ShowDialog();
        }
    }
}
