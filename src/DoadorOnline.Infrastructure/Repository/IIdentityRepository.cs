using DoadorOnline.Domain;
using FluentValidation.Results;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    Task CreateUserAsync(Donator user);

    Task<List<Donator>> GetUsers(string name,
                                 DonationType? donationType,
                                 BloodType? bloodType,
                                 RHFactorType? rhFactor);

    Task<Donator> GetUserById(string userId);
    Task<Donator> GetUserAsync(string userName);
    Task<IList<string>> GetUserRoles(Donator user);
    Task<List<Donation>> GetUserDonations(string userId);

    Task<Campaign> GetCampaignById(string campaignId);
    Task<List<Campaign>> GetCampaigns(string name,
                                      BloodType? bloodType,
                                      RHFactorType? rhFactor);
    Task<ValidationResult> SignInAsync(Donator user, string password);

    Task ResetPassword(Donator user,
                      string token,
                      string password);
    Task<string> RecoverPassword(Donator user);

    Task AddDonationIntentions(List<DonationIntention> donationIntentions);
    Task AddAddress(Address address);

    Task AddCampaign(Campaign campaign);

    Task SaveChanges();
}