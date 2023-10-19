using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DoadorOnline.BrasilApiService;

public class BrasilApiService : IBrasilApiService
{
    private readonly HttpClient _httpClient;

    public BrasilApiService(HttpClient httpClient, IOptions<BrasilApiSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.BaseUrl);
    }

    public async Task<CepResponseDTO> GetAddressByCep(int cep)
    {
        var response = await this._httpClient.GetAsync($"api/cep/v2/{cep}");
        var result = await response.Content.ReadAsStringAsync();
        var dados = JsonSerializer.Deserialize<CepResponseDTO>(result);
        dados.IsSuccess = response.IsSuccessStatusCode;

        return dados;
    }
}
