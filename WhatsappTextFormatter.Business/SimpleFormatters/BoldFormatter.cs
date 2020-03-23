using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business.SimpleFormatters
{
    internal class BoldFormatter : TextFormatter
    {
        public override char Marker => Markers.Bold;

        public override ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info) =>
            info.Bolds;

        public override void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges) =>
            info.Bolds = ranges;
    }
}
