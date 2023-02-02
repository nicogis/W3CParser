using System;
using W3CParser.Enumerators;

namespace W3CParser.Convertors
{
    public class HexConvertor : ITextConvertor
    {
        public dynamic Convert(string text)
        {
            if (long.TryParse(text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out long k))
            {
                return k;
            }
            else
            {
                return 0;
            }
                      
        }
    }
}
