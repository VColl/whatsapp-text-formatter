using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    internal abstract class TextFormatter
    {
        private readonly char _marker;

        public TextFormatter(char marker)
        {
            _marker = marker;
        }

        public IEnumerable<Tuple<int, int>> GetIndexRanges(string text) =>
            GetIndexRanges(text, 0);

        private IEnumerable<Tuple<int, int>> GetIndexRanges(string text, int startIndex)
        {
            int indexOfFirstMarker = GetIndexOfFirstMarker(text, startIndex);
            if (indexOfFirstMarker == -1)
                yield break;

            int indexOfSecondMarker = GetIndexOfSecondMarker(text, indexOfFirstMarker + 1);
            if (indexOfSecondMarker == -1)
                yield break;

            yield return Tuple.Create(indexOfFirstMarker, indexOfSecondMarker);

            foreach (var range in GetIndexRanges(text, indexOfSecondMarker + 1))
                yield return range;
        }

        private int GetIndexOfFirstMarker(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfFirstMarker = text.IndexOf(_marker, startIndex);

            if (!text.Substring(indexOfFirstMarker + 1).Contains(_marker))
                return -1;

            return IsValidFirstMarker(text, indexOfFirstMarker)
                ? indexOfFirstMarker
                : GetIndexOfFirstMarker(text, indexOfFirstMarker + 1);
        }

        private int GetIndexOfSecondMarker(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfSecondMarker = text.IndexOf(_marker, startIndex);

            return IsValidSecondMarker(text, indexOfSecondMarker)
                ? indexOfSecondMarker
                : GetIndexOfSecondMarker(text, indexOfSecondMarker + 1);
        }

        private bool IsValidFirstMarker(string text, int indexOfFirstMarker) =>
            !char.IsWhiteSpace(text[indexOfFirstMarker + 1])
            && (indexOfFirstMarker == 0
                || char.IsWhiteSpace(text[indexOfFirstMarker - 1])
                || Markers.All.Except(new[] { _marker }).Contains(text[indexOfFirstMarker - 1]));

        private bool IsValidSecondMarker(string text, int indexOfSecondMarker) =>
            text.Length == indexOfSecondMarker + 1
            || char.IsWhiteSpace(text[indexOfSecondMarker + 1])
            || Markers.All.Contains(text[indexOfSecondMarker + 1]);
    }
}
