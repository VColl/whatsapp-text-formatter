using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    internal abstract class TextFormatter
    {
        private readonly string _marker;

        public TextFormatter(string marker)
        {
            _marker = marker;
        }

        public IEnumerable<Tuple<int, int>> GetIndexRanges(string text) =>
            GetIndexRanges(text, 0, 0);

        private IEnumerable<Tuple<int, int>> GetIndexRanges(string text, int startIndex, int markedTextCounter)
        {
            int indexOfFirstMarker = GetIndexOfFirstMarker(text, startIndex);
            if (indexOfFirstMarker == -1)
                yield break;

            int indexOfSecondMarker = GetIndexOfSecondMarker(text, indexOfFirstMarker + 1);
            if (indexOfSecondMarker == -1)
                yield break;

            yield return Tuple.Create(indexOfFirstMarker - 2 * markedTextCounter, indexOfSecondMarker - 2 * (markedTextCounter + 1));

            foreach (var range in GetIndexRanges(text, indexOfSecondMarker + 1, markedTextCounter + 1))
                yield return range;
        }

        private int GetIndexOfFirstMarker(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfFirstMarker = text.IndexOf(_marker, startIndex);

            if (!text.Substring(indexOfFirstMarker + 1).Contains(_marker))
                return -1;

            if ((indexOfFirstMarker != 0 && !char.IsWhiteSpace(text[indexOfFirstMarker - 1]))
                || (char.IsWhiteSpace(text[indexOfFirstMarker + 1])))
                return GetIndexOfFirstMarker(text, indexOfFirstMarker + 1);

            return indexOfFirstMarker;
        }

        private int GetIndexOfSecondMarker(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfSecondMarker = text.IndexOf(_marker, startIndex);

            if (text.Length == indexOfSecondMarker + 1)
                return indexOfSecondMarker;

            if (char.IsWhiteSpace(text[indexOfSecondMarker + 1]))
                return indexOfSecondMarker;

            if (text[indexOfSecondMarker + 1].ToString() == _marker)
                return indexOfSecondMarker;

            return GetIndexOfSecondMarker(text, indexOfSecondMarker + 1);
        }
    }
}
