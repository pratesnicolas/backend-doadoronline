using DoadorOnline.Domain;
using FluentValidation.Results;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    Task CreateUserAsync(Donator user);

    Task<Donator> GetUserAsync(string userName);
    Task<IList<string>> GetUserRoles(Donator user);
    Task<ValidationResult> SignInAsync(Donator user, string password);

    Task ResetPassword(Donator user,
                      string token,
                      string password);
    Task<string> RecoverPassword(Donator user);

    Task AddDonationIntentions(List<DonationIntention> donationIntentions);
    Task AddAddress(Address address);
   
    Task SaveChanges();
}