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

            var invalidBolds = GetInvalidRanges(info.Bolds, info.Italics.Union(info.StrikeThroughs));
            var invalidItalics = GetInvalidRanges(info.Italics, info.Bolds.Union(info.StrikeThroughs));
            var invalidStrikeThroughs = GetInvalidRanges(info.StrikeThroughs, info.Bolds.Union(info.Italics));

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

            var fixedBolds = GetFixedRanges(info.Bolds, info);
            var fixedItalics = GetFixedRanges(info.Italics, info);
            var fixedStrikeThroughs = GetFixedRanges(info.StrikeThroughs, info);

            info.Text = text;
            info.Bolds = fixedBolds;
            info.Italics = fixedItalics;
            info.StrikeThroughs = fixedStrikeThroughs;

            return info;
        }

        private IEnumerable<Tuple<int, int>> GetInvalidRanges(IEnumerable<Tuple<int, int>> rangesToBeValidated, IEnumerable<Tuple<int, int>> validRanges)
        {
            var invalidRanges = new List<Tuple<int, int>>();
            foreach (var boldRange in rangesToBeValidated)
            {
                foreach (var italicRange in validRanges)
                {
                    if (italicRange.Item1 < boldRange.Item1 && boldRange.Item1 < italicRange.Item2 && italicRange.Item2 < boldRange.Item2)
                    {
                        invalidRanges.Add(boldRange);
                        break;
                    }
                }
            }

            return invalidRanges;
        }

        private IEnumerable<Tuple<int, int>> GetFixedRanges(IEnumerable<Tuple<int, int>> rangesToBeFixed, TextFormatInfo info)
        {
            var fixedRanges = new List<Tuple<int, int>>();
            foreach (var range in rangesToBeFixed)
            {
                var count1 = info.Bolds.Count(r => r.Item1 < range.Item1) + info.Bolds.Count(r => r.Item2 < range.Item1)
                    + info.Italics.Count(r => r.Item1 < range.Item1) + info.Italics.Count(r => r.Item2 < range.Item1)
                    + info.StrikeThroughs.Count(r => r.Item1 < range.Item1) + info.StrikeThroughs.Count(r => r.Item2 < range.Item1);

                var count2 = info.Bolds.Count(r => r.Item1 < range.Item2) + info.Bolds.Count(r => r.Item2 <= range.Item2)
                    + info.Italics.Count(r => r.Item1 < range.Item2) + info.Italics.Count(r => r.Item2 <= range.Item2)
                    + info.StrikeThroughs.Count(r => r.Item1 < range.Item2) + info.StrikeThroughs.Count(r => r.Item2 <= range.Item2);

                fixedRanges.Add(Tuple.Create(range.Item1 - count1, range.Item2 - count2));
            }

            return fixedRanges;
        }
    }
}
