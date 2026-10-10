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
using static Guna.UI2.Native.WinApi;

namespace Project.Application_Licenses
{
    public partial class ucFilter : UserControl
    {
        public class SearchEventArgs : EventArgs
        {

            public ClsPerson Person { get; set; }

        }
        public event EventHandler<SearchEventArgs> SearchClicked;
        public ucFilter()
        {
            InitializeComponent();
        }

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
     
       
    }
}
