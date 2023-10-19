using System.Text;

namespace DoadorOnline.Application;

public static  class StringUtils
{
    public static string GerarBase64Encode(this string value)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string GerarBase64Decode(this string value)
    { 
        byte[] data = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(data);
    }

    public static string GerarUrlEncode(this string value)
    {
        return System.Web.HttpUtility.UrlEncode(value);
    }

    public static string GerarUrlDecode(this string value)
    {
        return System.Web.HttpUtility.UrlDecode(value);
    }
}
