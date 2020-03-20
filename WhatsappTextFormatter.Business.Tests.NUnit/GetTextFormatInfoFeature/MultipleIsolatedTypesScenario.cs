using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class MultipleIsolatedTypesScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public MultipleIsolatedTypesScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleBoldItalicStrikeThrough()
        {
            string inputText = "The quick *brown* _fox_ jumps over the lazy ~dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 14) },
                Italics = new[] { Tuple.Create(16, 18) },
                StrikeThroughs = new[] { Tuple.Create(40, 42) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SingleBoldStrikeThroughItalic()
        {
            string inputText = "The quick *brown* ~fox~ jumps over the lazy _dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(10, 14) },
                Italics = new[] { Tuple.Create(40, 42) },
                StrikeThroughs = new[] { Tuple.Create(16, 18) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SingleItalicBoldStrikeThrough()
        {
            string inputText = "The quick _brown_ *fox* jumps over the lazy ~dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(16, 18) },
                Italics = new[] { Tuple.Create(10, 14) },
                StrikeThroughs = new[] { Tuple.Create(40, 42) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SingleItalicStrikeThroughBold()
        {
            string inputText = "The quick _brown_ ~fox~ jumps over the lazy *dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(40, 42) },
                Italics = new[] { Tuple.Create(10, 14) },
                StrikeThroughs = new[] { Tuple.Create(16, 18) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SingleStrikeThroughBoldItalic()
        {
            string inputText = "The quick ~brown~ *fox* jumps over the lazy _dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(16, 18) },
                Italics = new[] { Tuple.Create(40, 42) },
                StrikeThroughs = new[] { Tuple.Create(10, 14) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SingleStrikeThroughItalicBold()
        {
            string inputText = "The quick ~brown~ _fox_ jumps over the lazy *dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(40, 42) },
                Italics = new[] { Tuple.Create(16, 18) },
                StrikeThroughs = new[] { Tuple.Create(10, 14) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
