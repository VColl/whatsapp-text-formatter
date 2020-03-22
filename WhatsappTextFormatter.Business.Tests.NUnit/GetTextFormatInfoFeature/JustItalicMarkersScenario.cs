using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class JustItalicMarkersScenario
    {
        private GetTextFormatInfoFeatureSteps _steps;

        public JustItalicMarkersScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleItalicMarker()
        {
            string inputText = "_";

            var expectedResult = new TextFormatInfo
            {
                Text = "_",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoItalicMarkers()
        {
            string inputText = "__";

            var expectedResult = new TextFormatInfo
            {
                Text = "__",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ThreeItalicMarkers()
        {
            string inputText = "___";

            var expectedResult = new TextFormatInfo
            {
                Text = "___",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FourItalicMarkers()
        {
            string inputText = "____";

            var expectedResult = new TextFormatInfo
            {
                Text = "____",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FiveItalicMarkers()
        {
            string inputText = "_____";

            var expectedResult = new TextFormatInfo
            {
                Text = "_____",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SixItalicMarkers()
        {
            string inputText = "______";

            var expectedResult = new TextFormatInfo
            {
                Text = "______",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void LotsOfItalicMarker()
        {
            string inputText = "_ __ ___ _ __ ____ _ __ _____ _ _ __";

            var expectedResult = new TextFormatInfo
            {
                Text = "_ __ ___ _ __ ____ _ __ _____ _ _ __",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
