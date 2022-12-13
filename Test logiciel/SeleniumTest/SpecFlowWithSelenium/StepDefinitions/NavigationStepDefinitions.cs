using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using SpecFlowWithSelenium.Pages;

namespace SpecFlowWithSelenium.StepDefinitions
{
    
    [Binding]
    public class NavigationStepDefinitions
    {
        IWebDriver driver;
        BlazorPage page;
       

        [Given(@"user open the blazor site")]
        public void GivenUserOpenTheBlazorSite()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost:5200/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            page = new BlazorPage(driver);
        }

        [When(@"user click on counter menu")]
        public void WhenUserClickOnCounterMenu()
        {
           
            page.CounterButton.Click();
        }

        [Then(@"the counter page is visible")]
        public void ThenTheCounterPageIsVisible()
        {
            page.FindElement();
            
            Assert.That(page.ClickMeButton.Displayed, Is.True);
            driver.Close();
        }
    }
}
