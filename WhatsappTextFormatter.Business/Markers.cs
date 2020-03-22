using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    internal static class Markers
    {
        public const char Bold = '*';
        public const char Italic = '_';
        public const char StrikeThrough = '~';

        public static ICollection<char> All = new HashSet<char>
        {
            Bold,
            Italic,
            StrikeThrough
        };
    }
}
