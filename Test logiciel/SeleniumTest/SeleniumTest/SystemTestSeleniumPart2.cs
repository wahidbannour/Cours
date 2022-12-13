using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public class SystemTestSeleniumPart2
    {
        IWebDriver driver ;

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

        [Category("ViewTest")]
        [Test]
        public void FirstTestOfSelenium()
        {
            
           
            var searchBox = driver.FindElement(By.Name("q"));
            var searchButton = driver.FindElement(By.Name("btnK"));
            searchBox.SendKeys("Selenium");
            //Task.Delay(100);
            searchButton.Click();
            var searchQuery = driver.FindElement(By.Name("q")).GetAttribute("value"); // => "Selenium"
           
            Console.WriteLine(searchQuery);
           // Assert.Pass();
        }

        [Category("ViewTest")]
        [Test]
        public void SecondTestOfSelenium()
        {
            var searchBox = driver.FindElement(By.Name("q"));
            var searchButton = driver.FindElement(By.Name("btnK"));
            searchBox.SendKeys("Tunisia");
            //Task.Delay(100);
            searchButton.Click();
            var searchQuery = driver.FindElement(By.Name("q")).GetAttribute("value"); // => "Tunisia"

            Console.WriteLine(searchQuery);
            //Assert.Pass();
        }

    }
}