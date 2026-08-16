using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class usControlPanal : UserControl
    {
        public usControlPanal()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null)
                parentForm.WindowState = FormWindowState.Minimized;
        }


        private void btnMaximize_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                if (parentForm.WindowState == FormWindowState.Normal)
                    parentForm.WindowState = FormWindowState.Maximized;
                else
                    parentForm.WindowState = FormWindowState.Normal;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null)
                parentForm.Close();
        }
    }
}
