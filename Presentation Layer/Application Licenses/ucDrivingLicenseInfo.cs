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

namespace Project.Application_Licenses
{
    public partial class ucDrivingLicenseInfo : UserControl
    {

        public ucDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadingLocalLicenseInfo(LocalLicenseInfoDTO _LocalLicenseInfo)
        {
            lblClass.Text = _LocalLicenseInfo.LicenseClassName;
            lblDriverID.Text = _LocalLicenseInfo.DriverID.ToString();
            lblGender.Text = _LocalLicenseInfo.Gender;
            lblIssueDate.Text = _LocalLicenseInfo.IssueDate.ToString("dd/MM/yyyy");
            lblLicenseID.Text = _LocalLicenseInfo.LocalLicenseID.ToString();
            lblNationalNO.Text = _LocalLicenseInfo.NationalNo;
            lblName.Text = _LocalLicenseInfo.FullName;
            lblNotes.Text = _LocalLicenseInfo.Notes;

            lblNotes.Visible =
                !string.IsNullOrEmpty(_LocalLicenseInfo.Notes);

            lblIssueReason.Text = _LocalLicenseInfo.IssueReason;

            lblDateOfBirthDay.Text =
                _LocalLicenseInfo.DateOfBirth.ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(_LocalLicenseInfo.ImagePath))
            {
                try
                {
                    using (var img =
                           Image.FromFile(_LocalLicenseInfo.ImagePath))
                    {
                        pcPhoto.Image = new Bitmap(img);
                    }

                    pcPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    pcPhoto.Image = null;
                }
            }
            else
            {
                pcPhoto.Image = null;
            }

            lblExpirationDate.Text = _LocalLicenseInfo.ExpirationDate.ToString("dd/MM/yyyy");
            bool isDetained = ClsDetainedLicenseApplicationBlayer.IsLicenseDetained(_LocalLicenseInfo.LocalLicenseID);
            if (isDetained)
            {
                IsDetained.Text = "Detained";
                IsDetained.ForeColor = Color.Red;
            }
            else
            {
                IsDetained.Text = "Active";
                IsDetained.ForeColor = Color.Green;
            }
        }

        public void LoadDrivingLicenseDataByID(int LocalLicenseID)
        {

            LocalLicenseInfoDTO localLicenseInfo = ClsLocalLicense.GetApplicationBasicInfo(LocalLicenseID);
            if (localLicenseInfo == null)
            {
                MessageBox.Show("Local License Info not found.");
                return;
            }
           

            LoadingLocalLicenseInfo(localLicenseInfo);
        }
    }

    
    

}