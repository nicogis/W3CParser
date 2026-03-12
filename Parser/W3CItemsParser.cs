using W3CParser.Model;

namespace W3CParser.Parser;

sealed class W3CItemsParser
{
    public static W3CEvent Parse(string line, W3CFieldMap fieldMap)
    {
        var returnValue = new W3CEvent();
        var fieldValueIndex = 0;

        foreach (var fieldValue in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (fieldMap.TryGetValue(fieldValueIndex, out var fieldInfo))
            {
                fieldInfo.FieldInfo.SetValue(returnValue, fieldInfo.Convertor.Convert(fieldValue));
            }

            fieldValueIndex += 1;
        }

        return returnValue;
    }
}
