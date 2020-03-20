using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class MixedTypesScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public MixedTypesScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void MixedBoldItalicSingleWords()
        {
            string inputText = "The quick *_brown_* fox *_jumps*_ over _*the_* lazy _*dog*_";

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
