using DoadorOnline.Domain;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    void ChangePassword(Donator user);
    Task CreateUserAsync(Donator user);


    Task AddDonationIntentions(List<DonationIntention> donationIntentions);
    Task AddAddress(Address address);
    Task<Donator> GetUserAsync(string userName);
    Task<string> RecoverPassword(Donator user);
    Task ResetPassword(Donator user,
                       string token,
                       string password);
    Task SaveChanges();
}