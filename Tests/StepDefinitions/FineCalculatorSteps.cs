using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LibraryDomain;
using TechTalk.SpecFlow;

namespace SpecFlowExercises.StepDefinitions
{
    [Binding]
    public class FineCalculatorSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private decimal _calculatedFine = -1;
        private FineCalculator _fineCalculator;

        public FineCalculatorSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the standard fine per day is \$(.*)")]
        public void GivenTheStandardFinePerDayIs(Decimal finePerDay)
        {
            this._fineCalculator = new FineCalculator(finePerDay);
        }

        [When(@"the patron returns a book (.*) days late")]
        public void WhenThePatronReturnsABookDaysLate(int daysLate)
        {
            this._calculatedFine = this._fineCalculator.CalculateFine(daysLate);
        }

        [When(@"the patron returns a book on time")]
        public void WhenThePatronReturnsABookOnTime()
        {
            this._calculatedFine = this._fineCalculator.CalculateFine(0);
        }

        [Then(@"the there should be no fine")]
        public void ThenTheThereShouldBeNoFine()
        {
            this._calculatedFine.Should().Be(0);
        }

        [Then(@"there should be a \$(.*) fine")]
        public void ThenThereShouldBeAFine(Decimal expectedFine)
        {
            this._calculatedFine.Should().Be(expectedFine);
        }
    }
}
