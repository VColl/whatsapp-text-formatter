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
            foreach (var range in info.Bolds)
            {
                text = text.Remove(range.Item1, 1);
                text = text.Remove(range.Item2 + 1, 1);
            }

            info.Italics = _italicTextFormatter.GetIndexRanges(text);
            foreach (var range in info.Italics)
            {
                text = text.Remove(range.Item1, 1);
                text = text.Remove(range.Item2 + 1, 1);
            }

            info.StrikeThroughs = _strikeThroughTextFormatter.GetIndexRanges(text);
            foreach (var range in info.StrikeThroughs)
            {
                text = text.Remove(range.Item1, 1);
                text = text.Remove(range.Item2 + 1, 1);
            }

            var fixedItalics = new List<Tuple<int, int>>();
            foreach (var italicRange in info.Italics)
            {
                var count1 = info.StrikeThroughs.Count(r => r.Item1 < italicRange.Item1) + info.StrikeThroughs.Count(r => r.Item2 < italicRange.Item1);
                var count2 = info.StrikeThroughs.Count(r => r.Item1 < italicRange.Item2) + info.StrikeThroughs.Count(r => r.Item2 < italicRange.Item2);

                fixedItalics.Add(Tuple.Create(italicRange.Item1 - count1, italicRange.Item2 - count2));
            }

            var fixedBolds = new List<Tuple<int, int>>();
            foreach (var boldRange in info.Bolds)
            {
                var count1 = info.Italics.Count(r => r.Item1 < boldRange.Item1) + info.Italics.Count(r => r.Item2 < boldRange.Item1)
                    + info.StrikeThroughs.Count(r => r.Item1 < boldRange.Item1) + info.StrikeThroughs.Count(r => r.Item2 < boldRange.Item1);

                var count2 = info.Italics.Count(r => r.Item1 < boldRange.Item2) + info.Italics.Count(r => r.Item2 < boldRange.Item2)
                    + info.StrikeThroughs.Count(r => r.Item1 < boldRange.Item2) + info.StrikeThroughs.Count(r => r.Item2 < boldRange.Item2);

                fixedBolds.Add(Tuple.Create(boldRange.Item1 - count1, boldRange.Item2 - count2));
            }

            info.Text = text;
            info.Bolds = fixedBolds;
            info.Italics = fixedItalics;

            return info;
        }
    }
}
