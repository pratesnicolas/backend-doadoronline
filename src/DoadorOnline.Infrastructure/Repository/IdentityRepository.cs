using DoadorOnline.Domain;
using Microsoft.AspNetCore.Identity;

namespace DoadorOnline.Infrastructure;
public class IdentityRepository : IIdentityRepository
{

    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public IdentityRepository(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<User> GetUserAsync(string userName)
    {
        return new();
    }

    public async Task CreateUserAsync(User user)
    {
        await _userManager.CreateAsync(user);
        await _userManager.AddToRoleAsync(user, CustomRoleTypes.Donator);

    }

    public async void ChangePassword(User user)
    {

    }

}
