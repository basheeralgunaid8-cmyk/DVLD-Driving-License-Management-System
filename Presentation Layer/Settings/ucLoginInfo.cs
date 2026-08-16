using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer1;
namespace Project.Settings
{
    public partial class ucLoginInfo : UserControl
    {
        public ucLoginInfo()
        {
            InitializeComponent();
        }

        private void ucLoginInfo_Load(object sender, EventArgs e)
        {
            lblUserID.Text = clsGlobal.userID.ToString();
            lblUserName.Text = clsGlobal.Username;
            lblISactive.Text = clsGlobal.IsLoggedIn() ? "Active" : "Inactive";


        }
    }
}
