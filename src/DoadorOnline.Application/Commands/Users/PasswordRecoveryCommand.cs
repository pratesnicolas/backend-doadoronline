using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class PasswordRecoveryCommand : IRequest<ValidationResult>
{
    public string Email { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public bool IsValid()
    {
        this.ValidationResult = new PasswordRecoveryCommandValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }
}

