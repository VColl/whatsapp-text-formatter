using System;
using System.Collections.Generic;

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

            info.Text = text;
            return info;
        }

        
    }
}
