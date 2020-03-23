using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public interface ITextFormatterFactory
    {
        ITextFormatter GetFormatter(char character);
        IEnumerable<int> GetAllMarkerIndexes(TextFormatInfo info);
        void FixAllRanges(TextFormatInfo info);
        void ResetAllFirstMarkerIndexes();
        void ResetAllFirstMarkerIndexes(int startIndex);
    }

    internal class TextFormatterFactory : ITextFormatterFactory
    {
        private readonly IDictionary<char, ITextFormatter> _textFormatters;

        public TextFormatterFactory(ITextFormatter[] textFormatters)
        {
            _textFormatters = new Dictionary<char, ITextFormatter>();

            foreach (var textFormatter in textFormatters)
                _textFormatters.Add(textFormatter.Marker, textFormatter);
        }

        public ITextFormatter GetFormatter(char character)
        {
            if (_textFormatters.TryGetValue(character, out var textFormatter))
                return textFormatter;

            return TextFormatter.Dummy;
        }

        public IEnumerable<int> GetAllMarkerIndexes(TextFormatInfo info) =>
            _textFormatters.Values
            .SelectMany(t => t.GetMarkerIndexes(info))
            .OrderBy(i => i);

        public void FixAllRanges(TextFormatInfo info)
        {
            var fixedRangesByFormatter = new Dictionary<ITextFormatter, ICollection<Tuple<int, int>>>();
            foreach (var textFormatter in _textFormatters.Values)
            {
                var rangesToBeFixed = textFormatter.GetRanges(info);
                var fixedRanges = new List<Tuple<int, int>>();
                foreach (var range in rangesToBeFixed)
                {
                    var count1 = _textFormatters.Values.Sum(t => t.GetCountMarkersBefore(info, range.Item1));
                    var count2 = _textFormatters.Values.Sum(t => t.GetCountMarkersBefore(info, range.Item2));

                    fixedRanges.Add(Tuple.Create(range.Item1 - count1, range.Item2 - count2 - 1));
                }

                fixedRangesByFormatter.Add(textFormatter, fixedRanges);
            }

            foreach(var kvp in fixedRangesByFormatter)
                kvp.Key.SetRanges(info, kvp.Value);
        }

        public void ResetAllFirstMarkerIndexes()
        {
            foreach (var textFormatter in _textFormatters.Values)
                    textFormatter.FirstMarkerIndex = -1;
        }

        public void ResetAllFirstMarkerIndexes(int startIndex)
        {
            foreach (var textFormatter in _textFormatters.Values)
            {
                if (startIndex <= textFormatter.FirstMarkerIndex)
                    textFormatter.FirstMarkerIndex = -1;
            }
        }
    }
}
