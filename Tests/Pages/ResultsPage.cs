using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpecFlowExercises.Pages
{
    internal class ResultsPage
    {
        private readonly IWebDriver _webDriver;

        public ResultsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Open()
        {
            throw new InvalidOperationException("The results page cannot be opened directly.");
        }

        public IReadOnlyCollection<IWebElement> SearchResultItems =>
            _webDriver.FindElements(By.CssSelector("#searchResults li.searchResultItem"));

        public int NumberOfResults => SearchResultItems.Count;

        public Book FirstResult {
            get
            {
                if (NumberOfResults == 0)
                    throw new Exception("No search results found.");

                IWebElement firstResultItem = SearchResultItems.First();

                Book result = new Book();

                result.Title = firstResultItem.FindElement(By.CssSelector(@"h3[itemprop=""name""] a")).Text;
                result.Author = firstResultItem.FindElement(By.CssSelector(@"span[itemprop=""author""] a")).Text;

                return result;
            }
        }

        internal class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
}
