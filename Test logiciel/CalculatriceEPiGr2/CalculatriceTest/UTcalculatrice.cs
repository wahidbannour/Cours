using NUnit.Framework;
using CalculatriceEPiGr2.Business;
using System;
using CalculatriceEPiGr2.Models;
using CalculatriceEPiGr2.Services;

namespace CalculatriceTest
{
    public class UTcalculatrice
    {
        

        [Test]
        public void Add_AuthenficationValide5plus2_return7()
        {
            //Arrange
            var StubAuthentification = new FakeAuthentification();
            var cal = new Calculatrice(StubAuthentification);

            //Action
            var resultat = cal.Add(5, 2,new User { Id=1,Name="Ali",Login="123",Password= "123"});
            
            //Assert
            Assert.AreEqual(7, resultat);
        }

        [Test]
        public void Add_AuthenficationRefuse5plus2_returnArgumentException()
        {
            //Arrange
            var StubAuthentification = new FakeAuthentificationRefuse();
            var cal = new Calculatrice(StubAuthentification);

            //Action
            var resultat = Assert.Throws<ArgumentException>( 
                        ()=>  cal.Add(5, 2, new User { Id = 1, Name = "Ali", Login = "123", Password = "123" }));

            //Assert
            Assert.AreSame(resultat!.Message , "Authentification refusé");
        }
    }

    public class FakeAuthentification : IAuthentification
    {
        public bool IsValidUser(User user)
        {
            return true;
        }
    }

    public class FakeAuthentificationRefuse : IAuthentification
    {
        public bool IsValidUser(User user)
        {
            return false;
        }
    }
}