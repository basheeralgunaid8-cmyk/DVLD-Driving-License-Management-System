using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.People
{
    public partial class frmPersonDetails : Form
    {

        int _PersonID;

        ClsPerson _Person;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
          

        }

        private void LoadData()
        {
            _Person = ClsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("Person is Not Found");
                this.Close();
                return;
            }

            ucPersonCard1.LoadPersonData(_Person);

        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
