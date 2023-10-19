﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace DoadorOnline.Domain;

public class Donator : IdentityUser
{
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public GenderEnum Gender { get; private set; }
    public BloodType BloodType { get; private set; }
    public RHFactorType RhesusFactor { get; private set; }

    public UserType UserType { get; private set; }
    public int Points { get; private set; }
    public string Cpf { get; private set; }

    #region EF Relationships

    public ICollection<Address> Addresses => this._addresses;
    private readonly List<Address> _addresses = new();
    public ICollection<Donation> Donations => this._donations;
    private readonly List<Donation> _donations = new();

    public ICollection<DonationIntention> DonationIntentions => this._donationIntentions;
    private readonly List<DonationIntention> _donationIntentions = new();

    #endregion
    public Donator() { }

    public Donator(string name,
                   GenderEnum gender,
                   string email,
                   string cpf,
                   string phoneNumber,
                   DateTime birthDate,
                   UserType userType,
                   RHFactorType rhesusFactorType)

    {
        base.Id = Guid.NewGuid().ToString();
        Name = name;
        Gender = gender;
        Cpf = cpf;
        Email = email;
        UserName = email;
        NormalizedUserName = name;
        Email = email;
        NormalizedUserName = email;
        PhoneNumber = phoneNumber;
        UserName = Email;
        BirthDate = birthDate;
        UserType = userType;
        RhesusFactor = rhesusFactorType;
    }

    public void AdicionarErro(string erro)
      => this.ValidationResult.Errors.Add(new ValidationFailure("", erro));
    public void ChangeAddress(Address address)
    {
        this.Addresses.Add(address);
    }

    public void CreateNewPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return;

        base.SecurityStamp = Guid.NewGuid().ToString();
        base.ConcurrencyStamp = Guid.NewGuid().ToString();

        var pass = new PasswordHasher<Donator>();
        base.PasswordHash = pass.HashPassword(this, password);
    }

    public static class Factory
    {
        public static Donator NewUser(string name,
                                      GenderEnum gender,
                                      string email,
                                      string cpf,
                                      string phoneNumber,
                                      DateTime birthDate,
                                      UserType userType,
                                      RHFactorType rhesusFactorType)


        {
            return new(name,
                       gender,
                       email,
                       cpf,
                       phoneNumber,
                       birthDate,
                       userType,
                       rhesusFactorType);

        }
    }
}