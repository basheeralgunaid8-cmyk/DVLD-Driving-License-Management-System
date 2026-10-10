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

namespace Project.Manage_Appointments
{
    public partial class FrmManageAppointments : Form
    {
        public FrmManageAppointments()
        {
            InitializeComponent();
        }

        private void FrmManageAppointments_Load(object sender, EventArgs e)
        {
            dgvManageAppointments.DataSource = ClsAppointments.GetTestAppointmentData();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
