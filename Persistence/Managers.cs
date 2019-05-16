using System;

namespace Persistence
{
    public class Managers
    {
        public int ManagersID{get; set;}
        public string Pass{get; set;}
        public string FullName{get; set;}
        public string Email{get; set;}

        public Managers(){}
        public Managers(int magID, string pass, string fullName, string email)
        {
            magID = ManagersID;
            pass = Pass;
            fullName = FullName;
            email = Email;
        }
    }
}