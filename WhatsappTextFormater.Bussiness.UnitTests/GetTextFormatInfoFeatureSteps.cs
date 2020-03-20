using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace WhatsappTextFormater.Bussiness.Tests
{
    [Binding]
    public class GetTextFormatInfoFeatureSteps
    {
        private ScenarioContext _scenarioContext;

        public GetTextFormatInfoFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I input the text (.*)")]
        public void WhenIInputTheTextTheQuickBrownFoxJumpsOverTheLazyDog(string text)
        {
            //_scenarioContext.Pending();
        }
        
        [Then(@"the property Text of the result should be (.*)")]
        public void ThenThePropertyTextOfTheResultShouldBeTheQuickBrownFoxJumpsOverTheLazyDog(string unformattedText)
        {
            //_scenarioContext.Pending();
        }
        
        [Then(@"the property Bolds of the result should be (.*)")]
        public void ThenThePropertyBoldsOfTheResultShouldBe(string bolds)
        {
            //_scenarioContext.Pending();
        }
        
        [Then(@"the property Italics of the result should be (.*)")]
        public void ThenThePropertyItalicsOfTheResultShouldBe(string italics)
        {
            //_scenarioContext.Pending();
        }
        
        [Then(@"the property StrikeThroughs of the result should be (.*)")]
        public void ThenThePropertyStrikeThroughsOfTheResultShouldBe(string strikeThroughs)
        {
            Assert.Fail();
            //_scenarioContext.Pending();
        }
    }
}
