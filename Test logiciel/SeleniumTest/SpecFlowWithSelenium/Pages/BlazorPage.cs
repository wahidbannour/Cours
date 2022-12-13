using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Pages
{
    public class BlazorPage
    {
        #region data
        IWebDriver driver;
        IWebElement counterButton;
        IWebElement clickMeButton;
        IWebElement resultText;
        #endregion

        #region Properties
        public IWebElement ClickMeButton { get => clickMeButton; }
        public IWebElement CounterButton { get => counterButton; }
        public IWebElement ResultText { get => resultText; }
        #endregion
        public BlazorPage(IWebDriver driver)
        {
            this.driver = driver;
            ElementFind(out counterButton, "//a[@href='counter']");
        }

        
        public void ElementFind(out IWebElement element, string xpath)
        {
            element = null;
            do
            {
                try
                {
                    element = driver.FindElement(By.XPath(xpath));
                }
                catch (Exception) { }

            } while (element == null);
        }
        public void FindElement( )
        {
            ElementFind(out clickMeButton, "//button[@class = 'btn btn-primary']");
            ElementFind(out resultText, "//p[@role='status']");
        }
    
         
    }
}
