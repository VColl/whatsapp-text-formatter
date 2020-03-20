using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class SomethingStrikeThroughScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public SomethingStrikeThroughScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleStrikeThroughWord()
        {
            string inputText = "The quick brown ~fox~ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(16, 18) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void WholeStrikeThroughText()
        {
            string inputText = "~The quick brown fox jumps over the lazy dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(0, 42) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoIsolatedStrikeThroughWords()
        {
            string inputText = "The quick brown ~fox~ jumps over the lazy ~dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(16, 18), Tuple.Create(40, 42) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TildeInsideAStrikeThroughWord()
        {
            string inputText = "The quick ~bro~wn fox~ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick bro~wn fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 19) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonStrikeThroughTildeAtTheEndOfAStrikeThroughWord()
        {
            string inputText = "The quick ~brown fox~~ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox~ jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 18) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonStrikeThroughTildeAtTheEndOfANonStrikeThroughWord()
        {
            string inputText = "The quick ~brown fox~ jumps~ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps~ over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 18) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThroughTildeAtTheBeginningOfAStrikeThroughWord()
        {
            string inputText = "The quick ~~brown fox~ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 19) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TheInconsistentCaseOfWhatsAppWeb()
        {
            string inputText = "The quick ~brown fox jump~~s~ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jump~s~ over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 23) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
