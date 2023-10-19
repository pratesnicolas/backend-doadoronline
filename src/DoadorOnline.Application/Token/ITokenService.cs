namespace DoadorOnline.Application
{
    public interface ITokenService
    {
        Task<JsonWebTokenViewModel> GenerateToken(string cpfCnpj);
    }
}