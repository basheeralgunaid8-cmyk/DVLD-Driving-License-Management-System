using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Project.People;
using  Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static Project.People.PersonDetail;
namespace Project.Users
{
    public partial class PersonalInfo : UserControl
    {
         public ClsPerson _Person;
        public event EventHandler AddClicked;
        public class SearchEventArgs : EventArgs
        {
           
            public ClsPerson Person { get; set; }
          
           

        }
        public event EventHandler<SearchEventArgs> SearchClicked;

        public PersonalInfo()
        {
            InitializeComponent();

      
        }
        private void _Add()
        {
            AddClicked?.Invoke(this, EventArgs.Empty);

        }

        private void PersonalInfo_Load(object sender, EventArgs e)
        {
            cmbFilterBy.Items.Add("All");
            cmbFilterBy.Items.Add("User Name");
            cmbFilterBy.Items.Add("PersonID");
            cmbFilterBy.Items.Add("Is Active");
           

            cmbFilterBy.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Searchvalue = txtSearch.Text;
           
            _Person = ClsPerson.FindByNationalID(Searchvalue);
          
            if (_Person == null)
            {
                MessageBox.Show(
                    "No person found",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }
            
            ucPersonCard1.LoadPersonData(_Person);
            SearchEventArgs args = new SearchEventArgs();
            args.Person = _Person;
    
       
            SearchClicked?.Invoke(this, args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _Add();
        }

     
    }
}
