using DoadorOnline.Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoadorOnline.Infrastructure;
public class IdentityRepository : IIdentityRepository
{

    private readonly ApplicationDbContext _context;
    private readonly UserManager<Donator> _userManager;
    private readonly SignInManager<Donator> _signInManager;

    public IdentityRepository(ApplicationDbContext context,
                              UserManager<Donator> userManager,
                              SignInManager<Donator> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Donator> GetUserAsync(string userName)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        return user;
    }

    public async Task<Donator> GetUserById(string userId)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == userId);
        return user;
    }

    public async Task<List<Donator>> GetUsers(string name,
                                              DonationType? donationType,
                                              BloodType? bloodType,
                                              RHFactorType? rhFactor)
    {
        var users = await _userManager.Users.Include(x => x.DonationIntentions)
                                             .Where(x => (bloodType == null || x.BloodType == bloodType)
                                                         && (rhFactor == null || x.RhesusFactor == rhFactor)
                                                         && (donationType == null || x.DonationIntentions.Any(p => p.DonationType == donationType))
                                                         && (string.IsNullOrEmpty(name) || x.Name.Contains(name.Trim()))).ToListAsync();
                                                    

        return users;

    }
    public async Task<List<Donation>> GetUserDonations(string userId) 
    {
        var donations = await _context.Donations.Where(x => x.DonatorId == userId).ToListAsync();
        return donations;
    }

    public async Task<List<Campaign>> GetCampaigns(string name,
                                                   BloodType? bloodType,
                                                   RHFactorType? rhFactor)
    {
        var campaigns = await _context.Campaigns.Where(x => (string.IsNullOrEmpty(name) || x.DoneeName.Contains(name)) 
                                                       && (bloodType == null || x.DoneeBloodType == bloodType) 
                                                       && (rhFactor == null || x.DoneeRhFactor == rhFactor)).ToListAsync();

        return campaigns;
    }

    public async Task<Campaign> GetCampaignById(string campaignId)
    => await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);

    public async Task<Donator> GetUserClaims(string userName)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        return user;
    }

    public async Task<IList<string>> GetUserRoles(Donator user)    
      =>  await _userManager.GetRolesAsync(user);

    public async Task<ValidationResult> SignInAsync(Donator user, string password)
    {
        var sign =  await this._signInManager.PasswordSignInAsync(user,
                                                             password,
                                                             true,
                                                             true);

        if (!sign.Succeeded)
            user.AddError("User or password is invalid.");

        return user.ValidationResult;
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

    public async Task AddCampaign(Campaign campaign)
    {
        await _context.Campaigns.AddAsync(campaign);
    }

    public async Task AddAddress(Address address)
     => await _context.Addresses.AddAsync(address);

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
