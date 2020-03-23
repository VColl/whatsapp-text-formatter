using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature.Scenarios.IsolatedTypes
{
    public class SomethingItalicScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public SomethingItalicScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleItalicWord()
        {
            string inputText = "The quick brown _fox_ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(16, 18) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void WholeItalicText()
        {
            string inputText = "_The quick brown fox jumps over the lazy dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(0, 42) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoIsolatedItalicWords()
        {
            string inputText = "The quick brown _fox_ jumps over the lazy _dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(16, 18), Tuple.Create(40, 42) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void DashInsideAItalicWord()
        {
            string inputText = "The quick _bro_wn fox_ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick bro_wn fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 19) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonItalicDashAtTheEndOfABoldWord()
        {
            string inputText = "The quick _brown fox__ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox_ jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 18) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void NonItalicDashAtTheEndOfANonBoldWord()
        {
            string inputText = "The quick _brown fox_ jumps_ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps_ over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 18) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicDashAtTheBeginningOfABoldWord()
        {
            string inputText = "The quick __brown fox_ jumps over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 19) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TheInconsistentCaseOfWhatsAppWeb()
        {
            string inputText = "The quick _brown fox jump__s_ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jump_s_ over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 23) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
