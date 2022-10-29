using NUnit.Framework;              // framework de test
using NSubstitute;                  // framework de mocking 
using CalculatriceEPiGr2.Business;  // package de l'application de production
using CalculatriceEPiGr2.Models;    // package de l'application de production
using CalculatriceEPiGr2.Services;  // package de l'application de production
using System;                       // framework de developpement

namespace CalculatriceTest
{
    internal class UTcalculatriceWithNsubstitute
    {
        [Test]
        public void Add_AuthenficationValide5plus2_return7()
        {
            //Arrange

            //créer un objet factice à partire de l'interface
            var StubAuthentification = Substitute.For<IAuthentification>();
            //personnalisation du comportement de la méthode IsValidUser
            StubAuthentification.IsValidUser(Arg.Any<User>()).Returns(true);

            var cal = new Calculatrice(StubAuthentification);

            //Action
            var resultat = cal.Add(5, 2, new User { Id = 1, Name = "Ali", Login = "123", Password = "123" });

            //Assert
            Assert.AreEqual(7, resultat);
        }

        [Test]
        public void Add_AuthenficationRefuse5plus2_returnArgumentException()
        {
            //Arrange
            //créer un objet factice à partire de l'interface
            var StubAuthentification = Substitute.For<IAuthentification>();
            //personnalisation du comportement de la méthode IsValidUser
            StubAuthentification.IsValidUser(Arg.Any<User>()).Returns(false);
            var cal = new Calculatrice(StubAuthentification);

            //Action
            var resultat = Assert.Throws<ArgumentException>(
                        () => cal.Add(5, 2, new User { Id = 1, Name = "Ali", Login = "123", Password = "123" }));

            //Assert
            Assert.AreSame(resultat!.Message, "Authentification refusé");
        }
    }
}
