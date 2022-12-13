using NUnit.Framework;
using NumerationSystemHelper;
using NSubstitute;

namespace TestNumerationSystemHelper
{
    public class UnitTestNumerationHelper
    {
        [Test]
        public void ArabicToRomanConverter_1_returnI()
        {
            //Arrange
            var nh = new NumerationHelper();
            int scenario = 1;

            //Act
            var resultat = nh.ArabicToRomanConverter(scenario);

            //Assert
            Assert.AreEqual("I", resultat);

        }

        [Test]
        public void ArabicToRomanConverter_2_returnII()
        {
            //Arrange
            var nh = new NumerationHelper();
            int scenario = 2;

            //Act
            var resultat = nh.ArabicToRomanConverter(scenario);

            //Assert
            Assert.AreEqual("II", resultat);

        }

        [TestCase(1,"I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        public void ArabicToRomanConverter_NumberFrom1To9_returnIToIX(int scenario, string resultatAttendu)
        {
            //Arrange
            var nh = new NumerationHelper();
            

            //Act
            var resultat = nh.ArabicToRomanConverter(scenario);

            //Assert
            Assert.AreEqual(resultatAttendu, resultat);

        }

        [Test]
        public void PrintRomanNumber_1_returnI()
        {
            string resultat="";
            //Arrange
            var mockView = Substitute.For<INumericalView>();
            mockView.Print(Arg.Do<string>(x => resultat = x));
            var nh = new NumerationHelper();
            int scenario = 1;

            //Act
            nh.PrintRomanNumber(scenario);

            //Assert
            Assert.AreEqual("I", resultat);

        }
    }
}