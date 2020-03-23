using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature.Scenarios.JustMarkers
{
    public class JustBoldMarkersScenario
    {
        private GetTextFormatInfoFeatureSteps _steps;

        public JustBoldMarkersScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void SingleBoldMarker()
        {
            string inputText = "*";

            var expectedResult = new TextFormatInfo
            {
                Text = "*",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void TwoBoldMarkers()
        {
            string inputText = "**";

            var expectedResult = new TextFormatInfo
            {
                Text = "**",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ThreeBoldMarkers()
        {
            string inputText = "***";

            var expectedResult = new TextFormatInfo
            {
                Text = "***",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FourBoldMarkers()
        {
            string inputText = "****";

            var expectedResult = new TextFormatInfo
            {
                Text = "****",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void FiveBoldMarkers()
        {
            string inputText = "*****";

            var expectedResult = new TextFormatInfo
            {
                Text = "*****",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void SixBoldMarkers()
        {
            string inputText = "******";

            var expectedResult = new TextFormatInfo
            {
                Text = "******",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void LotsOfBoldMarker()
        {
            string inputText = "* ** *** * ** **** * ** ***** * * **";

            var expectedResult = new TextFormatInfo
            {
                Text = "* ** *** * ** **** * ** ***** * * **",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
