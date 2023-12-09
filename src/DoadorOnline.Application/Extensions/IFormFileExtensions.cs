using Microsoft.AspNetCore.Http;

namespace DoadorOnline.Application;

public static class IFormFileExtensions
{
    public static string ToBase64String(this IFormFile formFile)
    {
        if (formFile == null)
            return string.Empty;

        using var ms = new MemoryStream();
        formFile.CopyTo(ms);
        var fileBytes = ms.ToArray();
        string base64 = Convert.ToBase64String(fileBytes);
        return base64;
    }

}
