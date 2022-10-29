using NUnit.Framework;
using Calculatrice;
using NUnit.Framework.Constraints;
using System;
using System.Security.Authentication;
using NSubstitute;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace TestCalculatrice
{
    [TestFixture]
    public class UnitTestCalculAvance
    {
        [Test]
        public void ValeurAbsolue_Zero_Zero()
        {
            //Arrange
            var stubAuthentification = Substitute.For<IAuthentification>();
            stubAuthentification.IsAuthentifie.Returns(true);
            
            var ca = new CalculAvance(stubAuthentification);
            

            //Action
            var result = ca.ValeurAbsolue(0);
            //Asert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ValeurAbsolue_NotAuthentified_AuthentificationException()
        {
            //Arrange
            var StubAuthentification = Substitute.For<IAuthentification>();
            StubAuthentification.IsAuthentifie.Returns(false);
            var ca = new CalculAvance(StubAuthentification);
            
            //Act
            var exception = Assert.Throws<AuthenticationException>(()=> ca.ValeurAbsolue(0));
            //Asert
            Assert.NotNull(exception);
        }

        [Test]
        public void CalculMatriciel_Zero_1()
        {
            //Arrange
            int resultat = 0;
            var StubAuthentification = Substitute.For<IAuthentification>();
            var MockEmail = Substitute.For<IEmailManager>();
            // première façon avec un Do sur l'argument souhaité
            // et un accès direct à l'argument en le récupérant
            // dans une variable locale
            MockEmail.SendMail(Arg.Any<string>(),
                               Arg.Do<int>(arg =>  resultat = arg));

            // deuxième façon en déclanchant une action Do
            // après une condition When
            // l'argument est récupéré par son index.
            //MockEmail.When(x =>
            //        x.SendMail(Arg.Any<string>(),
            //                    Arg.Any<int>())).
            //                    Do(x => resultat = (int)x[1]);// 1 est l'index du deuxième argument d'appel de sendMail
            StubAuthentification.IsAuthentifie.Returns(true);
            var ca = new CalculAvance(StubAuthentification,MockEmail);
            

            //Action
            ca.CalculMatriciel(0);
            //Assert
            Assert.AreEqual(1, resultat);
        }

        public void Matriciel_1_1()
        {
            var MockMail = new FakeMail();
            var StubAuthentification = new FakeAutentification();
            var ca = new CalculAvance(StubAuthentification, MockMail);

            ca.CalculMatriciel(1);

            Assert.Equals(1, MockMail.Resultat);
        }


    }


    /// <summary>
    /// implémentation de laclasse factice de IAutehtification
    /// </summary>
    public class FakeAutentification : IAuthentification
    {
        bool _isAuthentification = false;
        public bool IsAuthentifie => _isAuthentification;

        public bool Authentifier(User user)
        {
            _isAuthentification = true;
            return true;
        }
    }

    public class FakeMail : IEmailManager
    {

        public int Resultat = 0;

        public void SendMail(string subject, int resultat)
        {
            Resultat = resultat;    
        }
    }


}
