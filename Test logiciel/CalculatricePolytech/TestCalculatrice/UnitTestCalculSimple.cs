using NUnit.Framework;
using Calculatrice;
using NUnit.Framework.Constraints;
using System;


namespace TestCalculatrice
{
    [TestFixture]
    public class UnitTestCalculSimple
    {
        
        [Test]
        public void Addition_OperandesZero_Zero()
        {
            //Arrange
            var cs = new CalculSimple();
            //Act
            var resultat = cs.Addition(0, 0);
            //Assert
            Assert.AreEqual(0, resultat);
        }

        [TestCase (5,6,11)]
        [TestCase(20, 3, 23)]
        [TestCase(100, 21, 121)]
        [TestCase(1023, 503, 1526)]
        [TestCase(15, 30, 45)]
        public void Addition_OperandesGeneraux_DansLeDoamineDuType(int operande1, int operande2, int resultatAttendu)
        {
            //Arrange
            var cs = new CalculSimple();
            //Act
            var resultat = cs.Addition(operande1, operande2);
            //Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestCase (int.MaxValue,1)]
        [TestCase(1,int.MaxValue)]
        public void Addition_OperandeAuLimiteSuperieur_ArgumentException(int operande1, int operande2)
        {
            var cs = new CalculSimple();
            
            var resultException = Assert.Throws<ArgumentException>(()=> cs.Addition(operande1, operande2));
           
          
            Assert.That(resultException, Is.Not.Null);
            //Assert.IsNotNull( resultat);
            //Assert.AreSame("Limite supérieure ateinte", resultat.Message);
        }

    }
}