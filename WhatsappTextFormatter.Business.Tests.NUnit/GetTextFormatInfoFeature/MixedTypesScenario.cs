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
    }
}
