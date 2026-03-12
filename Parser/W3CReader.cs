using W3CParser.Model;

namespace W3CParser.Parser;

public sealed class W3CReader : IDisposable
{
    public string? Software { get; private set; }

    TextReader Reader { get; }

    public W3CReader(TextReader reader)
    {
        Reader = reader;
    }

    static string RightOf(string token, string line) => line[(token.Length + 2)..];

    void ParseHeader(string line, Action<string> fieldsBlock)
    {
        const string CommentFields = "#Fields";
        const string CommentSoftware = "#Software";

        if (line.StartsWith(CommentSoftware, StringComparison.OrdinalIgnoreCase))
        {
            Software = RightOf(CommentSoftware, line);
        }
        else if (line.StartsWith(CommentFields, StringComparison.OrdinalIgnoreCase))
        {
            fieldsBlock(RightOf(CommentFields, line));
        }
    }

    public IEnumerable<W3CEvent> Read()
    {
        var itemParser = new W3CItemsParser();
        W3CFieldMap? fieldMap = null;

        string? line;
        while ((line = Reader.ReadLine()) is not null)
        {
            if (line.StartsWith("#", StringComparison.OrdinalIgnoreCase))
            {
                ParseHeader(line, fieldsLine =>
                {
                    fieldMap = new W3CFieldsParser().Parse(fieldsLine);
                });

                continue;
            }

            if (fieldMap is null)
            {
                continue;
            }

            yield return itemParser.Parse(line, fieldMap);
        }
    }

    public void Dispose()
    {
        Reader.Dispose();
    }
}
