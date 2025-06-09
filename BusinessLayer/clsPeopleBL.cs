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
        public int ID { get; set; } 
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality {  get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }




        public static DataTable GetAllPeople()
        {

           return clsPeopleDL.GetAllPeopleDL();
        }


    }
}
