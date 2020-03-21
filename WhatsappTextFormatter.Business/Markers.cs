using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    internal static class Markers
    {
        public const string Bold = "*";
        public const string Italic = "_";
        public const string StrikeThrough = "~";

        public static ICollection<string> All = new HashSet<string>
        {
            Bold,
            Italic,
            StrikeThrough
        };
    }
}
