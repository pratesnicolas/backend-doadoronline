using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DoadorOnline.Application;

public class CreateCampaignCommand : IRequest<ValidationResult>
{
    public string UserId { get; set; }
    public string DoneeName { get; set; }

    public string DonationPlace { get; set; }
    public BloodType DoneeBloodType { get; set; }
    public RHFactorType DoneeRHFactor { get; set; }
    public DateTime DoneeBirthDate { get; set; }
    public IFormFile CampaignImage { get; set; }

    public ValidationResult ValidationResult { get; set; }

    public bool EhValido()
    {
        this.ValidationResult = new CreateCampaignValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }
}
