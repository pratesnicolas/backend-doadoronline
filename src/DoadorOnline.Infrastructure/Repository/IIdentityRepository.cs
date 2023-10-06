using DoadorOnline.Domain;

namespace DoadorOnline.Infrastructure;
public interface IIdentityRepository
{
    void ChangePassword(User user);
    Task CreateUserAsync(User user);
    Task<User> GetUserAsync(string userName);
}