using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public CreateCampaignCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaignCreator = await _identityRepository.GetUserById(request.UserId) ?? throw new Exception("User not found.");

        var base64Image = string.Empty;

        var newCampaign = Campaign.Factory.NewCampaign(campaignCreator.Id,                                                     
                                                       request.DoneeName, 
                                                       request.DonationPlace,
                                                       request.DoneeBloodType,
                                                       request.DoneeBirthDate,
                                                       request.DoneeRHFactor,
                                                       base64Image);

        await _identityRepository.AddCampaign(newCampaign);

        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
}
