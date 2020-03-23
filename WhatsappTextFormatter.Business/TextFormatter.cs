using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    internal abstract class TextFormatter : ITextFormatter
    {
        public static ITextFormatter Dummy = new DummyTextFormatter();

        public int FirstMarkerIndex { get; set; } = -1;

        public int GetCountMarkersBefore(TextFormatInfo info, int index) =>
            GetRanges(info).Count(r => r.Item1 < index) + GetRanges(info).Count(r => r.Item2 < index);

        public IEnumerable<int> GetMarkerIndexes(TextFormatInfo info) =>
            GetRanges(info)
            .SelectMany(r => new[] { r.Item1, r.Item2 });

        public abstract char Marker { get; }
        public abstract ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info);
        public abstract void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges);

        private class DummyTextFormatter : ITextFormatter
        {
            public char Marker => ' ';
            public int FirstMarkerIndex { get; set; }

            public int GetCountMarkersBefore(TextFormatInfo info, int index) => 0;
            public IEnumerable<int> GetMarkerIndexes(TextFormatInfo info) => Enumerable.Empty<int>();
            public ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info) => new Tuple<int, int>[] { };
            public void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges) { }
        }
    }
}
