using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class AuthenticateUserCommand : IRequest<ValidationResult>
{
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public bool IsValid()
    {
        this.ValidationResult = new AuthenticateUserValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }

}
