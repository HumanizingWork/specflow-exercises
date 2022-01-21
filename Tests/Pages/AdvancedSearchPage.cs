using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpecFlowExercises.Pages
{
    internal class AdvancedSearchPage
    {
        private readonly IWebDriver _webDriver;

        public AdvancedSearchPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Open()
        {
            _webDriver.Url = "https://openlibrary.org/advancedsearch";
        }

        public IWebElement TitleField => _webDriver.FindElement(By.Id("qtop-title"));

        public IWebElement SearchButton =>
            _webDriver.FindElement(By.CssSelector(@"#contentBody form input[type=""submit""]"));
    }
}
