using System.Reflection;
using W3CParser.Attributes;
using W3CParser.Model;

namespace W3CParser.Parser;

sealed class W3CFieldsParser
{
    sealed class FieldBinding
    {
        public W3CFieldBaseAttribute Attribute { get; }
        public FieldInfo FieldInfo { get; }

        public FieldBinding(W3CFieldBaseAttribute attribute, FieldInfo fieldInfo)
        {
            Attribute = attribute;
            FieldInfo = fieldInfo;
        }
    }

    static readonly IReadOnlyDictionary<string, FieldBinding> KnownFields =
        typeof(W3CEvent)
            .GetFields(BindingFlags.Instance | BindingFlags.Public)
            .Select(fieldInfo => new
            {
                FieldInfo = fieldInfo,
                Attribute = fieldInfo.GetCustomAttributes<W3CFieldBaseAttribute>(false).FirstOrDefault()
            })
            .Where(x => x.Attribute is not null)
            .ToDictionary(
                x => x.Attribute!.FieldName,
                x => new FieldBinding(x.Attribute!, x.FieldInfo),
                StringComparer.OrdinalIgnoreCase);

    public W3CFieldMap Parse(string line)
    {
        var fieldMap = new W3CFieldMap();
        var lineFields = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (var index = 0; index < lineFields.Length; index++)
        {
            if (KnownFields.TryGetValue(lineFields[index], out var binding))
            {
                fieldMap.Add(index, binding.Attribute.Convertor, binding.FieldInfo);
            }
        }

        return fieldMap;
    }
}
