using System.Globalization;

namespace W3CParser.Convertors;

public class TimeConvertor : ITextConvertor
{
    public object Convert(string text) =>
        DateTimeOffset.ParseExact(
            text,
            "HH':'mm':'ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal);
}
