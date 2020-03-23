using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature.Scenarios.MixedTypes
{
    public class CancelingScenario
    {
        private readonly GetTextFormatInfoFeatureSteps _steps;

        public CancelingScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void BoldCancelingItalic()
        {
            string inputText = "The *quick _brown* fox_ *_jumps* over_ the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox_ _jumps over_ the lazy dog",
                Bolds = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void BoldCancelingStrikeThrough()
        {
            string inputText = "The *quick ~brown* fox~ *~jumps* over~ the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox~ ~jumps over~ the lazy dog",
                Bolds = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicCancelingBold()
        {
            string inputText = "The _quick *brown_ fox* _*jumps_ over* the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox* *jumps over* the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void ItalicCancelingStrikeThrough()
        {
            string inputText = "The _quick ~brown_ fox~ _~jumps_ over~ the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick ~brown fox~ ~jumps over~ the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
                StrikeThroughs = new Tuple<int, int>[] { },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThrougtCancelingBold()
        {
            string inputText = "The ~quick *brown~ fox* ~*jumps~ over* the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick *brown fox* *jumps over* the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void StrikeThrougtCancelingItalic()
        {
            string inputText = "The ~quick _brown~ fox_ ~_jumps~ over_ the lazy dog";

            var expectedResult = new TextFormatInfo
            {
                Text = "The quick _brown fox_ _jumps over_ the lazy dog",
                Bolds = new Tuple<int, int>[] { },
                Italics = new Tuple<int, int>[] { },
                StrikeThroughs = new[] { Tuple.Create(4, 15), Tuple.Create(22, 27) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }
    }
}
