using System;
using DataLayer;

namespace BusinessLayer
{
    public class clsLoginBl
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public static bool CheckLogincredentials(string username, string password)
        {
           return clsLoginDL.LoginDL(username, password);
        }


    }
}
