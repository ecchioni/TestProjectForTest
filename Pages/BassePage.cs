using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public Logger logger;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public IWebElement GetElement(String id)
        {
            if (wait.Until(foo => driver.FindElement(By.CssSelector(id)).Displayed))
            {
                
                return driver.FindElement(By.CssSelector(id));
            }
            else
            {                
                return null;
            }
        }

        public IList<IWebElement> GetElements(String id)
        {
            return driver.FindElements(By.CssSelector(id));
        }

        public void ClickElement(IWebElement element)
        {
            if (wait.Until(foo => element.Enabled))
                element.Click();
            else
            {               
                throw new StaleElementReferenceException("Element is not enabled");
            }
        }
        public void openFromURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
