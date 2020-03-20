using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            AssertIndexes(expectedResult.Bolds, _result.Bolds);
            AssertIndexes(expectedResult.Italics, _result.Italics);
            AssertIndexes(expectedResult.StrikeThroughs, _result.StrikeThroughs);
        }

        private void AssertIndexes(IEnumerable<Tuple<int, int>> expectedIndexes, IEnumerable<Tuple<int, int>> actualIndexRanges) =>
            CollectionAssert.AreEquivalent(GetIndexes(expectedIndexes), GetIndexes(actualIndexRanges));

        private IEnumerable<int> GetIndexes(IEnumerable<Tuple<int, int>> indexRanges) =>
            indexRanges.SelectMany(range => Enumerable.Range(range.Item1, range.Item2));
    }
}
