using NUnit.Framework;              // framework de test
using NSubstitute;                  // framework de mocking 
using CalculatriceEPiGr2.Business;  // package de l'application de production
using CalculatriceEPiGr2.Models;    // package de l'application de production
using CalculatriceEPiGr2.Services;  // package de l'application de production
using System;

namespace CalculatriceTest
{
    internal class UTcalculAvance
    {

        [Test]
        public void AddMatrix_AuthentificationValideAnd5plus1_return6()
        {
            string resultat="0";

            //Arrange

            var stubAuthentification = Substitute.For<IAuthentification>();
            stubAuthentification.IsValidUser(Arg.Any<User>()).Returns(true);
            //mocking de l'interface IEmail
            var mockEmail = Substitute.For<IEmail>();
            //Presonnalisation de la méthode SendMail et récupération de résultat
            mockEmail.SendMail(Arg.Do<string>(arg => resultat = arg ));

            var calAv = new CalculAvance(stubAuthentification, mockEmail);

            //Act
            calAv.AddMatrix(5, 1);


            //Assert
            Assert.That(resultat, Is.EqualTo(6.ToString()));
        }
    }
}
