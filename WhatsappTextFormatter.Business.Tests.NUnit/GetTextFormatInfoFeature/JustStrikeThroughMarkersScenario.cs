using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class JustStrikeThroughMarkersScenario
    {
        private GetTextFormatInfoFeatureSteps _steps;

        public JustStrikeThroughMarkersScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleStrikeThroughMarker()
        {
            string inputText = "~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoStrikeThroughMarkers()
        {
            string inputText = "~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ThreeStrikeThroughMarkers()
        {
            string inputText = "~~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FourStrikeThroughMarkers()
        {
            string inputText = "~~~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FiveStrikeThroughMarkers()
        {
            string inputText = "~~~~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~~~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SixStrikeThroughMarkers()
        {
            string inputText = "~~~~~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~~~~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void LotsOfStrikeThroughMarker()
        {
            string inputText = "~ ~~ ~~~ ~ ~~ ~~~~ ~ ~~ ~~~~~ ~ ~ ~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~ ~~ ~~~ ~ ~~ ~~~~ ~ ~~ ~~~~~ ~ ~ ~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
