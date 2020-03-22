using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public class FullTextFormatter
    {
        private int _firstBoldMarkerIndex = -1;
        private int _firstItalicMarkerIndex = -1;
        private int _firstStrikeThroughMarkerIndex = -1;

        public TextFormatInfo GetTextFormatInfo(string text)
        {
            var info = new TextFormatInfo();

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                if (character == Markers.Bold)
                {
                    if (_firstBoldMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            _firstBoldMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.Bolds.Add(Tuple.Create(_firstBoldMarkerIndex, i));
                        if (_firstBoldMarkerIndex < _firstItalicMarkerIndex)
                            _firstItalicMarkerIndex = -1;

                        if (_firstBoldMarkerIndex < _firstStrikeThroughMarkerIndex)
                            _firstStrikeThroughMarkerIndex = -1;

                        _firstBoldMarkerIndex = -1;
                    }

                }

                if (character == Markers.Italic)
                {
                    if (_firstItalicMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            _firstItalicMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.Italics.Add(Tuple.Create(_firstItalicMarkerIndex, i));
                        if (_firstItalicMarkerIndex < _firstBoldMarkerIndex)
                            _firstBoldMarkerIndex = -1;

                        if (_firstItalicMarkerIndex < _firstStrikeThroughMarkerIndex)
                            _firstStrikeThroughMarkerIndex = -1;

                        _firstItalicMarkerIndex = -1;
                    }
                }

                if (character == Markers.StrikeThrough)
                {
                    if (_firstStrikeThroughMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            _firstStrikeThroughMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.StrikeThroughs.Add(Tuple.Create(_firstStrikeThroughMarkerIndex, i));
                        if (_firstStrikeThroughMarkerIndex < _firstBoldMarkerIndex)
                            _firstBoldMarkerIndex = -1;

                        if (_firstStrikeThroughMarkerIndex < _firstItalicMarkerIndex)
                            _firstItalicMarkerIndex = -1;

                        _firstStrikeThroughMarkerIndex = -1;
                    }
                }
            }

            var indexesToBeRemoved = info.Bolds.SelectMany(r => new[] { r.Item1, r.Item2 })
                .Union(info.Italics.SelectMany(r => new[] { r.Item1, r.Item2 }))
                .Union(info.StrikeThroughs.SelectMany(r => new[] { r.Item1, r.Item2 }))
                .OrderBy(i => i);

            int counter = 0;
            foreach (var index in indexesToBeRemoved)
                text = text.Remove(index - counter++, 1);

            info.Text = text;
            info.Bolds = GetFixedRanges(info.Bolds, info);
            info.Italics = GetFixedRanges(info.Italics, info);
            info.StrikeThroughs = GetFixedRanges(info.StrikeThroughs, info);

            return info;
        }

        private bool IsValidFirstMarker(char marker, int markerIndex, string text) =>
            (text.Length > markerIndex + 1)
            && !char.IsWhiteSpace(text[markerIndex + 1])
            && (markerIndex == 0
                || char.IsWhiteSpace(text[markerIndex - 1])
                || Markers.All.Except(new[] { marker }).Contains(text[markerIndex - 1]));

        private bool IsValidSecondMarker(int markerIndex, string text) =>
            text.Length == markerIndex + 1
            || char.IsWhiteSpace(text[markerIndex + 1])
            || Markers.All.Contains(text[markerIndex + 1]);

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
