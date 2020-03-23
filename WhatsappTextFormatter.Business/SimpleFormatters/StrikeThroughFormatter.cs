using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business.SimpleFormatters
{
    internal class StrikeThroughFormatter : TextFormatter
    {
        public override char Marker => Markers.StrikeThrough;

        public override ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info) =>
            info.StrikeThroughs;

        public override void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges) =>
            info.StrikeThroughs = ranges;
    }
}
