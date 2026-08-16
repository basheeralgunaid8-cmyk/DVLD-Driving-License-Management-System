using DVLD_BusinessLayer;
using DVLD_BusinessLayer1;
using Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Project.People
{
    public partial class PersonDetail : UserControl
    {
        private string _ImagePath=string.Empty;

      
        public PersonDetail()
        {
            InitializeComponent();
        }
        public class PersonDetailEventArgs : EventArgs
        {
            public int PersonID { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string FourthName { get; set; }
            public string NationalNo { get; set; }
            public DateTime BirthOfDate { get; set; }
            public string Address { get; set; } = string.Empty;
            public string Gender { get; set; } = string.Empty;
            public int NationalCountryID { get; set; }
            public string ImagePath { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public List<string> Phones { get; set; } = new List<string>();
         
        }
      
        public event EventHandler<PersonDetailEventArgs> PersonDetailClicked;

        private void _FillAllCountriesInComboBox()
        {
            DataTable dt = ClsCountries.GetAllCountries();

            cbCountry.DataSource = dt;

            cbCountry.DisplayMember = "CountryName";

            cbCountry.ValueMember = "CountryID";
        }

       
        private void PersonDetail_Load(object sender, EventArgs e)
        {
            _FillAllCountriesInComboBox();


        }

        public  void LoadData( ClsPerson _Person)
        {
        

            txtFirst.Text = _Person.FirstName;
            txtSecond.Text = _Person.SecondName;
            txtThird.Text = _Person.ThirdName;
            txtLast.Text = _Person.FourthName;
            txtNationalNo.Text = _Person.NationalID;
            dtpBirth.Value = _Person.BirthOfDate;
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            rdFemale.Checked = _Person.Gender == "Female";
            rdMale.Checked = _Person.Gender == "Male";
            cbCountry.SelectedValue = _Person.NationalCountryID;
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                picPerson.ImageLocation = _Person.ImagePath;
                picPerson.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                SetDefaultImage();
            }
            if (_Person.Phones.Count > 0)
            {
                txtPhone.Text = _Person.Phones[0].Phone;
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            PersonDetailEventArgs personDetail =
           new PersonDetailEventArgs();


            personDetail.FirstName = txtFirst.Text;
            personDetail.SecondName = txtSecond.Text;
            personDetail.ThirdName = txtThird.Text;
            personDetail.FourthName = txtLast.Text;

            personDetail.NationalNo = txtNationalNo.Text;

            personDetail.BirthOfDate = dtpBirth.Value;

            personDetail.Address = txtAddress.Text;

            personDetail.Email = txtEmail.Text;


            if (rdFemale.Checked)
                personDetail.Gender = "Female";
            else if (rdMale.Checked)
                personDetail.Gender = "Male";


            personDetail.NationalCountryID =
                Convert.ToInt32(cbCountry.SelectedValue);


            if (!string.IsNullOrEmpty(txtPhone.Text))
                personDetail.Phones.Add(txtPhone.Text);


            if (!string.IsNullOrEmpty(picPerson.ImageLocation))
            {
                personDetail.ImagePath =
                    CopyImageToProjectFolder(picPerson.ImageLocation);
            }


            PersonDetailClicked?.Invoke(this, personDetail);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Form frm = this.FindForm();

            if (frm != null)
            {
                frm.Close();
            }
        }
        private string CopyImageToProjectFolder(string sourcePath)
        {
            string folder = Path.Combine(
                  Application.StartupPath,
                            "Images"
                               );                                   

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            string fileName = Guid.NewGuid().ToString()
                              + Path.GetExtension(sourcePath);


            string destinationPath =
                Path.Combine(folder, fileName);


            File.Copy(sourcePath, destinationPath, true);


            return destinationPath;
        }
        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picPerson.ImageLocation = dialog.FileName;
            }

        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {
            dtpBirth.MaxDate = DateTime.Now;
            dtpBirth.MinDate = DateTime.Today.AddYears(-18);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(
                    txtNationalNo,
                    "National Number is required"
                );

                e.Cancel = true; // prevent leaving textbox
                return;
            }


            if (ClsPerson.IsNationalNOExist(txtNationalNo.Text))
            {
                errorProvider1.SetError(
                    txtNationalNo,
                    "National Number is already used!"
                );

                e.Cancel = true; // stay in textbox
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void SetDefaultImage()
        {
            if (rdMale.Checked)
            {
                picPerson.Image = Resources.man;
            }
            else if (rdFemale.Checked)
            {
                picPerson.Image = Resources.female__2_;
            }

            picPerson.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked)
                SetDefaultImage();
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked)
            {
                if (rdFemale.Checked)
                    SetDefaultImage();
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
