using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Project.Users;
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
using static Project.People.ucSearchPerson;

namespace Project.People
{
    public partial class FrmManagePeople : Form
    {

        public FrmManagePeople()
        {
            InitializeComponent();

            ucSearchPerson1.SearchClicked += ucSearchPerson1_SearchClicked;
            ucSearchPerson1.EditClicked += ucSearchPerson1_EditClicked;
            ucSearchPerson1.AddClicked += ucSearchPerson1_AddClicked;
            ucSearchPerson1.ShowClicked += ucSearchPerson1_ShowClicked;
            ucSearchPerson1.DeleteClicked += ucSearchPerson1_DeleteClicked;


        }

        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();

            ucSearchPerson1.SetFilters(new List<string>()
          {
        "All",
        "PersonID",
        "NationalID",
        "FirstName",
        "Email",
        "Phone"
          });

        }
        private void _RefreshPeopleList()
        {
            dgvPeople.DataSource = ClsPerson.GetAllPeopleInfo();
        }
        private void ucSearchPerson1_SearchClicked(object sender, SearchEventArgs e)
        {

            dgvPeople.DataSource =
            ClsPerson.Search(
                e.Search,
                e.FilterValue
            );



        }
        private void _DeletePerson()
        {
            int selectedPersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            ClsPerson.DeletePerson(selectedPersonID);
            MessageBox.Show("Person Deleted Successfully", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _RefreshPeopleList();
        }

        private void ucSearchPerson1_DeleteClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete This Contact?", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _DeletePerson();
            }
        }
        private void ucSearchPerson1_ShowClicked(object sender, EventArgs e)
        {

            _ShowDetails();
            _RefreshPeopleList();

        }



        private void _ShowDetails()
        {
            int selectedPersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(selectedPersonID);
            frmPersonDetails.ShowDialog();

            _RefreshPeopleList();
        }
        private void _Edit()
        {
            int selectedPersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            FrmAddPerson frmAddPerson = new FrmAddPerson(selectedPersonID);
            frmAddPerson.ShowDialog();
            _RefreshPeopleList();
        }
        private void _Add()
        {
          FrmAddPerson frmAddPerson = new FrmAddPerson(-1);
           frmAddPerson.ShowDialog();
            _RefreshPeopleList();

        }
        private void ucSearchPerson1_EditClicked(object sender, EventArgs e)
        {
            _Edit();
            _RefreshPeopleList();
        }
        private void ucSearchPerson1_AddClicked(object sender, EventArgs e)
        {
            _Add();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Edit();
            _RefreshPeopleList();
        }

        private void tsmiAddNewPerson_Click_1(object sender, EventArgs e)
        {
            _Add();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);

            frmPersonDetails frm = new frmPersonDetails(PersonID);


            frm.ShowDialog();
            _RefreshPeopleList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeletePerson();
        }

    }
}
