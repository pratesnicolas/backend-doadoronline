using Microsoft.AspNetCore.Http;

namespace DoadorOnline.Application;

public static class IFormFileExtensions
{
    public static byte[] ToArrayBytes(this IFormFile formFile)
    {
        if (formFile is null)
            return null;

        using var ms = new MemoryStream();
        formFile.CopyTo(ms);
        var fileBytes = ms.ToArray();
        return fileBytes;
    }

}
