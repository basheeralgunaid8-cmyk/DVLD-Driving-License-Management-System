using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.People.PersonDetail;
using static Project.People.ucSearchPerson;

namespace Project.People
{
    public partial class FrmAddPerson : Form
    {
        public enum Mode { AddNewMode = 0, UpdateMode = 1 };
        private Mode _Mode;

        int _PersonID;
        ClsPerson _Person;
        public FrmAddPerson(int personID)
        {
            InitializeComponent();

            personDetail1.PersonDetailClicked += personDetail1_SaveClicked;

            _PersonID = personID;


            if (_PersonID == -1)
            {
                _Mode = Mode.AddNewMode;
                _Person = new ClsPerson();
            }
            else
            {
                _Mode = Mode.UpdateMode;
                _Person = ClsPerson.Find(_PersonID);
            }
        }


        private void  LoadData2()
        {
            if (_Mode == Mode.AddNewMode)
            {
                lblTitle.Text = "Add New Person";
                _Person = new ClsPerson();
                return;
            }

           
            if (_Person == null)
            {
                MessageBox.Show("Person is Not Found");
                this.Close();
                return;
            }
            lblTitle.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();


            personDetail1.LoadData(_Person);

        }


        private void personDetail1_SaveClicked(
        object sender,
        PersonDetailEventArgs e)
        {

            _Person.FirstName = e.FirstName;

            _Person.SecondName = e.SecondName;

            _Person.ThirdName = e.ThirdName;

            _Person.FourthName = e.FourthName;

            _Person.NationalID = e.NationalNo;

            _Person.BirthOfDate = e.BirthOfDate;

            _Person.Address = e.Address;

            _Person.Gender = e.Gender;

            _Person.NationalCountryID = e.NationalCountryID;

            _Person.ImagePath = e.ImagePath;

            _Person.Email = e.Email;

            if (!_Person.IsValidBirthDate())
            {
                MessageBox.Show(
                    "Person must be at least 18 years old."
                );

                return;
            }

            if (_Person.Save())
            {

                int PersonID = _Person.PersonID;


                if (_Mode == Mode.AddNewMode)
                {

                    foreach (string phoneNumber in e.Phones)
                    {

                        clsPhone phone = new clsPhone();

                        phone.Phone = phoneNumber;

                        phone.PersonID = PersonID;

                        phone.SavePhone();

                    }

                }


                MessageBox.Show("Saved Successfully");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void FrmAddPerson_Load(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void personDetail1_Load(object sender, EventArgs e)
        {

        }
    }
}
