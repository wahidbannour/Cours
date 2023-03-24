using SharedAppTP1.Entities;
using SharedAppTP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{
    public class Authentification : IAuthentification
    {
        private User user;
        private IDaoUser daoUser;
        private bool isVerified =false;

        public Authentification(IDaoUser dao)
        {
            daoUser = dao;
        }

        public bool IsVerified => isVerified;

        public User VerifyUser(string login, string password)
        {
            this.user = daoUser.GetUserByLogin(login);
            if (user != null && user.Login == login && user.Password == password)
            {
                isVerified = true;
                return user;
            }
            isVerified = false;    
            return null;

        }
    }
}
