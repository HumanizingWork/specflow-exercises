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
    public class PatronAccountSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private PatronAccount _patronAccount;
        private decimal _balance;

        public PatronAccountSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a new patron, John, has joined the library")]
        public void GivenANewPatronJohnHasJoinedTheLibrary()
        {
            this._patronAccount = new PatronAccount("John");
        }

        [Given(@"John has been fined \$(.*) for a late return")]
        public void GivenJohnHasBeenFinedForALateReturn(Decimal amount)
        {
            this._patronAccount.ChargeAccount(amount);
        }

        [Given(@"John has been charged \$(.*) for a lost book")]
        public void GivenJohnHasBeenChargedForALostBook(Decimal amount)
        {
            this._scenarioContext.Pending();
        }

        [When(@"John checks his account balance")]
        public void WhenJohnChecksHisAccountBalance()
        {
            this._balance = this._patronAccount.Balance;
        }

        [Then(@"the balance should be \$(.*)")]
        public void ThenTheBalanceShouldBe(Decimal expectedBalance)
        {
            this._balance.Should().Be(expectedBalance);
        }
    }
}
