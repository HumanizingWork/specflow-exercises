using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium.Chrome;
using SpecFlowExercises.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowExercises.StepDefinitions
{
    [Binding]
    public class OpenLibrarySteps : IDisposable
    {
        private readonly ScenarioContext _scenarioContext;
        private ChromeDriver _chromeDriver;
        private readonly AdvancedSearchPage _advancedSearchPage;
        private readonly ResultsPage _resultsPage;

        public OpenLibrarySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _chromeDriver = new ChromeDriver();
            _advancedSearchPage = new AdvancedSearchPage(_chromeDriver);
            _resultsPage = new ResultsPage(_chromeDriver);
        }

        public void Dispose()
        {
            if (_chromeDriver != null)
            {
                _chromeDriver.Dispose();
                _chromeDriver = null;
            }
        }

        [When(@"I do an advanced search with Title ""(.*)""")]
        public void WhenIDoAnAdvancedSearchWithTitle(string query)
        {
            _advancedSearchPage.Open();
            _advancedSearchPage.TitleField.SendKeys(query);
            _advancedSearchPage.SearchButton.Click();
        }

        [Then(@"the only result should be:")]
        public void ThenTheOnlyResultShouldBe(Table table)
        {
            _resultsPage.NumberOfResults.Should().Be(1);

            ResultsPage.Book expectedBook = table.CreateInstance<ResultsPage.Book>();

            ResultsPage.Book actualBook = _resultsPage.FirstResult;
            actualBook.Title.Should().Be(expectedBook.Title);
            actualBook.Author.Should().Be(expectedBook.Author);
        }
    }
}