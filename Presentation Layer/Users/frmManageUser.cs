using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
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
using DTO_Project;
using static Project.People.ucSearchPerson;
namespace Project.Users
{
    public partial class frmManageUser : Form
    {
      
        public frmManageUser()
        {
            InitializeComponent();
         
            ucSearchPerson1.AddClicked += ucSearchPerson1_AddClicked;
            ucSearchPerson1.SearchClicked += ucSearchPerson1_SearchClicked;
        }

        private void _Add()
        {
          FrmAddUser frmAddUser = new FrmAddUser(-1);
            frmAddUser.ShowDialog();

        }
        private void ucSearchPerson1_SearchClicked(object sender, SearchEventArgs e)
        {

            dgvManageUser.DataSource =
            ClsUser.Search(
                e.Search,
                e.FilterValue
            );



        }
        private void ucSearchPerson1_AddClicked(object sender, EventArgs e)
        {
            _Add();
           
        }

        private void _LoadData()
        {
            dgvManageUser.DataSource = ClsUser.GetAllUsersInfo();

        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            _LoadData();
            ucSearchPerson1.SetFilters(new List<string>()
              {
                    "All",
                    "UserID",
                    "Username",
                    "PersonID",
                    "IsActive"
              });


        }
       
       
    }
}
