
using DoadorOnline.Domain;

namespace DoadorOnline.Application;
public class GetUserRequestDTO
{
    public string? Name { get; set; }
    public DonationType? DonationType { get; set; }
    public BloodType? BloodType { get; set; }
    public RHFactorType? RHFactor { get; set; }
}

