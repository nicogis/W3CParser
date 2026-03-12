using System.Globalization;

namespace W3CParser.Convertors;

public class HexConvertor : ITextConvertor
{
    public object Convert(string text) =>
        long.TryParse(
            text,
            NumberStyles.HexNumber,
            CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0L;
}
