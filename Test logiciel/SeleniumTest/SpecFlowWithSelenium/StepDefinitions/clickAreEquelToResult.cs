using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowWithSelenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class clickAreEqualToResult
    {
        IWebDriver driver;
        BlazorPage page;

        [Given(@"user open the blazor site and click on counter menu")]
        public void GivenUserOpenTheBlazorSiteAndClickOnCounterMenu()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost:5200/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            page = new BlazorPage(driver);
            page.CounterButton.Click();
        }

        [When(@"user click on clickme button (.*) times")]
        public void WhenUserClickOnClickmeButtonTimes(int n)
        {
            page.FindElement();
            for (int i = 0; i < n; i++)
                page.ClickMeButton.Click();
        }

        [Then(@"result must be equal to (.*)")]
        public void ThenResultMustBeEqualTo(int n)
        {
            Assert.IsTrue(page.ResultText.Text.Contains(n.ToString()));
            driver.Close();
        }



    }
}
