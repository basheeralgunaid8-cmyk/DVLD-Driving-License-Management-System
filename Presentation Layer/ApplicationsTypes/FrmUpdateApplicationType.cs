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

namespace Project.ApplicationsTypes
{
    public partial class FrmUpdateApplicationType : Form
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;
        private int _ApplicationTypeID;
        ClsApplicationType _ApplicationType;  
        public FrmUpdateApplicationType( int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;


            if(_ApplicationTypeID >0)
            {
                Mode = enMode.UpdateMode;
                _ApplicationType = ClsApplicationType.FindApplicationTypeByID(_ApplicationTypeID);
            }
        }

        private void _LoadApplicationTypeData()
        {
            if (_ApplicationType != null)
            {
                lblApplicationTypeID.Text = _ApplicationType._ApplicationID.ToString();
                txtApplicationName.Text = _ApplicationType._ApplicationName;
                txtApplicationFees.Text = _ApplicationType._ApplicationFees.ToString();
            }
        }

        private void FrmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            _ApplicationType._ApplicationName = txtApplicationName.Text;
            if (decimal.TryParse(txtApplicationFees.Text, out decimal fees)) ;
            {
                _ApplicationType._ApplicationFees = fees;
            }

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Application Type");
            }
        }
    }
}
