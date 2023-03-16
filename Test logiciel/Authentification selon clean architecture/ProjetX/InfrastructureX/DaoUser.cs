using SharedX.Entities;
using SharedX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InfrastructureX
{
    public class DaoUser : IdaoUser
    {
        List<User> _users = new List<User>();

        public DaoUser()
        {
            _users.Add(new User { Id=1, Name ="ALi", Login="ali", Password="ss",Email = "ali@gmail.com" });
            _users.Add(new User { Id = 2, Name = "Salah", Login = "Salah", Password = "Salah", Email = "Salah@gmail.com" });
            _users.Add(new User { Id = 3, Name = "Samira", Login = "Samira", Password = "Samira", Email = "Samira@gmail.com" });
            _users.Add(new User { Id = 4, Name = "ALia", Login = "alia", Password = "alia", Email = "alia@gmail.com" });

        }

        public User GetUserByLogin(string login)
        {
            return _users.Where(x => x.Login.Equals(login)).FirstOrDefault();
        }
    }
}
