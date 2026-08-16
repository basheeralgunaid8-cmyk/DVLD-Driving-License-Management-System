using  DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Guna.UI2.WinForms;
using Project.Applications;
using Project.People;
using Project.Settings;
using Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();

        }


        private void CenterCards()
        {
            panelCards.Left = (this.ClientSize.Width - panelCards.Width) / 2;
        }
        private void btnManagePeople_Click(object sender, EventArgs e)
        {
            FrmManagePeople frmManagePeople = new FrmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void guna2CustomGradientPanel1_SizeChanged(object sender, EventArgs e)
        {
            CenterCards();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click_1(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.IsLoggedIn())
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                this.Close();
                this.Hide();
                return;
            }


            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chart1.Series.Clear();

            chart1.Series.Add("Revenue");

            chart1.Series["Revenue"].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


            chart1.Series["Revenue"].Points.AddXY("Mon", 1000);
            chart1.Series["Revenue"].Points.AddXY("Tue", 17000);
            chart1.Series["Revenue"].Points.AddXY("Wed", 3000);
            chart1.Series["Revenue"].Points.AddXY("Thu", 1500);
            chart1.Series["Revenue"].Points.AddXY("Fri", 6500);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal.Logout();
      
            this.Hide();

            frmLogin frm = new frmLogin();

            frm.ShowDialog(); this.Close();

            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmManageUser frmManageUser = new frmManageUser();
            frmManageUser.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            cmsSettings.Show(btnSettings, 0, btnSettings.Height);
        }

        private void currentUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(clsGlobal.userID);
            frmUserInfo.ShowDialog();

         
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChange = new frmChangePassword(clsGlobal.userID);
            frmChange.ShowDialog();
        }

        private void btnManageTest_Click(object sender, EventArgs e)
        {
            FrmManageApplicatons frmManageApplications = new FrmManageApplicatons();
            frmManageApplications.ShowDialog();
        }

    }

    }

