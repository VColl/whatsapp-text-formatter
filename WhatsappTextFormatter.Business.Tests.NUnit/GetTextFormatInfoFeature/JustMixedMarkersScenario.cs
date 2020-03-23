using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature
{
    public class JustMixedMarkersScenario
    {
        private GetTextFormatInfoFeatureSteps _steps;

        public JustMixedMarkersScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void ShortUnformatted()
        {
            string inputText = "*_~";

            var expectedResult = new TextFormatInfo
            {
                Text = "*_~",
                Bolds = new Tuple<int, int>[] {  },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void LongUnformatted()
        {
            string inputText = "~~**__**~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~**__**~~",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldAndStrikeThrough()
        {
            string inputText = "~*_*_*~";

            var expectedResult = new TextFormatInfo
            {
                Text = "__*",
                Bolds = new [] { Tuple.Create(0,0) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new [] { Tuple.Create(0,2) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void OnlyBold()
        {
            string inputText = "~~**__*__**~~";

            var expectedResult = new TextFormatInfo
            {
                Text = "~~**____*~~",
                Bolds = new [] { Tuple.Create(6,7) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicAndStrikeThrough()
        {
            string inputText = "_*_**__***___~*~_*";

            var expectedResult = new TextFormatInfo
            {
                Text = "***__***___*_*",
                Bolds = new Tuple<int, int>[] { },
                Italics = new [] { Tuple.Create(0,0) },
                StrikeThroughs = new [] { Tuple.Create(11,11) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldAndStrikeThrough2()
        {
            string inputText = "___~~~*~_*~*~___";

            var expectedResult = new TextFormatInfo
            {
                Text = "___~~~~_*___",
                Bolds = new [] { Tuple.Create(6,7) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new [] { Tuple.Create(8,8) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicAndStrikeThrough2()
        {
            string inputText = "__~_*~~__~~_*_~~**_** **__**~~_*__~* _____";

            var expectedResult = new TextFormatInfo
            {
                Text = "___*~__~~*~~**** **_**~~*_~* _____",
                Bolds = new Tuple<int, int>[] {  },
                Italics = new Tuple<int, int>[] { Tuple.Create(9,9), Tuple.Create(14,18), Tuple.Create(24, 24) },
                StrikeThroughs = new Tuple<int, int>[] { Tuple.Create(2,3),  },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
