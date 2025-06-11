using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class clsUserBL
    {

        enum enMode
        {
            AddNew,
            Update
        }

        enMode _Mode;

        public int UserID { get; set; }
        public int  PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }    

        public int isActive { get; set; }

        // Defalut constructor 

        clsUserBL()
        {
            UserID = 0;
            PersonID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            isActive = -1;
            _Mode = enMode.AddNew;

        }

        // Paramterized constructor 

        clsUserBL(int userid , int personid , string username , string password,int isactive)
        {
            UserID = userid;
            PersonID = personid;
            UserName = username;
            Password = password;
            isActive = isActive;
            _Mode = enMode.Update;
        }

        // Get All the users function 
            
        public static DataTable GetAllUsers()
        {

            return clsUserDL.GetAllUsersDL(); 

        }



    }
}
