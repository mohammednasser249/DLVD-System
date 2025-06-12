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

        private enMode _Mode;

        public int UserID { get; set; }
        public int  PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }    

        public int isActive { get; set; }

        // Defalut constructor 

        public clsUserBL()
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

        // Add new user funciton 

        private  bool _AddNewUser()
        {
           if( clsUserDL.AddNewUserDL(this.PersonID, this.UserName, this.Password, this.isActive)!=0)
                return true;
           else 
                return  false;
        }

        // Delete Users 

        public static bool DeleteUserBL(int userid)
        {
          return  clsUserDL.DeleteUser(userid);
        }

        public int Save()
        {
            switch(_Mode)
            {
               case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return this.UserID;
                    }
                    break;

            }

            return -1;
        }
       


    }
}
