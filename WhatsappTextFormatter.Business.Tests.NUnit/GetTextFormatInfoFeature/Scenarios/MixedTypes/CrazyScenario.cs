using NUnit.Framework;
using System;

namespace WhatsappTextFormatter.Business.Tests.NUnit.GetTextFormatInfoFeature.Scenarios.MixedTypes
{
    public class CrazyScenario
    {
        private GetTextFormatInfoFeatureSteps _steps;

        public CrazyScenario()
        {
            _steps = new GetTextFormatInfoFeatureSteps();
        }

        [SetUp]
        public void Setup()
        {
            _steps.Setup();
        }

        [Test]
        public void CrazyScenario1()
        {
            string inputText = "*The ***qui*ck** _**br*own*_ fox j~~u_mps_* *over ~~the~~* lazy _*d~o~g*_";

            var expectedResult = new TextFormatInfo
            {
                Text = "The **qui*ck** *br*own fox j~~u_mps_* over ~the~ lazy d~o~g",
                Bolds = new Tuple<int, int>[] { Tuple.Create(0,4), Tuple.Create(15,21), Tuple.Create(38,47), Tuple.Create(54,58)},
                Italics = new Tuple<int, int>[] { Tuple.Create(15,21), Tuple.Create(54,58) },
                StrikeThroughs = new Tuple<int, int>[] { Tuple.Create(43, 46) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        [Test]
        public void CrazyScenario2()
        {
            string inputText = "___**_T~~he~~ ***~~__**_qu~ick*** bro_**_*_wn *__fox ju*_*_m~ps o*_*_ver the _**__*_*lazy___*_~~*_~*_*~_*_**_* ~dog___~~____";

            var expectedResult = new TextFormatInfo
            {
                Text = "___**T~~he~~ ***~~_**qu~ick*** bro***_wn *_fox ju*_m~ps o_ver the _*__*lazy__~~*_**** ~dog__~~____",
                Bolds = new Tuple<int, int>[] { Tuple.Create(50, 56), Tuple.Create(57, 66), Tuple.Create(70, 76), Tuple.Create(80, 80) },
                Italics = new Tuple<int, int>[] { Tuple.Create(5, 17), Tuple.Create(21, 33), Tuple.Create(36, 41), Tuple.Create(50, 56), Tuple.Create(70, 74), Tuple.Create(77, 79), Tuple.Create(81,81), Tuple.Create(84,89) },
                StrikeThroughs = new Tuple<int, int>[] { Tuple.Create(80, 80) },
            };

            _steps.WhenIInputTheText(inputText);
            _steps.ThenTheResultShouldBe(expectedResult);
        }

        //[Test]
        //public void ThreeBoldMarkers()
        //{
        //    string inputText = "***";

        //    var expectedResult = new TextFormatInfo
        //    {
        //        Text = "***",
        //        Bolds = new Tuple<int, int>[] { },
        //        Italics = new Tuple<int, int>[] { },
        //        StrikeThroughs = new Tuple<int, int>[] { },
        //    };

        //    _steps.WhenIInputTheText(inputText);
        //    _steps.ThenTheResultShouldBe(expectedResult);
        //}

        //[Test]
        //public void FourBoldMarkers()
        //{
        //    string inputText = "****";

        //    var expectedResult = new TextFormatInfo
        //    {
        //        Text = "****",
        //        Bolds = new Tuple<int, int>[] { },
        //        Italics = new Tuple<int, int>[] { },
        //        StrikeThroughs = new Tuple<int, int>[] { },
        //    };

        //    _steps.WhenIInputTheText(inputText);
        //    _steps.ThenTheResultShouldBe(expectedResult);
        //}

        //[Test]
        //public void FiveBoldMarkers()
        //{
        //    string inputText = "*****";

        //    var expectedResult = new TextFormatInfo
        //    {
        //        Text = "*****",
        //        Bolds = new Tuple<int, int>[] { },
        //        Italics = new Tuple<int, int>[] { },
        //        StrikeThroughs = new Tuple<int, int>[] { },
        //    };

        //    _steps.WhenIInputTheText(inputText);
        //    _steps.ThenTheResultShouldBe(expectedResult);
        //}

        //[Test]
        //public void SixBoldMarkers()
        //{
        //    string inputText = "******";

        //    var expectedResult = new TextFormatInfo
        //    {
        //        Text = "******",
        //        Bolds = new Tuple<int, int>[] { },
        //        Italics = new Tuple<int, int>[] { },
        //        StrikeThroughs = new Tuple<int, int>[] { },
        //    };

        //    _steps.WhenIInputTheText(inputText);
        //    _steps.ThenTheResultShouldBe(expectedResult);
        //}

        //[Test]
        //public void LotsOfBoldMarker()
        //{
        //    string inputText = "* ** *** * ** **** * ** ***** * * **";

        //    var expectedResult = new TextFormatInfo
        //    {
        //        Text = "* ** *** * ** **** * ** ***** * * **",
        //        Bolds = new Tuple<int, int>[] { },
        //        Italics = new Tuple<int, int>[] { },
        //        StrikeThroughs = new Tuple<int, int>[] { },
        //    };

        //    _steps.WhenIInputTheText(inputText);
        //    _steps.ThenTheResultShouldBe(expectedResult);
        //}
    }
}
