using System;

namespace WhatsappTextFormatter.Business
{
    public class TextFormatter
    {
        public TextFormatInfo GetTextFormatInfo(string text)
        {
            return new TextFormatInfo
            {
                Text = text
            };
        }
    }
}
