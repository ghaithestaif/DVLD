using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Business
{
    public class clsPeople
    {
       public enum enMode{enUpdate,enAddnew}
        enMode _Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }// allows NULL
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }              // tinyint
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }            // allows NULL
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }        // allows NULL
        public clsCountries Country;


        public clsPeople() { 
        _Mode = enMode.enAddnew;
        }

        private clsPeople(
            int personID,
            string nationalNo,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            DateTime dateOfBirth,
            byte gender,
            string address,
            string phone,
            string email,
            int nationalityCountryID,
            string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            Country=clsCountries.Find(NationalityCountryID);
            _Mode = enMode.enUpdate;
        }

        // =======================
        // Business Methods
        // =======================

        private int _AddNew()
        {
         int PersonID=   DVLD_DataAccess.clsPeople.AddNewPerson(
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                Address,
                DateOfBirth,
                Gendor,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath
            );

            return PersonID;
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsPeople.UpdatePerson(
                PersonID,
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                Address,
                DateOfBirth,
                Gendor,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath
            );
        }

        public bool Save()
        {
            if (_Mode == enMode.enAddnew)
            {
                PersonID = _AddNew();
                _Mode = enMode.enUpdate;
                return PersonID > 0;
            }
            else if (_Mode == enMode.enUpdate)
            {
                return _Update();
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(int personID)
        {
            return DVLD_DataAccess.clsPeople.DeletePerson(personID);
        }

        public static clsPeople Find(int personID)
        {
            string NationalNo= "",
             FirstName = "",
             SecondName = "",
             ThirdName = "",
             LastName = "",
             Address = "",
             Phone = "",
             Email = "",
             ImagePath = "";
            byte Gender = 0;
             int NationalityCountryID = 0; 
            DateTime DateOfBirth=DateTime.MinValue;

            DVLD_DataAccess.clsPeople.FindPersonByID(personID, ref NationalNo, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone,
                ref Email, ref NationalityCountryID, ref ImagePath);
            


            return new clsPeople(personID,
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gender,
                Address,
                Phone,
                Email,
                NationalityCountryID,
                ImagePath
            );
        }

        public static DataTable GetAll()
        {
            return DVLD_DataAccess.clsPeople.GetAllPeople();
        }

        static public bool IspersonExist(string NationalNo)
        {
            return DVLD_DataAccess.clsPeople.IspersonExist(NationalNo);
        }
        
        static public DataTable FilterPeople(DVLD_General.Common.PeopleFilterSort peopleFilter,string FilterExpression="")
        {
            return DVLD_DataAccess.clsPeople.FilterPeople(peopleFilter, FilterExpression);
        }

        static public DataTable SortPeople(DVLD_General.Common.PeopleFilterSort peopleSort, DVLD_General.Common.SortType Type )
        {
            return DVLD_DataAccess.clsPeople.SortPeople(peopleSort, Type);
        }







    }
}
