using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class CreateUserCommand : IRequest<ValidationResult>
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    public BloodType BloodType { get; set; }
    public List<DonationType> UserType { get; set; }

    public AddressDTO Address { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public record AddressDTO()
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }

    public bool IsValid()
    {
        this.ValidationResult = new CreateUserCommandValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }
}
