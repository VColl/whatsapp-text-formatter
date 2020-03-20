using NUnit.Framework;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class GetTextFormatInfoFeatureSteps
    {
        private readonly TextFormatter _textFormatter;
        private TextFormatInfo _result;

        public GetTextFormatInfoFeatureSteps()
        {
            _textFormatter = new TextFormatter();
        }

        public void Setup()
        {
            _result = null;
        }

        public void WhenIInputTheText(string text)
        {
            _result = _textFormatter.GetTextFormatInfo(text);
        }

        public void ThenTheResultShouldBe(TextFormatInfo expectedResult)
        {
            Assert.AreEqual(expectedResult.Text, _result.Text);
            CollectionAssert.AreEquivalent(expectedResult.Bolds, _result.Bolds);
            CollectionAssert.AreEquivalent(expectedResult.Italics, _result.Italics);
            CollectionAssert.AreEquivalent(expectedResult.StrikeThroughs, _result.StrikeThroughs);
        }
    }
}
