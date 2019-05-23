using System;

namespace Persistence
{
    public class Managers
    {
        public int ManagersID{get; set;}
        public string Pass{get; set;}
        public string FullName{get; set;}
        public string UserName{get; set;}

        public Managers(){}
        public Managers(int magID, string pass, string fullName, string userName)
        {
            magID = ManagersID;
            pass = Pass;
            fullName = FullName;
            userName = UserName;
        }
    }
}