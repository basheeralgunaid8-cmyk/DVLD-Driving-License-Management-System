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

   
    public partial class ucSearchPerson : UserControl
    {

        public class SearchEventArgs : EventArgs
        {
            public string Search { get; set; }
          
          public string FilterValue { get; set; }

           
        }
        public event EventHandler<SearchEventArgs> SearchClicked;

        public event EventHandler EditClicked;
        public event EventHandler AddClicked;
        public event EventHandler ShowClicked;
        public event EventHandler DeleteClicked;

        public ucSearchPerson()
        {
            InitializeComponent();
        }

        private ComboBox cmbFilter;

        public void SetFilters(List<string> filters)
        {

            foreach (string filter in filters)
            {
               
                cmbFilterBy.Items.Add(filter);
            }

            if (cmbFilterBy.Items.Count > 0)
            {
                cmbFilterBy.SelectedIndex = 0;
            }
        }

        private void ucSearchPerson_Load(object sender, EventArgs e)
        {
          
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchEventArgs args = new SearchEventArgs();

           
            args.FilterValue = cmbFilterBy.Text;

            args.Search= txtSearch.Text;
            
            SearchClicked?.Invoke(this, args);
        }

        private void _Add()
        {
            AddClicked?.Invoke(this, EventArgs.Empty);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
             _EditPerson();
        }

        private void _EditPerson()
        {
            EditClicked?.Invoke(this, EventArgs.Empty);

        }

        private void _ShowDetails()
        {
            ShowClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnShowdetails_Click(object sender, EventArgs e)
        {
            _ShowDetails();
        }

        private void _DeletePerson()
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _DeletePerson();

        }
    }
    }

