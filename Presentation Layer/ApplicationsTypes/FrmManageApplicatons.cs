using DVLD_BusinessLayer1;
using Project.ApplicationsTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Applications
{
    public partial class FrmManageApplicatons : Form
    {

        public FrmManageApplicatons()
        {
            InitializeComponent();
        }

        private void _RefreshApplicationsList()
        {
            dgvApplicationType.DataSource = ClsApplicationType.GetAllApplicationTypesInfo();
        }
      
        private void FrmManageApplicatons_Load_1(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectIndex= Convert.ToInt32(dgvApplicationType.CurrentRow.Cells[0].Value);
            FrmUpdateApplicationType frmUpdate = new FrmUpdateApplicationType(selectIndex);
            frmUpdate.ShowDialog();
            _RefreshApplicationsList();
        }
    }
}
