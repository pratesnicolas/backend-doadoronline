using DoadorOnline.Domain;
using FluentValidation.Results;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    Task CreateUserAsync(Donator user);
    Task UpdateUser(Donator user);

    Task<List<Donator>> GetUsers(string name,
                                 DonationType? donationType,
                                 BloodType? bloodType,
                                 RHFactorType? rhFactor,
                                 UserType? userType);

    Task<Donator> GetUserById(string userId);
    Task<Donator> GetUserByCpfEmail(string cpf, string email);
    Task<Donator> GetUserAsync(string userName);
    Task<IList<string>> GetUserRoles(Donator user);
    Task<List<Donation>> GetUserDonations(string userId);
    Task AddDonation(Donation donation);
    Task<Campaign> GetCampaignById(string campaignId);
    Task<List<Campaign>> GetCampaigns(string name,
                                      BloodType? bloodType,
                                      RHFactorType? rhFactor);
    Task<List<Campaign>> GetCarouselCampaigns();
    Task<List<PartnerSale>> GetCarouselSales();
    Task<ValidationResult> SignInAsync(Donator user, string password);

    Task ResetPassword(Donator user,
                      string token,
                      string password);
    Task<string> RecoverPassword(Donator user);

    Task AddDonationIntentions(List<DonationIntention> donationIntentions);
    Task AddAddress(Address address);
    Task<List<PartnerSale>> GetSales();
    Task AddCampaign(Campaign campaign);
    Task<PartnerSale> GetSaleById(string saleId);
    Task DeleteSale(PartnerSale sale);
    Task SaveChanges();
}