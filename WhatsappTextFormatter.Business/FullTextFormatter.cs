using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public class FullTextFormatter
    {
        public TextFormatInfo GetTextFormatInfo(string text)
        {
            int firstBoldMarkerIndex = -1;
            int firstItalicMarkerIndex = -1;
            int firstStrikeThroughMarkerIndex = -1;

            var info = new TextFormatInfo();

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                if (character == Markers.Bold)
                {
                    if (firstBoldMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            firstBoldMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.Bolds.Add(Tuple.Create(firstBoldMarkerIndex, i));
                        if (firstBoldMarkerIndex < firstItalicMarkerIndex)
                            firstItalicMarkerIndex = -1;

                        if (firstBoldMarkerIndex < firstStrikeThroughMarkerIndex)
                            firstStrikeThroughMarkerIndex = -1;

                        firstBoldMarkerIndex = -1;
                    }

                }

                if (character == Markers.Italic)
                {
                    if (firstItalicMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            firstItalicMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.Italics.Add(Tuple.Create(firstItalicMarkerIndex, i));
                        if (firstItalicMarkerIndex < firstBoldMarkerIndex)
                            firstBoldMarkerIndex = -1;

                        if (firstItalicMarkerIndex < firstStrikeThroughMarkerIndex)
                            firstStrikeThroughMarkerIndex = -1;

                        firstItalicMarkerIndex = -1;
                    }
                }

                if (character == Markers.StrikeThrough)
                {
                    if (firstStrikeThroughMarkerIndex == -1)
                    {
                        if (IsValidFirstMarker(character, i, text))
                        {
                            firstStrikeThroughMarkerIndex = i;
                            continue;
                        }
                    }

                    else if (IsValidSecondMarker(i, text))
                    {
                        info.StrikeThroughs.Add(Tuple.Create(firstStrikeThroughMarkerIndex, i));
                        if (firstStrikeThroughMarkerIndex < firstBoldMarkerIndex)
                            firstBoldMarkerIndex = -1;

                        if (firstStrikeThroughMarkerIndex < firstItalicMarkerIndex)
                            firstItalicMarkerIndex = -1;

                        firstStrikeThroughMarkerIndex = -1;
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

            var fixedBolds = GetFixedRanges(info.Bolds, info);
            var fixedItalics = GetFixedRanges(info.Italics, info);
            var fixedStrikeThroughs = GetFixedRanges(info.StrikeThroughs, info);

            info.Text = text;
            info.Bolds = fixedBolds;
            info.Italics = fixedItalics;
            info.StrikeThroughs = fixedStrikeThroughs;

            return info;
        }

        private bool IsValidFirstMarker(char marker, int markerIndex, string text) =>
            (text.Length > markerIndex + 1)
            && !char.IsWhiteSpace(text[markerIndex + 1])
            && (markerIndex == 0
                || char.IsWhiteSpace(text[markerIndex - 1])
                || Markers.All.Except(new[] { marker }).Contains(text[markerIndex - 1]));

        private bool IsValidSecondMarker(int markerIndex, string text) =>
            !char.IsWhiteSpace(text[markerIndex - 1])
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
