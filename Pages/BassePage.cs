using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TestProject2.Pages
{
    public class BasePage
    {
        private IWebDriver _driver;       
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;            
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public IWebElement GetElement(String id)
        {
            if (_wait.Until(foo => _driver.FindElement(By.CssSelector(id)).Displayed))
            {
                
                return _driver.FindElement(By.CssSelector(id));
            }
            else
            {                
                return null;
            }
        }

        public IList<IWebElement> GetElements(String id)
        {
            return _driver.FindElements(By.CssSelector(id));
        }

        public void ClickElement(IWebElement element)
        {
            if (_wait.Until(foo => element.Enabled))
                element.Click();
            else
            {               
                throw new StaleElementReferenceException("Element is not enabled");
            }
        }
        public void openFromURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
