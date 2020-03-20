using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class UnformattedTextScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public UnformattedTextScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void UnformattedTextWithoutAsterisks()
        {
            string inputText = "The quick brown fox jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void UnformattedTextBeginningWithAnAsterisk()
        {
            string inputText = "*The quick brown fox jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "*The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void UnformattedTextEndingWithAnAsterisk()
        {
            string inputText = "The quick brown fox jumps over the lazy dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog*",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void UnformattedTextBeginningWithTwoAsterisks()
        {
            string inputText = "**The quick brown fox jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "**The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void UnformattedTextEndingWithTwoAsterisks()
        {
            string inputText = "The quick brown fox jumps over the lazy dog**";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog**",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
