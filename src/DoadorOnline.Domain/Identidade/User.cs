using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace DoadorOnline.Domain;

public class User : IdentityUser
{
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public GenderEnum Gender { get; private set; }
    public BloodType BloodType { get; private set; }

    public UserType UserType { get; private set; }

    public Address Address { get; private set; }
    public Donation Donation { get; set; }
    public Donator Donator { get; private set; }

    public int Points { get; private set; }
    public string Cpf { get; private set; }

    #region EF Relationships

    public ICollection<Address> Addresses => this._addresses;
    private readonly List<Address> _addresses = new();
    public ICollection<Donation> Donations => this._donations;
    private readonly List<Donation> _donations = new();

    public ICollection<Donator> Donators => this._donators;
    private readonly List<Donator> _donators = new();

    #endregion
    public User() { }

    public User(string name,
                GenderEnum gender,
                string cpf,
                string phoneNumber,
                UserType userType,
                string email,
                DateTime birthDate)

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
    }

    public void AdicionarErro(string erro)
      => this.ValidationResult.Errors.Add(new ValidationFailure("", erro));

    public void AddDonator(Donator donator) => Donator = donator;
    public void ChangeAddress(Address address) => Address = address;

    public void CreateNewPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return;

        base.SecurityStamp = Guid.NewGuid().ToString();
        base.ConcurrencyStamp = Guid.NewGuid().ToString();

        var pass = new PasswordHasher<User>();
        base.PasswordHash = pass.HashPassword(this, password);
    }

    public static class Factory
    {
        public static User NewUser(string name,
                                   GenderEnum gender,
                                   string cpf,
                                   string phoneNumber,
                                   DateTime birthDate,
                                   UserType userType,
                                   string email)

        {
            return new(name,
                       gender,
                       cpf,
                       phoneNumber,
                       userType,
                       email,
                       birthDate);

        }
    }
}
