using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class SomethingBoldScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public SomethingBoldScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleBoldWord()
        {
            string inputText = "The quick brown *fox* jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(16, 18) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void WholeBoldText()
        {
            string inputText = "*The quick brown fox jumps over the lazy dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(0, 42) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoIsolatedBoldWords()
        {
            string inputText = "The quick brown *fox* jumps over the lazy *dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(16, 18), Tuple.Create(40, 42) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void AsteriskInsideABoldWord()
        {
            string inputText = "The quick *bro*wn fox* jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick bro*wn fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 19) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonBoldAsteriskAtTheEndOfABoldWord()
        {
            string inputText = "The quick *brown fox** jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox* jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 18) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonBoldAsteriskAtTheEndOfANonBoldWord()
        {
            string inputText = "The quick *brown fox* jumps* over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps* over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 18) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldAsteriskAtTheBeginningOfABoldWord()
        {
            string inputText = "The quick **brown fox* jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 19) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
