using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedX.Entities;
using SharedX.Interfaces;

namespace CoreX
{
    public class Authentification
    {
        User user;
        IdaoUser daoUser;
        public User CurrentUser => user;

        public Authentification(IdaoUser daoUser)
        {
            this.daoUser = daoUser;
        }

        public bool VerifyUser(string login, string password)
        {
           
            if (login == string.Empty)
                return false;
            var wUser = daoUser.GetUserByLogin(login);
            if (wUser == null)
                return false;
            if ( password == wUser.Password)
            {
                user = wUser;
                return true;
            }
            return false;     
        }
    }
}
