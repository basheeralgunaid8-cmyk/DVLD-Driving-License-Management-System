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
using Project.Users;
using DVLD_BusinessLayer;
using static Project.People.PersonDetail;
using DVLD_BusinessLayer1;
using System.Runtime.InteropServices;
namespace Project.Application_Licenses
{
    public partial class FrmLicenseHistory : Form
    {
        int _PersonID = -1;
        int _ApplicationID = -1;
        public FrmLicenseHistory(int PersonID,int ApplicationID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _ApplicationID = ApplicationID;

        }

        private void FrmLicenseHistory_Load(object sender, EventArgs e)
        {
            ClsPerson person=ClsPerson.Find(_PersonID);
            if (person==null)
            {
                MessageBox.Show("Invalid Person ID");
                this.Close();
            }
            else
            {
                personalInfo1.LoadPersonCard(person);
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void _LoadLocalLicenseInfo()
        {
            dgvLocalLicenseInfo.DataSource = ClsLocalLicense.GetLocalLicenseInfo(_ApplicationID);
        }

        private void  _LoadInternationalLicenseInfo()
        {
            dgvInternationalLicenseInfo.DataSource=ClsInternationalLicense.GetInternationalLicenseInfo(_ApplicationID);
        }

    }
}

