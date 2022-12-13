using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace SeleniumTest
{
    public class SystemTestSelenium
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Category("ViewTest")]
        [Test]
        public void FirstTestOfSelenium()
        {
            var driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            var searchBox = driver.FindElement(By.Name("q"));
            var searchButton = driver.FindElement(By.Name("btnK"));
            searchBox.SendKeys("Selenium");
            searchButton.Click();
            var searchQuery = driver.FindElement(By.Name("q")).GetAttribute("value"); // => "Selenium"
            driver.Quit();
            Console.WriteLine(searchQuery);
            Assert.Pass();
        }
    }
}