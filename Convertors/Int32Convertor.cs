namespace W3CParser.Convertors;

public class Int32Convertor : ITextConvertor
{
    public object Convert(string text) => System.Convert.ToInt32(text);
}
