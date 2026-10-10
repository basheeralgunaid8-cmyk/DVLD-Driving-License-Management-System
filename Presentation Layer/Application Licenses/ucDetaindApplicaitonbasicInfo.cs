using DVLD_BusinessLayer1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Application_Licenses
{
    public partial class ucDetaindApplicaitonbasicInfo : UserControl
    {
    
        public ucDetaindApplicaitonbasicInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int DetainedID,int LocalLicenseID)
        {
            lblDetainedID.Text = DetainedID.ToString();
            lblOldLicneseID.Text= LocalLicenseID.ToString();
            lblDetaindDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text=clsGlobal.Username;
        }

    
    }
}
