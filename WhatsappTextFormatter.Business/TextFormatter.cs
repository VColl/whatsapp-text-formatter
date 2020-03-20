using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    public class TextFormatter
    {
        public TextFormatInfo GetTextFormatInfo(string text)
        {
            var info = new TextFormatInfo
            {
                Bolds = GetBolds(text)
            };

            foreach (var range in info.Bolds)
            {
                text = text.Remove(range.Item1, 1);
                text = text.Remove(range.Item2 + 1, 1);
            }

            info.Text = text;
            return info;
        }

        private IEnumerable<Tuple<int, int>> GetBolds(string text, int startIndex = 0, int boldCounter = 0)
        {
            int indexOfFirstAsterisk = GetIndexOfFirstAsterisk(text, startIndex);
            if (indexOfFirstAsterisk == -1)
                yield break;

            int indexOfSecondAsterisk = GetIndexOfSecondAsterisk(text, indexOfFirstAsterisk + 1);
            if (indexOfSecondAsterisk == -1)
                yield break;

            yield return Tuple.Create(indexOfFirstAsterisk - 2 * boldCounter, indexOfSecondAsterisk - 2 * (boldCounter + 1));

            foreach (var range in GetBolds(text, indexOfSecondAsterisk + 1, boldCounter + 1))
                yield return range;
        }

        private static int GetIndexOfFirstAsterisk(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains("*"))
                return -1;

            int indexOfFirstAsterisk = text.IndexOf("*", startIndex);

            if (!text.Substring(indexOfFirstAsterisk + 1).Contains("*"))
                return -1;

            if (char.IsWhiteSpace(text[indexOfFirstAsterisk + 1]) || text[indexOfFirstAsterisk + 1] == '*')
                return GetIndexOfFirstAsterisk(text, indexOfFirstAsterisk + 1);

            return indexOfFirstAsterisk;
        }

        private static int GetIndexOfSecondAsterisk(string text, int startIndex)
        {
            if (!text.Substring(startIndex).Contains("*"))
                return -1;

            int indexOfSecondAsterisk = text.IndexOf("*", startIndex);

            if (text.Length > indexOfSecondAsterisk + 1 && !char.IsWhiteSpace(text[indexOfSecondAsterisk + 1]))
                return GetIndexOfSecondAsterisk(text, indexOfSecondAsterisk + 1);

            return indexOfSecondAsterisk;
        }
    }
}
