using DoadorOnline.Domain;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    void ChangePassword(User user);
    Task CreateUserAsync(User user);

    Task AddDonator(Donator donator);

    Task AddAddress(Address address);   
    Task<User> GetUserAsync(string userName);
    Task SaveChanges();
}