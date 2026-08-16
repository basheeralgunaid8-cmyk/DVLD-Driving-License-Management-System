using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Microsoft.VisualBasic.ApplicationServices;
using Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.People.PersonDetail;
namespace Project.Settings
{
    public partial class frmUserInfo : Form
    {

        private int _UserID;
        ClsPerson _Person;
        public frmUserInfo(int userID)
        {

            _UserID = userID;
            InitializeComponent();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadUserInfoData()
        {
            ClsUser user = ClsUser.Find(_UserID);

            if (user == null)
            {
                MessageBox.Show("User is not found");
                this.Close();
                return;
            }

            ClsPerson person = ClsPerson.Find(user.PersonID);

            if (person == null)
            {
                MessageBox.Show("Person is not found");
                this.Close();
                return;
            }

            ucPersonCard1.LoadPersonData(person);

        }
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            LoadUserInfoData();

        }
    }
    }
