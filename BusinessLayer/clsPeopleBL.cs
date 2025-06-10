using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

   
    public class clsPeopleBL
    {

        enum enMode
        {
            AddNew,
            Update
        }

        enMode _Mode;
        public int ID { get; set; } 
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int NationalityCountryID {  get; set; }
        public string Address {  get; set; }

        public string ImagePath { get; set; }

        // Parametrized Constructor 

        public clsPeopleBL(int id, string nationalNo, string firstName, string secondName,
          string thirdName, string lastName, int gender,string Address, DateTime dob,
           string phone, string email,int nationalityCountryID,string imagePath)
        {
            ID = id;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            ImagePath = imagePath;
            NationalityCountryID = nationalityCountryID;
            DOB = dob;
            Phone = phone;
            Email = email;
            _Mode = enMode.Update;
        }


        public clsPeopleBL()
        {
            ID = 0;
            NationalNo =  string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            ImagePath = string.Empty;
            Gender = 0;
            NationalityCountryID = 0;
            DOB = DateTime.MinValue;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            _Mode = enMode.AddNew;
        }


        public static DataTable GetAllPeople()
        {

           return clsPeopleDL.GetAllPeopleDL();
        }

        private bool _AddNewPersonBL()
        {
          if(  clsPeopleDL.AddPersonDL(this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.Gender,this.Address,this.DOB,this.Phone,this.Email,this.NationalityCountryID,this.ImagePath))
            {
                return true;
            }
          return false;
        }


        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPersonBL())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;

            }
            return false;
        }

    }
}
