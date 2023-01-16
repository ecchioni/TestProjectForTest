using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject2.Pages;

namespace TestProject2
{
    [TestClass]
    public class UnitTestClass
    {
        private IWebDriver? driver;
        public TestContext? testContext { get; set; }
        private static string? _baseUrl;
        private static int _numberOfClicks;     

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _baseUrl = testContext.Properties["webAppUrl"].ToString();
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
        public void TestTheNumberOfElementsGeneratedOnThePageIsCorrect()
        {
            Page testPage = new Page(driver);
            string pageToOpen = _baseUrl + testPage.Uri;
           
            testPage.openFromURL(pageToOpen);
            for (int i = 0; i < _numberOfClicks; i++)
            {
                testPage.ClickElement(testPage.GetElement(testPage.AddButton));
            }
            IList<IWebElement> elements = testPage.GetElements(testPage.DeleteButtonClass);
            Assert.IsTrue(elements.Count == _numberOfClicks);

        }
    }
}