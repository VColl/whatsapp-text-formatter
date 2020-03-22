using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public class FullTextFormatter
    {
        private int _firstBoldMarkerIndex;
        private int _firstItalicMarkerIndex;
        private int _firstStrikeThroughMarkerIndex;

        public TextFormatInfo GetTextFormatInfo(string text)
        {
            _firstBoldMarkerIndex = -1;
            _firstItalicMarkerIndex = -1;
            _firstStrikeThroughMarkerIndex = -1;

            var info = new TextFormatInfo();

            for (int i = 0; i < text.Length; i++)
                AddRange(info, text[i], i, text);

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

        private void AddRange(TextFormatInfo info, char character, int index, string text)
        {
            if (!Markers.All.Contains(character))
                return;

            ICollection<Tuple<int, int>> ranges = GetRanges(info, character);
            int firstMarkerIndexCandidate = GetFirstMarkerIndexCandidate(character);

            if (firstMarkerIndexCandidate == -1)
            {
                if (IsValidFirstMarker(character, index, text))
                {
                    UpdateFirstMarkerIndex(character, index);
                }
            }

            else if (IsValidSecondMarker(character, index, text))
            {
                ranges.Add(Tuple.Create(firstMarkerIndexCandidate, index));
                if (firstMarkerIndexCandidate <= _firstBoldMarkerIndex)
                    _firstBoldMarkerIndex = -1;

                if (firstMarkerIndexCandidate <= _firstItalicMarkerIndex)
                    _firstItalicMarkerIndex = -1;

                if (firstMarkerIndexCandidate <= _firstStrikeThroughMarkerIndex)
                    _firstStrikeThroughMarkerIndex = -1;
            }
        }

        private ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info, char character)
        {
            switch (character)
            {
                case Markers.Bold:
                    return info.Bolds;
                case Markers.Italic:
                    return info.Italics;
                case Markers.StrikeThrough:
                    return info.StrikeThroughs;
                default:
                    return null;
            }
        }

        private int GetFirstMarkerIndexCandidate(char character)
        {
            switch (character)
            {
                case Markers.Bold:
                    return _firstBoldMarkerIndex;
                case Markers.Italic:
                    return _firstItalicMarkerIndex;
                case Markers.StrikeThrough:
                    return _firstStrikeThroughMarkerIndex;
                default:
                    return -1;
            }
        }

        private void UpdateFirstMarkerIndex(char marker, int index)
        {
            switch (marker)
            {
                case Markers.Bold:
                    _firstBoldMarkerIndex = index;
                    return;
                case Markers.Italic:
                    _firstItalicMarkerIndex = index;
                    return;
                case Markers.StrikeThrough:
                    _firstStrikeThroughMarkerIndex = index;
                    return;
            }
        }

        private bool IsValidFirstMarker(char marker, int markerIndex, string text) =>
            (text.Length > markerIndex + 1)
            && !char.IsWhiteSpace(text[markerIndex + 1])
            && (text[markerIndex + 1] != marker || (text.Length > markerIndex + 2 && text[markerIndex + 2] != marker))
            && (markerIndex == 0
                || char.IsWhiteSpace(text[markerIndex - 1])
                || Markers.All.Except(new[] { marker }).Contains(text[markerIndex - 1]));

        private bool IsValidSecondMarker(char marker, int markerIndex, string text) =>
            !char.IsWhiteSpace(text[markerIndex - 1])
            && text[markerIndex - 1] != marker
            && (text.Length == markerIndex + 1
                || char.IsWhiteSpace(text[markerIndex + 1])
                || Markers.All.Contains(text[markerIndex + 1]));

        private ICollection<Tuple<int, int>> GetFixedRanges(IEnumerable<Tuple<int, int>> rangesToBeFixed, TextFormatInfo info)
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
