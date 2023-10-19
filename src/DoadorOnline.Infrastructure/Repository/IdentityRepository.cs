using DoadorOnline.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace DoadorOnline.Infrastructure;
public class IdentityRepository : IIdentityRepository
{

    private readonly ApplicationDbContext _context;
    private readonly UserManager<Donator> _userManager;

    public IdentityRepository(ApplicationDbContext context, UserManager<Donator> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Donator> GetUserAsync(string userName)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        return user;
    }
    public async Task<string> RecoverPassword(Donator user)
    {
        return await this._userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task ResetPassword(Donator user,
                                    string token,
                                    string password)
    {
        user.Validate(await this._userManager
                                         .ResetPasswordAsync(user,
                                                             token,
                                                             password));
    }


    public async Task CreateUserAsync(Donator user)
    {
        user.Validate(await _userManager.CreateAsync(user));

        if (!user.ValidationResult.IsValid)
            return;

        await _userManager.AddToRoleAsync(user, user.UserType.ToString());
    }

    public async Task AddDonationIntentions(List<DonationIntention> donationIntentions)
    {
        await _context.DonationIntentions.AddRangeAsync(donationIntentions);
    }

    public async Task AddAddress(Address address)
     => await _context.Addresses.AddAsync(address);

    public async void ChangePassword(Donator user)
    {

    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
