using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public class FullTextFormatter
    {
        private readonly BoldTextFormatter _boldTextFormatter;
        private readonly ItalicTextFormatter _italicTextFormatter;
        private readonly StrikeThroughTextFormatter _strikeThroughTextFormatter;

        public FullTextFormatter()
        {
            _boldTextFormatter = new BoldTextFormatter();
            _italicTextFormatter = new ItalicTextFormatter();
            _strikeThroughTextFormatter = new StrikeThroughTextFormatter();
        }

        public TextFormatInfo GetTextFormatInfo(string text)
        {
            var info = new TextFormatInfo();

            info.Bolds = _boldTextFormatter.GetIndexRanges(text);
            info.Italics = _italicTextFormatter.GetIndexRanges(text);
            info.StrikeThroughs = _strikeThroughTextFormatter.GetIndexRanges(text);

            var invalidBolds = new List<Tuple<int, int>>();
            foreach (var boldRange in info.Bolds)
            {
                foreach (var italicRange in info.Italics)
                {
                    if (italicRange.Item1 < boldRange.Item1 && boldRange.Item1 < italicRange.Item2 && italicRange.Item2 < boldRange.Item2)
                    {
                        invalidBolds.Add(boldRange);
                        break;
                    }
                }

                foreach (var strikeThroughRange in info.StrikeThroughs)
                {
                    if (strikeThroughRange.Item1 < boldRange.Item1 && boldRange.Item1 < strikeThroughRange.Item2 && strikeThroughRange.Item2 < boldRange.Item2)
                    {
                        invalidBolds.Add(boldRange);
                        break;
                    }
                }
            }

            var invalidItalics = new List<Tuple<int, int>>();
            foreach (var italicRange in info.Italics)
            {
                foreach (var boldRange in info.Bolds)
                {
                    if (boldRange.Item1 < italicRange.Item1 && italicRange.Item1 < boldRange.Item2 && boldRange.Item2 < italicRange.Item2)
                    {
                        invalidItalics.Add(italicRange);
                        break;
                    }
                }

                foreach (var strikeThroughRange in info.StrikeThroughs)
                {
                    if (strikeThroughRange.Item1 < italicRange.Item1 && italicRange.Item1 < strikeThroughRange.Item2 && strikeThroughRange.Item2 < italicRange.Item2)
                    {
                        invalidItalics.Add(italicRange);
                        break;
                    }
                }
            }

            var invalidStrikeThroughs = new List<Tuple<int, int>>();
            foreach (var strikeThroughRange in info.StrikeThroughs)
            {
                foreach (var boldRange in info.Bolds)
                {
                    if (boldRange.Item1 < strikeThroughRange.Item1 && strikeThroughRange.Item1 < boldRange.Item2 && boldRange.Item2 < strikeThroughRange.Item2)
                    {
                        invalidStrikeThroughs.Add(strikeThroughRange);
                        break;
                    }
                }

                foreach (var italicRange in info.Italics)
                {
                    if (italicRange.Item1 < strikeThroughRange.Item1 && strikeThroughRange.Item1 < italicRange.Item2 && italicRange.Item2 < strikeThroughRange.Item2)
                    {
                        invalidStrikeThroughs.Add(strikeThroughRange);
                        break;
                    }
                }
            }

            info.Bolds = info.Bolds.Except(invalidBolds);
            info.Italics = info.Italics.Except(invalidItalics);
            info.StrikeThroughs = info.StrikeThroughs.Except(invalidStrikeThroughs);

            var indexesToBeRemoved = info.Bolds.SelectMany(r => new[] { r.Item1, r.Item2 })
                .Union(info.Italics.SelectMany(r => new[] { r.Item1, r.Item2 }))
                .Union(info.StrikeThroughs.SelectMany(r => new[] { r.Item1, r.Item2 }))
                .OrderBy(i => i);

            int counter = 0;
            foreach (var index in indexesToBeRemoved)
                text = text.Remove(index - counter++, 1);

            var fixedBolds = new List<Tuple<int, int>>();
            foreach (var boldRange in info.Bolds)
            {
                var count1 = info.Bolds.Count(r => r.Item1 < boldRange.Item1) + info.Bolds.Count(r => r.Item2 < boldRange.Item1)
                    + info.Italics.Count(r => r.Item1 < boldRange.Item1) + info.Italics.Count(r => r.Item2 < boldRange.Item1)
                    + info.StrikeThroughs.Count(r => r.Item1 < boldRange.Item1) + info.StrikeThroughs.Count(r => r.Item2 < boldRange.Item1);

                var count2 = info.Bolds.Count(r => r.Item1 < boldRange.Item2) + info.Bolds.Count(r => r.Item2 <= boldRange.Item2)
                    + info.Italics.Count(r => r.Item1 < boldRange.Item2) + info.Italics.Count(r => r.Item2 <= boldRange.Item2)
                    + info.StrikeThroughs.Count(r => r.Item1 < boldRange.Item2) + info.StrikeThroughs.Count(r => r.Item2 <= boldRange.Item2);

                fixedBolds.Add(Tuple.Create(boldRange.Item1 - count1, boldRange.Item2 - count2));
            }

            var fixedItalics = new List<Tuple<int, int>>();
            foreach (var italicRange in info.Italics)
            {
                var count1 = info.Bolds.Count(r => r.Item1 < italicRange.Item1) + info.Bolds.Count(r => r.Item2 < italicRange.Item1)
                    + info.Italics.Count(r => r.Item1 < italicRange.Item1) + info.Italics.Count(r => r.Item2 < italicRange.Item1)
                    + info.StrikeThroughs.Count(r => r.Item1 < italicRange.Item1) + info.StrikeThroughs.Count(r => r.Item2 < italicRange.Item1);

                var count2 = info.Bolds.Count(r => r.Item1 < italicRange.Item2) + info.Bolds.Count(r => r.Item2 <= italicRange.Item2)
                    + info.Italics.Count(r => r.Item1 < italicRange.Item2) + info.Italics.Count(r => r.Item2 <= italicRange.Item2)
                    + info.StrikeThroughs.Count(r => r.Item1 < italicRange.Item2) + info.StrikeThroughs.Count(r => r.Item2 <= italicRange.Item2);

                fixedItalics.Add(Tuple.Create(italicRange.Item1 - count1, italicRange.Item2 - count2));
            }

            var fixedStrikeThroughs = new List<Tuple<int, int>>();
            foreach (var strikeThroughRange in info.StrikeThroughs)
            {
                var count1 = info.Bolds.Count(r => r.Item1 < strikeThroughRange.Item1) + info.Bolds.Count(r => r.Item2 < strikeThroughRange.Item1)
                    + info.Italics.Count(r => r.Item1 < strikeThroughRange.Item1) + info.Italics.Count(r => r.Item2 < strikeThroughRange.Item1)
                    + info.StrikeThroughs.Count(r => r.Item1 < strikeThroughRange.Item1) + info.StrikeThroughs.Count(r => r.Item2 < strikeThroughRange.Item1);

                var count2 = info.Bolds.Count(r => r.Item1 < strikeThroughRange.Item2) + info.Bolds.Count(r => r.Item2 <= strikeThroughRange.Item2)
                    + info.Italics.Count(r => r.Item1 < strikeThroughRange.Item2) + info.Italics.Count(r => r.Item2 <= strikeThroughRange.Item2)
                    + info.StrikeThroughs.Count(r => r.Item1 < strikeThroughRange.Item2) + info.StrikeThroughs.Count(r => r.Item2 <= strikeThroughRange.Item2);

                fixedStrikeThroughs.Add(Tuple.Create(strikeThroughRange.Item1 - count1, strikeThroughRange.Item2 - count2));
            }

            info.Text = text;
            info.Bolds = fixedBolds;
            info.Italics = fixedItalics;
            info.StrikeThroughs = fixedStrikeThroughs;

            return info;
        }
    }
}
