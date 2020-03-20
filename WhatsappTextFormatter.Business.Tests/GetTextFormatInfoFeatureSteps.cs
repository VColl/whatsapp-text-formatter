using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using WhatsappTextFormatter.Business;

namespace WhatsappTextFormatter.Bussiness.Tests
{
    [Binding()]
    public class GetTextFormatInfoFeatureSteps
    {
        private readonly TextFormatter _textFormatter;
        private TextFormatInfo _result;

        public GetTextFormatInfoFeatureSteps()
        {
            _textFormatter = new TextFormatter();
        }

        [When(@"I input the text (.*)")]
        public void WhenIInputTheText(string text)
        {
            _result = _textFormatter.GetTextFormatInfo(text);
        }
        
        [Then(@"the property Text of the result should be (.*)")]
        public void ThenThePropertyTextOfTheResultShouldBe(string unformattedText)
        {
            Assert.AreEqual(unformattedText, _result.Text);
        }
        
        [Then(@"the property Bolds of the result should be (.*)")]
        public void ThenThePropertyBoldsOfTheResultShouldBe(string bolds)
        {
            var actual = JsonConvert.SerializeObject(_result.Bolds);
            Assert.AreEqual(bolds, actual);
        }
        
        [Then(@"the property Italics of the result should be (.*)")]
        public void ThenThePropertyItalicsOfTheResultShouldBe(string italics)
        {
            var actual = JsonConvert.SerializeObject(_result.Italics);
            Assert.AreEqual(italics, actual);
        }
        
        [Then(@"the property StrikeThroughs of the result should be (.*)")]
        public void ThenThePropertyStrikeThroughsOfTheResultShouldBe(string strikeThroughs)
        {
            var actual = JsonConvert.SerializeObject(_result.StrikeThroughs);
            Assert.AreEqual(strikeThroughs, actual);
        }
    }
}
