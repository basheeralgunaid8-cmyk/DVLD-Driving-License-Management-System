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

namespace Project.ManageTestType
{
    public partial class FrmUpdateTestType : Form
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;
        private int _TestTypeID;
        ClsTestType _TestType;
        public FrmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
            if (_TestTypeID > 0)
            {
                Mode = enMode.UpdateMode;
                _TestType = ClsTestType.FindTestTypeByID(_TestTypeID);
            }
        }

        private void _LoadaTestTypeData()
        {
            if (_TestType != null)
            {
                lblTestTypeID.Text = _TestType._TestTypeID.ToString();
                txtTestTypeTitle.Text = _TestType._TestTypeTitle;
                txtDescription.Text = _TestType._Description;
                txtTestTypeFees.Text = _TestType._Fees.ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType._TestTypeTitle = txtTestTypeTitle.Text;
            _TestType._Description = txtDescription.Text;
            if (decimal.TryParse(txtTestTypeFees.Text, out decimal fees)) ;
            {
                _TestType._Fees = fees;
            }

            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Test Type");
            }
        }

        private void FrmUpdateTestType_Load(object sender, EventArgs e)
        {
            if (_TestType != null)
            {
                _LoadaTestTypeData();

            }
        }
    }
}
