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
    public partial class ucUserAction : UserControl
    {
        public ucUserAction()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Closing the form.");
            this.ParentForm.Close();

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
        }

        private void ucUserAction_Load(object sender, EventArgs e)
        {

        }
    }
}
