using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;

namespace DoadorOnline.Application;
public class DonationQueries : IDonationQueries
{
    private readonly IIdentityRepository _identityRepository;

    public DonationQueries(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<IEnumerable<DonatorViewModel>> GetDonators(GetUserRequestDTO request)
    {
        var donators = await _identityRepository.GetUsers(request.Name,
                                                          request.DonationType,
                                                          request.BloodType,
                                                          request.RHFactor,
                                                          UserType.Donator);


        var donatorsVM = donators.Select(x => new DonatorViewModel(x.Id,
                                                                   x.Name,
                                                                   x.Cpf,
                                                                   x.BirthDate,
                                                                   $@"{Enum.GetName(x.BloodType)}{Enum.GetName(x.RhesusFactor)}",
                                                                   x.DonationIntentions.Any(x => x.DonationType == DonationType.Blood),
                                                                   x.DonationIntentions.Any(x => x.DonationType == DonationType.BoneMarrow),
                                                                   x.DonationIntentions.Any(x => x.DonationType == DonationType.Organs)));




        return donatorsVM;
    }

    public async Task<IEnumerable<DonationViewModel>> GetUserDonations(string userId)
    {
        var donations = await _identityRepository.GetUserDonations(userId);

        var donationsVM = donations.Select(x => new DonationViewModel(x.DonationType.ToString(),
                                                                      x.DonationPlace,
                                                                      x.DateCreated,
                                                                      x.PointsEarned));
        return donationsVM;

    }

    public async Task<IEnumerable<CampaignViewModel>> GetCampaigns(string name, BloodType? bloodtype, RHFactorType? rhFactor)
    {
        var campaigns = await _identityRepository.GetCampaigns(name, bloodtype, rhFactor);

        var campaignsVM = campaigns.Select(x => new CampaignViewModel(x.Id,
                                                                      x.DoneeName,
                                                                      DateTime.Today.Year - x.DoneeBirthDate.Year,
                                                                      Enum.GetName(x.DoneeBloodType),
                                                                      Enum.GetName(x.DoneeRhFactor),
                                                                      x.Base64Image));
        return campaignsVM;

    }

    public async Task<IEnumerable<CampaignViewModel>> GetCarouselCampaigns()
    {
        var campaigns = await _identityRepository.GetCarouselCampaigns();

        var campaignsVM = campaigns.Select(x => new CampaignViewModel(x.Id,
                                                                      x.DoneeName,
                                                                      DateTime.Today.Year - x.DoneeBirthDate.Year,
                                                                      Enum.GetName(x.DoneeBloodType),
                                                                      Enum.GetName(x.DoneeRhFactor),
                                                                      x.Base64Image));
        return campaignsVM;

    }

    public async Task<CampaignDetailsViewModel> GetCampaign(string campaignId)
    {
        var campaign = await _identityRepository.GetCampaignById(campaignId);

        var campaignsVM = new CampaignDetailsViewModel(campaign.Id,
                                                       campaign.DoneeName,
                                                       DateTime.Today.Year - campaign.DoneeBirthDate.Year,
                                                       campaign.DonationPlace,
                                                       Enum.GetName(campaign.DoneeBloodType),
                                                       Enum.GetName(campaign.DoneeRhFactor),
                                                       campaign.Base64Image);
        return campaignsVM;

    }
    public async Task <UserDetailsViewModel> GetUserDetails(string userId)
    {
        var user = await _identityRepository.GetUserById(userId);

        var userDetailsVM = new UserDetailsViewModel(new PersonalDataViewModel(user.Name,
                                                                               user.Cpf,
                                                                               user.Email,
                                                                               user.BirthDate,
                                                                               user.Gender,
                                                                               user.PhoneNumber),
                                                     user.Addresses.Select(x => new AddressViewModel(x.ZipCode,
                                                                                                     x.Street,
                                                                                                     x.District,
                                                                                                     x.City,
                                                                                                     x.Number,
                                                                                                     x.AddressLine2,
                                                                                                     x.State)).ToList(),
                                                     new DonationOptionsViewModel(user.DonationIntentions.Any(x => x.DonationType == DonationType.Organs),
                                                                                  user.DonationIntentions.Any(x => x.DonationType == DonationType.Blood),
                                                                                  user.BloodType,
                                                                                  user.RhesusFactor,
                                                                                  user.DonationIntentions.Any(x => x.DonationType == DonationType.BoneMarrow)),
                                                     user.Donations.Select(x => new DonationViewModel(Enum.GetName(typeof(DonationType), x.DonationType),
                                                                                                      x.DonationPlace,
                                                                                                      x.DateCreated,
                                                                                                      x.PointsEarned)).ToList());

        return userDetailsVM;
    }
}

