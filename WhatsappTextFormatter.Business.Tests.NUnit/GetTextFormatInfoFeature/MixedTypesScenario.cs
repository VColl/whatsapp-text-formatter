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
                Text = "The quick brown fox _jumps_ over *the* lazy dog",
                Bolds = new[] { Tuple.Create(10, 14), Tuple.Create(20, 25), Tuple.Create(44, 46) },
                Italics = new[] { Tuple.Create(10, 14), Tuple.Create(33, 36), Tuple.Create(44, 46) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedBoldStrikeThroughSingleWords()
        {
            string inputText = "The quick *~brown~* fox *~jumps*~ over ~*the~* lazy ~*dog*~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox ~jumps~ over *the* lazy dog",
                Bolds = new[] { Tuple.Create(10, 14), Tuple.Create(20, 25), Tuple.Create(44, 46) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(10, 14), Tuple.Create(33, 36), Tuple.Create(44, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedItalicStrikeThrougtSingleWords()
        {
            string inputText = "The quick ~_brown_~ fox ~_jumps~_ over _~the_~ lazy _~dog~_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick brown fox _jumps_ over ~the~ lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(10, 14), Tuple.Create(33, 36), Tuple.Create(44, 46) },
                StrikeThroughs = new[] { Tuple.Create(10, 14), Tuple.Create(20, 25), Tuple.Create(44, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedBoldItalicMultipleWords()
        {
            string inputText = "The _quick *_*brown* fox_ _*jumps over* _*the* lazy_ _dog*_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox_ jumps over _the lazy dog*",
                Bolds = new[] { Tuple.Create(11, 15), Tuple.Create(22, 31), Tuple.Create(34, 36) },
                Italics = new[] { Tuple.Create(4, 10), Tuple.Create(22, 41), Tuple.Create(43, 46) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedBoldStrikeThroughMultipleWords()
        {
            string inputText = "The ~quick *~*brown* fox~ ~*jumps over* ~*the* lazy~ ~dog*~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox~ jumps over ~the lazy dog*",
                Bolds = new[] { Tuple.Create(11, 15), Tuple.Create(22, 31), Tuple.Create(34, 36) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(4, 10), Tuple.Create(22, 41), Tuple.Create(43, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedItalicStrikeThroughMultipleWords()
        {
            string inputText = "The ~quick _~_brown_ fox~ ~_jumps over_ ~_the_ lazy~ ~dog_~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox~ jumps over ~the lazy dog_",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(11, 15), Tuple.Create(22, 31), Tuple.Create(34, 36) },
                StrikeThroughs = new[] { Tuple.Create(4, 10), Tuple.Create(22, 41), Tuple.Create(43, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void MixedAllTypes()
        {
            string inputText = "The *_~quick~_* *_~brown*_~ *_~fox~*_ ~*_jumps*~_ over _~*the_*~ lazy _~*dog_*~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _~brown~ *fox_ ~jumps*~ over ~*the~ lazy ~*dog~",
                Bolds = new[] { Tuple.Create(4, 8), Tuple.Create(10, 16), Tuple.Create(23, 25), Tuple.Create(44, 55) },
                Italics = new[] { Tuple.Create(4, 8), Tuple.Create(26, 32), Tuple.Create(39, 43), Tuple.Create(51, 55) },
                StrikeThroughs = new[] { Tuple.Create(4, 8), Tuple.Create(20, 22) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
