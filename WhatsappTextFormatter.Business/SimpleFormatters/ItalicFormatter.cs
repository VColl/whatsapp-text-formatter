using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business.SimpleFormatters
{
    internal class ItalicFormatter : TextFormatter
    {
        public override char Marker => Markers.Italic;

        public override ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info) =>
            info.Italics;

        public override void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges) =>
            info.Italics = ranges;
    }
}
