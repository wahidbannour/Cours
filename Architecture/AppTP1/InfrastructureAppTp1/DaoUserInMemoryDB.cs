using SharedAppTP1.Entities;
using SharedAppTP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureAppTp1
{
    public class DaoUserInMemoryDB : IDaoUser
    {
        private List<User> users;

        public DaoUserInMemoryDB()
        {
            users = new List<User> { new User {Name = "Ali", Login="ali", Password = "ali" , Email ="ali@ali.com"},
            new User {Name = "Asma", Login="Asma", Password = "Asma" , Email ="Asma@ali.com"},
            new User {Name = "Hanen", Login="Hanen", Password = "Hanen" , Email ="Hanen@ali.com"},
            new User {Name = "Amani", Login="Amani", Password = "Amani" , Email ="Amani@ali.com"},};
        }

        public User GetUserByLogin(string login)
        {
            return users.Where(x => x.Login.Equals(login)).FirstOrDefault();
        }
    }
}
