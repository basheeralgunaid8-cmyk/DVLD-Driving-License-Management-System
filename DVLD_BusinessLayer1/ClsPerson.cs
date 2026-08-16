using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_BusinessLayer
{
    public class ClsPerson
    {
        public enum enMode
        {
            AddNew = 0,
            UpdateMode = 1
        }


        public enMode Mode { get; set; }


        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string FourthName { get; set; }

        public string NationalID { get; set; }

        public DateTime BirthOfDate { get; set; }

        public string Address { get; set; }

        public string PassportNo { get; set; }

        public string Gender { get; set; }

        public int NationalCountryID { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }


        // Relationship: One Person -> Many Phones
        public List<clsPhone> Phones { get; set; }



        public ClsPerson()
        {
            PersonID = -1;

            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            FourthName = string.Empty;

            NationalID = string.Empty;

            BirthOfDate = DateTime.Now;

            Address = string.Empty;



            Gender = string.Empty;

            NationalCountryID = -1;

            ImagePath = string.Empty;

            Email = string.Empty;


            Phones = new List<clsPhone>();

            Mode = enMode.AddNew;
        }



        public ClsPerson(
            int personID,
            string firstName,
            string secondName,
            string thirdName,
            string fourthName,
            string nationalID,
            DateTime birthOfDate,
            string address,
            string gender,
            int countryID,
            string imagePath,
            string email)
        {

            PersonID = personID;

            FirstName = firstName;

            SecondName = secondName;

            ThirdName = thirdName;

            FourthName = fourthName;

            NationalID = nationalID;

            BirthOfDate = birthOfDate;

            Address = address;

        

            Gender = gender;

            NationalCountryID = countryID;

            ImagePath = imagePath;

            Email = email;


            Phones = new List<clsPhone>();

            Mode = enMode.UpdateMode;
        }



        public string FullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {FourthName}";
        }



        private bool _AddNewPerson()
        {

            PersonID =
                clsPersonData.AddNewPerson(
                    FirstName,
                    SecondName,
                    ThirdName,
                    FourthName,
                    NationalID,
                    BirthOfDate,
                    Address,
                    Gender,
                    NationalCountryID,
                    ImagePath,
                    Email
                );


            return PersonID != -1;
        }




        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePersonInfo(
                PersonID,
                FirstName,
                SecondName,
                ThirdName,
                FourthName,
                NationalID,
                BirthOfDate,
                Address,
                Gender,
                NationalCountryID,
                ImagePath,
                Email
            );
        }



        public bool IsValidBirthDate()
        {
            int age = DateTime.Today.Year - BirthOfDate.Year;

            if (BirthOfDate.Date > DateTime.Today.AddYears(-age))
                age--;

            return age >= 18;
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.UpdateMode;

                        return true;
                    }

                    return false;



                case enMode.UpdateMode:

                    return _UpdatePerson();

            }


            return false;
        }


        public static ClsPerson FindByNationalID(string NationalID)
        {


            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string fourthName = "";
            int ID = -1;
            DateTime birthDate = DateTime.Now;

            string address = "";


            string gender = "";

            int countryID = -1;

            string imagePath = "";

            string email = "";



            if (clsPersonData.FindPersonInfoByNationalID(
                  ref ID,
                ref firstName,
                ref secondName,
                ref thirdName,
                ref fourthName,
                 NationalID,
                ref birthDate,
                ref address,
                ref gender,
                ref countryID,
                ref imagePath,
                ref email))
            {


                ClsPerson person =
                   new ClsPerson(
                       ID,
                       firstName,
                       secondName,
                       thirdName,
                       fourthName,
                       NationalID,
                       birthDate,
                       address,
                       gender,
                       countryID,
                       imagePath,
                       email
                   );


                // Load phones
                person.Phones =
                    clsPhone.GetPhonesByPersonID(ID);
                return person;


            }

            return null;
        }

        public static ClsPerson Find(int ID)
        {

            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string fourthName = "";

            string nationalID = "";

            DateTime birthDate = DateTime.Now;

            string address = "";


            string gender = "";

            int countryID = -1;

            string imagePath = "";

            string email = "";



            if (clsPersonData.FindPersonInfoByID(
                ID,
                ref firstName,
                ref secondName,
                ref thirdName,
                ref fourthName,
                ref nationalID,
                ref birthDate,
                ref address,
                ref gender,
                ref countryID,
                ref imagePath,
                ref email))
            {

                ClsPerson person =
                    new ClsPerson(
                        ID,
                        firstName,
                        secondName,
                        thirdName,
                        fourthName,
                        nationalID,
                        birthDate,
                        address,
                        gender,
                        countryID,
                        imagePath,
                        email
                    );


                // Load phones
                person.Phones =
                    clsPhone.GetPhonesByPersonID(ID);



                return person;
            }


            return null;
        }


        public static DataTable Search( string search,string filterColumn)
        {

            if (string.IsNullOrEmpty(search))
            {
                return clsPersonData.GetAllPeople();
            }


            return clsPersonData.SearchPeople(
                search,
                filterColumn);
        }






        public static DataTable GetAllPeopleInfo()
        {
            return clsPersonData.GetAllPeople();
        }





        public static bool IsExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool IsNationalNOExist(string nationalNO)
        {
            return clsPersonData.IsNationalNoExist(nationalNO);
        }



        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePersonInfo(ID);
        }

    }
}
