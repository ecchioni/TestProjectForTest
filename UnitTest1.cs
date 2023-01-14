using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject2.Pages;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver? driver;
        public TestContext? testContext { get; set; }
        private static string? _url;
        public static int _numberOfClicks;     

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _url = testContext.Properties["webAppUrl"].ToString();
            _numberOfClicks = Int32.Parse(testContext.Properties["numberOfClicks"].ToString());
                    
        }
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Page testPage = new Page(driver);                    
           
            testPage.openFromURL(_url);
            for (int i = 0; i < _numberOfClicks; i++)
            {
                testPage.ClickElement(testPage.GetElement(testPage.addButton));
            }
            IList<IWebElement> elements = testPage.GetElements(testPage.deleteButtonClass);
            Assert.IsTrue(elements.Count == _numberOfClicks);

        }
    }
}