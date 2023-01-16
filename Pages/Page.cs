using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Pages
{
    public class Page : BasePage
    {
        public Page(OpenQA.Selenium.IWebDriver driver) : base(driver)
        { }
        public String AddButton {get;}=@"[onclick=""addElement()""]";

        public String DeleteButtonClass { get; } = @".added-manually";

        public String Uri { get; } = @"add_remove_elements/";




    }
}
