using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsappTextFormatter.Business
{
    public class FullTextFormatter
    {
        private readonly ITextFormatterFactory _textFormatterFactory;

        public FullTextFormatter(ITextFormatterFactory textFormatterFactory)
        {
            _textFormatterFactory = textFormatterFactory;
        }

        public TextFormatInfo GetTextFormatInfo(string text)
        {
            _textFormatterFactory.ResetAllFirstMarkerIndexes();

            var info = new TextFormatInfo();

            for (int i = 0; i < text.Length; i++)
                ProcessCharacter(info, text[i], i, text);

            var indexesToBeRemoved = _textFormatterFactory.GetAllMarkerIndexes(info);

            int counter = 0;
            foreach (var index in indexesToBeRemoved)
                text = text.Remove(index - counter++, 1);

            _textFormatterFactory.FixAllRanges(info);
            info.Text = text;

            return info;
        }

        private void ProcessCharacter(TextFormatInfo info, char character, int index, string text)
        {
            if (!Markers.All.Contains(character))
                return;

            var textFormatter = _textFormatterFactory.GetFormatter(character);

            ICollection<Tuple<int, int>> ranges = textFormatter.GetRanges(info);

            if (textFormatter.FirstMarkerIndex == -1)
            {
                if (IsValidFirstMarker(character, index, text))
                {
                    textFormatter.FirstMarkerIndex = index;
                }
            }

            else if (IsValidSecondMarker(character, index, text))
            {
                ranges.Add(Tuple.Create(textFormatter.FirstMarkerIndex, index));
                _textFormatterFactory.ResetAllFirstMarkerIndexes(textFormatter.FirstMarkerIndex);
            }
        }

        private bool IsValidFirstMarker(char marker, int markerIndex, string text) =>
            (text.Length > markerIndex + 1)
            && !char.IsWhiteSpace(text[markerIndex + 1])
            && (text[markerIndex + 1] != marker
                || (text.Length > markerIndex + 2
                    && !Markers.All.Contains(text[markerIndex + 2])
                    && !char.IsWhiteSpace(text[markerIndex + 2])))
            && (markerIndex == 0
                || char.IsWhiteSpace(text[markerIndex - 1])
                || Markers.All.Except(new[] { marker }).Contains(text[markerIndex - 1]));

        private bool IsValidSecondMarker(char marker, int markerIndex, string text) =>
            !char.IsWhiteSpace(text[markerIndex - 1])
            && (text[markerIndex - 1] != marker
                || (markerIndex - 2 >= 0
                    && char.IsWhiteSpace(text[markerIndex - 2])))
            && (text.Length == markerIndex + 1
                || char.IsWhiteSpace(text[markerIndex + 1])
                || Markers.All.Contains(text[markerIndex + 1]));
    }
}
