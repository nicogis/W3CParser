using W3CParser.Convertors;

namespace W3CParser.Attributes;

abstract class W3CFieldBaseAttribute(string name, ITextConvertor convertor) : Attribute
{
    public string FieldName { get; } = name;
    public ITextConvertor Convertor { get; } = convertor;
}

sealed class W3CFieldAttribute(string name) : W3CFieldBaseAttribute(name, new StringConvertor()) { }

sealed class W3CFieldTimeAttribute(string name) : W3CFieldBaseAttribute(name, new TimeConvertor()) { }
sealed class W3CFieldDateAttribute(string name) : W3CFieldBaseAttribute(name, new DateTimeOffsetConvertor()) { }

sealed class W3CInt32Attribute(string name) : W3CFieldBaseAttribute(name, new Int32Convertor()) { } 

sealed class W3CHexAttribute(string name) : W3CFieldBaseAttribute(name, new HexConvertor()) { }
