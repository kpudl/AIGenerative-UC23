using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.ComponentModel;

public class EnumDescriptorConverter<T> : DefaultTypeConverter
    where T : struct
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
       return GetDescription((T)value);
    }

    private string GetDescription(T status)
    {
        var field = status.GetType().GetField(status.ToString());
        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return attribute == null ? status.ToString() : attribute.Description;
    }
}