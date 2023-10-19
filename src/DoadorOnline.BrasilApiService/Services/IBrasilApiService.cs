namespace DoadorOnline.BrasilApiService;

public interface IBrasilApiService
{
    Task<CepResponseDTO> GetAddressByCep(int cep);
}
