namespace DoadorOnline.BrasilApiService;

public class CepResponseDTO : BrasilApiErrorDTO
{
    public string cep { get; set; }
    public string street { get; set; }
    public string neighborhood { get; set; }
    public string city { get; set; }
    public string state { get; set; }
}
