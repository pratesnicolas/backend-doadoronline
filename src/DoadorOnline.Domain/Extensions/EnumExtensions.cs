using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DoadorOnline.Domain;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        Type enumType = value.GetType();
        MemberInfo member = enumType.GetMember(value.ToString())[0];
        var attr = member.GetCustomAttribute<DisplayAttribute>();
        return attr != null ? attr.Name : value.ToString();
    }
}
