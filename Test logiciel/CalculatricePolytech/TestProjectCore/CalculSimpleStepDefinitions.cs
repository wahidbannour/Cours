using Calculatrice;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TestProjectCore
{
    [Binding]
    public class CalculSimpleStepDefinitions
    {
        CalculSimple cs;
        int op1, op2, result;

        [Given(@"user want add (.*) and (.*)")]
        public void GivenUserWantAddAnd(int p0, int p1)
        {
            cs = new CalculSimple();
            op1 = p0;
            op2 = p1;
        }

        [When(@"user click addbutton")]
        public void WhenUserClickAddbutton()
        {
            cs.Addition(op1, op2);
        }

        [Then(@"the result (.*) is printed on the screen")]
        public void ThenTheResultIsPrintedOnTheScreen(int p0)
        {
            Assert.AreEqual(p0,result);
        }

        [Given(@"user want to substruct (.*) and (.*)")]
        public void GivenUserWantToSubstructAnd(int p0, int p1)
        {
            cs = new CalculSimple();
            op1 = p0;
            op2 = p1;
        }

        [When(@"user click substruct-button")]
        public void WhenUserClickSubstruct_Button()
        {
            cs.Soustraction(op1, op2);
        }
    }
}
