namespace DoadorOnline.Application;

public static class ByteExtensions
{
    public static string ToBase64String(this byte[] byteArray)
    {
        return byteArray is null ? string.Empty : Convert.ToBase64String(byteArray) ;
    }

}
