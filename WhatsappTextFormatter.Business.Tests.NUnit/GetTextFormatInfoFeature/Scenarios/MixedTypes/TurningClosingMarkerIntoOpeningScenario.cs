using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature.Scenarios.MixedTypes
{
    public class TurningClosingMarkerIntoOpeningScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public TurningClosingMarkerIntoOpeningScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void BoldChangingItalic()
        {
            string inputText = "The *quick _brown fox*_* jumps_ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox* jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(4, 19) },
                Italics = new[] { Tuple.Create(20, 26) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldChangingItalicTwice()
        {
            string inputText = "The *quick _brown fox*_* jumps_ *over _the lazy*_* dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox* jumps over _the lazy* dog",
                Bolds = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
                Italics = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldChangingStrikeThrough()
        {
            string inputText = "The *quick ~brown fox*~* jumps~ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox* jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(4, 19) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(20, 26) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldChangingStrikeThroughTwice()
        {
            string inputText = "The *quick ~brown fox*~* jumps~ *over ~the lazy*~* dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox* jumps over ~the lazy* dog",
                Bolds = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicChangingBold()
        {
            string inputText = "The _quick *brown fox_*_ jumps* over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox_ jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(20, 26) },
                Italics = new[] { Tuple.Create(4, 19) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicChangingBoldTwice()
        {
            string inputText = "The _quick *brown fox_*_ jumps* _over *the lazy_*_ dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox_ jumps over *the lazy_ dog",
                Bolds = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
                Italics = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicChangingStrikeThroughs()
        {
            string inputText = "The _quick ~brown fox_~_ jumps~ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox_ jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(4, 19) },
                StrikeThroughs = new[] { Tuple.Create(20, 26) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicChangingStrikeThroughsTwice()
        {
            string inputText = "The _quick ~brown fox_~_ jumps~ _over ~the lazy_~_ dog~";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox_ jumps over ~the lazy_ dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
                StrikeThroughs = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThroughsChangingBold()
        {
            string inputText = "The ~quick *brown fox~*~ jumps* over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox~ jumps over the lazy dog",
                Bolds = new[] { Tuple.Create(20, 26) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(4, 19) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThroughsChangingBoldTwice()
        {
            string inputText = "The ~quick *brown fox~*~ jumps* ~over *the lazy~*~ dog*";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox~ jumps over *the lazy~ dog",
                Bolds = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThroughsChangingItalic()
        {
            string inputText = "The ~quick _brown fox~_~ jumps_ over the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox~ jumps over the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(20, 26) },
                StrikeThroughs = new[] { Tuple.Create(4, 19) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThroughsChangingItalicTwice()
        {
            string inputText = "The ~quick _brown fox~_~ jumps_ ~over _the lazy~_~ dog_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox~ jumps over _the lazy~ dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(20, 26), Tuple.Create(42, 46) },
                StrikeThroughs = new[] { Tuple.Create(4, 19), Tuple.Create(28, 41) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
