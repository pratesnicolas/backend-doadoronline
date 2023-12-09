using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;
public class AddDonationCommand : IRequest<ValidationResult>
{
    public string UserId { get; set; }

    public string DonationPlace { get; set; }
    public DonationType DonationType { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public bool EhValido()
    {
        this.ValidationResult = new AddDonationCommandValidation().Validate(this);
        return this.ValidationResult.IsValid;
    }
}
