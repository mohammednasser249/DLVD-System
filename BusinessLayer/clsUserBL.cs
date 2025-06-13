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
            isActive = isactive;
            _Mode = enMode.Update;
        }
        // Change password 

        public static bool ChangePasswordBL(int UserID , string NewPassword)
        {
           return clsUserDL.ChangePassword(UserID , NewPassword);
        }

        // Find UserById 

        public static clsUserBL FindUserById(int id)
        {
            int PersonId = 0;
            int IsActive = -1;
            string username =string.Empty;
            string password =string.Empty;

            if(clsUserDL.FindUserByIDDL(id,ref PersonId,ref username,ref password,ref IsActive))
            {
                return new clsUserBL(id, PersonId, username,password, IsActive);
            }else
                return null;

        }
        // Find Username 
        public static clsUserBL FindUserByUserName(string UserName)
        {
            int PersonId = 0;
            int IsActive = -1;
            string password = string.Empty;
            int UserID = 0;
            if (clsUserDL.FindUserByUserNameDL(UserName, ref PersonId, ref UserID, ref password, ref IsActive))
            {
                return new clsUserBL(UserID, PersonId, UserName, password, IsActive);
            }
            else
                return null;
            

        }



        // Get All the users function 

        public static DataTable GetAllUsers()
        {

            return clsUserDL.GetAllUsersDL(); 

        }

        // Add new user funciton 

        private  bool _AddNewUser()
        {
            this.UserID = clsUserDL.AddNewUserDL(this.PersonID, this.UserName, this.Password, this.isActive);
           if(this.UserID != 0)
                return true;
           else 
                return  false;
        }

        // Delete Users 

        public static bool DeleteUserBL(int userid)
        {
          return  clsUserDL.DeleteUser(userid);
        }

        // Update 

        public  bool UpdateUserBL(int UserId)
        {
            if(clsUserDL.UpdateUserDL(UserId,this.UserName,this.Password,this.isActive))
            {
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch(_Mode)
            {
               case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return UpdateUserBL(this.UserID);

            }

            return false;
        }
       



    }
}
