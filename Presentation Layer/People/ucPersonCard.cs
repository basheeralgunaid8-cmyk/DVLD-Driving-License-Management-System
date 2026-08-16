using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.People
{
    public partial class ucPersonCard : UserControl
    {
        ClsPerson _Person;
        
        public ucPersonCard()
        {
            InitializeComponent();
        }
        public void LoadPersonData(ClsPerson person)
        {
            _Person = person;


            lblPersonID.Text = _Person.PersonID.ToString();

            lblFullName.Text = _Person.FullName();

            lblNationalID.Text = _Person.NationalID;

            lblBirthDate.Text = _Person.BirthOfDate.ToShortDateString();

            lblAddress.Text = _Person.Address;

            lblGender.Text = _Person.Gender;

            lblEmail.Text = _Person.Email;

            var country = ClsCountries.Find(_Person.NationalCountryID);

            lblCountry.Text = country != null
                ? country.CountryName
                : "Unknown";



            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                try
                {
                    using (var img = Image.FromFile(_Person.ImagePath))
                    {
                        picPerson.Image = new Bitmap(img);
                    }

                    picPerson.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    picPerson.Image = null;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddPerson frm= new FrmAddPerson(_Person.PersonID);
            frm.Show();
        }
    }
}
