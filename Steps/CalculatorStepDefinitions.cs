using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowCalucator.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int FirstNumber, SecoundNumber,Result;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            FirstNumber = number;
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

         //   _scenarioContext.Pending();
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {

            SecoundNumber = number;
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

          //  _scenarioContext.Pending();
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            Result = FirstNumber + SecoundNumber;

          //  _scenarioContext.Pending();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int value)
        {
            //TODO: implement assert (verification) logic
            Assert.AreEqual(value, Result);
         //   _scenarioContext.Pending();
        }

        [When(@"the two numbers are Subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            //TODO: implement act (action) logic

            Result = FirstNumber - SecoundNumber;

            //  _scenarioContext.Pending();
        }
        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            Result = FirstNumber / SecoundNumber;
        }
    }
}
