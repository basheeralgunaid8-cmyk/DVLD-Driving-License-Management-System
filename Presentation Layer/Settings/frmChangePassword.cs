using DVLD_BusinessLayer;
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

namespace Project.Settings
{
    public partial class frmChangePassword : Form
    {
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;


        
        int _UserID;
        ClsUser _User;
        ClsPerson _Person;
        public frmChangePassword(int UserID)
        {

            _UserID = UserID;
            if(_UserID == -1)
            {
                _Mode = Mode.AddNewMode;
                _User = new ClsUser();
            }
            else
            {
                _Mode = Mode.UpdateMode;
                _User = ClsUser.Find(_UserID);
            }
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadUserInfoData()
        {
            
            if (_User == null)
            {
                MessageBox.Show("User is not found");
                this.Close();
                return;
            }

            _Person = ClsPerson.Find(_User.PersonID);

            if (_Person == null)
            {
                MessageBox.Show("Person is not found");
                this.Close();
                return;
            }

            ucPersonCard1.LoadPersonData(_Person);

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadUserInfoData();

         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.UserID = _UserID;

            string currentPassword = _User.PasswordHash;

            // Check current password
            if (currentPassword != txtCurrentPassword.Text)
            {
                MessageBox.Show("Current password is incorrect.");
                return;
            }

            // Check new password length
            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return;
            }

            // Check confirmation
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Set new password
            _User.PasswordHash = txtNewPassword.Text;

            _User.PersonID = _Person.PersonID;
            _User.IsActive = clsGlobal.IsActive;

            _User.FullName =
                ClsPerson.Find(_User.PersonID)?.FullName() ?? "Unknown";

            if (_User.Save())
            {
                MessageBox.Show("Password changed successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error changing password.");
            }
        }
    }
}
