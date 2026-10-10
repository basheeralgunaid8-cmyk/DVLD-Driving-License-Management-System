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

namespace Project.ManageTestType
{
    public partial class FrmManageTestTypes : Form
    {
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTestTypeList()
        {
            dgvaTestType.DataSource = DVLD_BusinessLayer1.ClsTestType.GetAllTestTypesInfo();
        }

        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypeList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectIndex = Convert.ToInt32(dgvaTestType.CurrentRow.Cells[0].Value);
            FrmUpdateTestType frmUpdate = new FrmUpdateTestType(selectIndex);
            frmUpdate.ShowDialog();
            _RefreshTestTypeList();
        }
    }
}
