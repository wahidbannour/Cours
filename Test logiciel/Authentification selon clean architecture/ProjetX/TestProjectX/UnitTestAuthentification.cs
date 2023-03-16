using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreX;
using NUnit.Framework;
using SharedX.Entities;
using SharedX.Interfaces;

namespace TestProjectX
{
    public class UnitTestAuthentification
    {

        [Test]
        public void VerifyUser_LoginAndPwrdValid_True()
        {
            //Arrange
            User user = new User { Id= 1, Login= "ali", Password="ali"};
            var dao = new FakeDaoUser(user);
            var authentification = new Authentification(dao);
            //Action
            var result = authentification.VerifyUser("ali", "ali");
            //Assert
            Assert.That(result, Is.True);
        }
    }


    public class FakeDaoUser : IdaoUser
    {
        User user;
        public FakeDaoUser(User user)
        {
            this.user = user;
        }

        public User GetUserByLogin(string login)
        {
            return user;
        }
    }
}
