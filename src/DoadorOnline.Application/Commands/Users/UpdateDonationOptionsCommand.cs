using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class UpdateDonationOptionsCommand : IRequest<ValidationResult>
{
    public string UserId { get; set; }
    public bool IsOrganDonator { get; set; }    
    public bool IsBloodDonator { get; set; }
    public BloodType BloodType { get; set; }
    public RHFactorType RHFactor { get; set; }
    public bool IsBoneMarrowDonator { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
}
