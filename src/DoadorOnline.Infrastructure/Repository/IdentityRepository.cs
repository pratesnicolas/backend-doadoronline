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
        user.Validate(await _userManager.CreateAsync(user));

        if (!user.ValidationResult.IsValid)
            return;

        await _userManager.AddToRoleAsync(user, user.UserType.ToString());
    }

    public async Task AddDonator(Donator donator)
      => await _context.Donator.AddAsync(donator);

    public async Task AddAddress(Address address)
     => await _context.Address.AddAsync(address);

    public async void ChangePassword(User user)
    {

    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
