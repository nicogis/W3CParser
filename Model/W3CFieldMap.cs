using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using W3CParser.Convertors;

namespace W3CParser.Model;

sealed class W3CFieldMap
{
    public sealed class W3CFieldMapInfo(ITextConvertor convertor, FieldInfo fieldInfo)
    {
        public ITextConvertor Convertor { get; } = convertor;
        public FieldInfo FieldInfo { get; } = fieldInfo;
    }

    readonly Dictionary<int, W3CFieldMapInfo> fieldDictionary = new(22);

    public bool ContainsKey(int key) => fieldDictionary.ContainsKey(key);

    public bool TryGetValue(int key, [NotNullWhen(true)] out W3CFieldMapInfo? value) =>
        fieldDictionary.TryGetValue(key, out value);

    public W3CFieldMapInfo this[int key] => fieldDictionary[key];

    public void Add(int fieldIndex, ITextConvertor convertor, FieldInfo fieldInfo)
    {
        fieldDictionary.Add(fieldIndex, new W3CFieldMapInfo(convertor, fieldInfo));
    }
}
