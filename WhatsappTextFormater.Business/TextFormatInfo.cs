using System;
using System.Collections.Generic;

namespace WhatsappTextFormater.Business
{
    public class TextFormatInfo
    {
        /// <summary>
        /// The unformatted Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The collection of indexes of the bold characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> Bolds { get; set; }

        /// <summary>
        /// The collection of indexes of the italic characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> Italics { get; set; }

        /// <summary>
        /// The collection of indexes of the strike-through characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> StrikeThroughs { get; set; }
    }
}
