namespace DoadorOnline.BrasilApiService;

public class CepResponseDTO : BrasilApiErrorDTO
{
    public string Cep { get; set; }
    public string State { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
}
