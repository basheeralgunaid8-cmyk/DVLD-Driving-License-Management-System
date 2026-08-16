using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Project.People;
using Project.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Users
{
    public partial class FrmAddUser : Form
    {
        private int _PersonID=-1;
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;

        int _UserID;
        ClsUser _User;
        public FrmAddUser(int UserID)
        {
            InitializeComponent();
            personalInfo1.SearchClicked += PersonalInfo_SearchClicked;
            personalInfo1.AddClicked += PersonalInfo1_AddClicked;
            _UserID = UserID;
            if (_UserID == -1)
            {
                _Mode = Mode.AddNewMode;
                _User = new ClsUser();
                
            }
            else
            {
                _Mode = Mode.UpdateMode;
                _User = ClsUser.Find(_UserID);

            }
        }
        private void _Add()
        {
            FrmAddUser frmAddUser = new FrmAddUser(-1);
            frmAddUser.ShowDialog();

        }
        private void PersonalInfo1_AddClicked(object sender, EventArgs e)
        {
            _Add();

        }
        private void _LoadUserData()
        {
            if (_Mode == Mode.AddNewMode)
            {
                _User = new ClsUser();
                return;
            }
            if (_User == null)
            {
                MessageBox.Show("User is Not Found");
                this.Close();
                return;
            }

        }


        private void PersonalInfo_SearchClicked(object sender, PersonalInfo.SearchEventArgs e)
        {
            ClsPerson person = e.Person;


            // store it for creating user
            _PersonID = person.PersonID;

         
        }


        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            _LoadUserData();

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.UserName = textUserName.Text;
            string password = txtPassword.Text;

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return;
            }


            if (password != txtConfirmedPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            _User.PasswordHash = password;
            _User.PersonID = _PersonID;
            _User.IsActive = chbisActive.Checked;
            _User.FullName=ClsPerson.Find(_PersonID)?.FullName() ?? "Unknown";
          

            if (_User.Save())
            {

                lblUserID.Text = _User.UserID.ToString();
                MessageBox.Show("User saved successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save user.");
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_PersonID == -1)
            {
                MessageBox.Show("Please select a person first.");
                return;
            }

            if (ClsUser.IsPersonExistsInUserTable(_PersonID))
            {
                MessageBox.Show(
                    "This person already has a user account."
                );
                return;
            }
            tabControl1.SelectedTab = tapLoginInfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
