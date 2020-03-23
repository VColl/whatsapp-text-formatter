using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    public interface ITextFormatter
    {
        char Marker { get; }
        int FirstMarkerIndex { get; set; }

        IEnumerable<int> GetMarkerIndexes(TextFormatInfo info);
        int GetCountMarkersBefore(TextFormatInfo info, int index);
        ICollection<Tuple<int, int>> GetRanges(TextFormatInfo info);
        void SetRanges(TextFormatInfo info, ICollection<Tuple<int, int>> ranges);
    }
}
