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

        private IEnumerable<Tuple<int, int>> GetIndexRanges(string text, int startIndex, int boldCounter)
        {
            int indexOfFirstAsterisk = GetIndexOfFirstAsterisk(text, startIndex);
            if (indexOfFirstAsterisk == -1)
                yield break;

            int indexOfSecondAsterisk = GetIndexOfSecondAsterisk(text, indexOfFirstAsterisk + 1);
            if (indexOfSecondAsterisk == -1)
                yield break;

            yield return Tuple.Create(indexOfFirstAsterisk - 2 * boldCounter, indexOfSecondAsterisk - 2 * (boldCounter + 1));

            foreach (var range in GetIndexRanges(text, indexOfSecondAsterisk + 1, boldCounter + 1))
                yield return range;
        }

        private int GetIndexOfFirstAsterisk(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfFirstAsterisk = text.IndexOf(_marker, startIndex);

            if (!text.Substring(indexOfFirstAsterisk + 1).Contains(_marker))
                return -1;

            if ((indexOfFirstAsterisk != 0 && !char.IsWhiteSpace(text[indexOfFirstAsterisk - 1]))
                || (char.IsWhiteSpace(text[indexOfFirstAsterisk + 1])))
                return GetIndexOfFirstAsterisk(text, indexOfFirstAsterisk + 1);

            return indexOfFirstAsterisk;
        }

        private int GetIndexOfSecondAsterisk(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains(_marker))
                return -1;

            int indexOfSecondAsterisk = text.IndexOf(_marker, startIndex);

            if (text.Length == indexOfSecondAsterisk + 1)
                return indexOfSecondAsterisk;

            if (char.IsWhiteSpace(text[indexOfSecondAsterisk + 1]))
                return indexOfSecondAsterisk;

            if (text[indexOfSecondAsterisk + 1].ToString() == _marker)
                return indexOfSecondAsterisk;

            return GetIndexOfSecondAsterisk(text, indexOfSecondAsterisk + 1);
        }
    }
}
