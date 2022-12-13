using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SeleniumTest.Pages;
using System;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public class SystemTestSeleniumPart3
    {
        IWebDriver driver ;
        GoogleSearchPage pageGoogle;

        [SetUp] // méthode qui s'exécute avant chaque test
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            Console.WriteLine("Initialisation du site web");
        }

        [TearDown] // méthode qui s'exécute après chaque test
        public void Clean()
        {
            driver.Close();
            Console.WriteLine("fermer le site web");
        }
        [OneTimeTearDown]
        public void Quit()
        {
            driver.Quit();
        }

        [Category("ViewTest P3")]
        [Test]
        public void FirstTestOfSelenium()
        {
            pageGoogle =new GoogleSearchPage(driver);
            pageGoogle.SearchBox.SendKeys("Selenium");
            var searchQuery = pageGoogle.SearchBox.GetAttribute("value"); // => "Selenium"
            
            pageGoogle.SearchButton.Click();
            
           
            Console.WriteLine(searchQuery);
           // Assert.Pass();
        }

        [Category("ViewTest P3")]
        [Test]
        public void SecondTestOfSelenium()
        {
            pageGoogle = new GoogleSearchPage(driver);
            pageGoogle.SearchBox.SendKeys("Tunisia");
            var searchQuery = pageGoogle.SearchBox.GetAttribute("value"); // => "Tunisia"

            pageGoogle.SearchButton.Click();
            

            Console.WriteLine(searchQuery);
            //Assert.Pass();
        }

    }
}