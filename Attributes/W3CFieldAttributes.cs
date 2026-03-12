using W3CParser.Convertors;

namespace W3CParser.Attributes;

abstract class W3CFieldBaseAttribute : Attribute
{
    public string FieldName { get; }
    public ITextConvertor Convertor { get; }

    protected W3CFieldBaseAttribute(string name, ITextConvertor convertor)
    {
        FieldName = name;
        Convertor = convertor;
    }
}

sealed class W3CFieldAttribute : W3CFieldBaseAttribute
{
    public W3CFieldAttribute(string name) : base(name, new StringConvertor())
    {
    }
}

sealed class W3CFieldTimeAttribute : W3CFieldBaseAttribute
{
    public W3CFieldTimeAttribute(string name) : base(name, new TimeConvertor())
    {
    }
}

sealed class W3CFieldDateAttribute : W3CFieldBaseAttribute
{
    public W3CFieldDateAttribute(string name) : base(name, new DateTimeOffsetConvertor())
    {
    }
}

sealed class W3CInt32Attribute : W3CFieldBaseAttribute
{
    public W3CInt32Attribute(string name) : base(name, new Int32Convertor())
    {
    }
}

sealed class W3CHexAttribute : W3CFieldBaseAttribute
{
    public W3CHexAttribute(string name) : base(name, new HexConvertor())
    {
    }
}
