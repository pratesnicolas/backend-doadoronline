﻿using DoadorOnline.Domain;
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
        var user = await _userManager.Users.Include(x => x.DonationIntentions)
                                           .Include(x => x.Addresses)
                                           .Include(x => x.Donations)
                                           .SingleOrDefaultAsync(x => x.Id == userId);

        return user;
    }


    public async Task<Donator> GetUserByCpfEmail(string cpf, string email)
    {
        return await _userManager
            .Users
            .SingleOrDefaultAsync(x => x.Cpf == cpf
                                       || x.Email == email);
    }


    public async Task<List<Donator>> GetUsers(string name,
                                              DonationType? donationType,
                                              BloodType? bloodType,
                                              RHFactorType? rhFactor,
                                              UserType? userType)
    {
        var users = await _userManager.Users.Include(x => x.DonationIntentions)
                                             .Where(x => (bloodType == null || x.BloodType == bloodType)
                                                         && (rhFactor == null || x.RhesusFactor == rhFactor)
                                                         && (donationType == null || x.DonationIntentions.Any(p => p.DonationType == donationType))
                                                         && (string.IsNullOrEmpty(name) || x.Name.Contains(name.Trim()))
                                                         && (userType == null || x.UserType == userType)).ToListAsync();


        return users;

    }

    public async Task AddDonation(Donation donation)
    {
        await _context.Donations.AddAsync(donation);
    }
    public async Task<List<Donation>> GetUserDonations(string userId)
    {
        var donations = await _context.Donations.Include(x => x.User)
                                                .Where(x => x.DonatorId == userId)
                                                .ToListAsync();
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

    public async Task<List<Campaign>> GetCarouselCampaigns()
    {
        var campaigns = await _context
            .Campaigns
            .OrderByDescending(x => x.ExpirationDate)
            .Take(12)
            .ToListAsync();

        return campaigns;
    }

    public async Task<List<PartnerSale>> GetCarouselSales()
    {
        var sales = await _context
            .PartnerSales
            .Include(x => x.User)
            .Take(12)
            .ToListAsync();

        return sales;
            
    }

    public async Task<Campaign> GetCampaignById(string campaignId)
    => await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);

    public async Task<Donator> GetUserClaims(string userName)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        return user;
    }

    public async Task<IList<string>> GetUserRoles(Donator user)
      => await _userManager.GetRolesAsync(user);

    public async Task<ValidationResult> SignInAsync(Donator user, string password)
    {
        var sign = await this._signInManager.PasswordSignInAsync(user,
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

    public async Task UpdateUser(Donator user)
    {
        await _userManager.UpdateAsync(user);
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

    public async Task<List<PartnerSale>> GetSales()
       => await _context.PartnerSales.Include(x => x.User).ToListAsync();

    public async Task AddSale(PartnerSale sale)
      => await _context.PartnerSales.AddAsync(sale);

    public Task DeleteSale(PartnerSale sale)
    {   
        _context.PartnerSales.Remove(sale);
        return Task.CompletedTask;
    }

    public async Task<PartnerSale> GetSaleById(string saleId)
    {
        return await _context.PartnerSales
                             .Include(x => x.User)
                             .FirstOrDefaultAsync(x => x.Id == saleId);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
