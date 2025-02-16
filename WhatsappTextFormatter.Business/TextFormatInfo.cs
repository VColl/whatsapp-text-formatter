﻿using System;
using System.Collections.Generic;

namespace WhatsappTextFormatter.Business
{
    public class TextFormatInfo
    {
        /// <summary>
        /// The unformatted Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The collection of zero-based indexes of the bold characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> Bolds { get; set; }

        /// <summary>
        /// The collection of zero-based indexes of the italic characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> Italics { get; set; }

        /// <summary>
        /// The collection of zero-based indexes of the strike-through characters in the text.
        /// </summary>
        public ICollection<Tuple<int, int>> StrikeThroughs { get; set; }

        public TextFormatInfo()
        {
            Bolds = new List<Tuple<int, int>>();
            Italics = new List<Tuple<int, int>>();
            StrikeThroughs = new List<Tuple<int, int>>();
        }
    }
}
