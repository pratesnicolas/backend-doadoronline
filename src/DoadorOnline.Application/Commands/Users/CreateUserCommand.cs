using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class CreateUserCommand : IRequest<ValidationResult>
{
    public string Name { get; set; }
    public string Password { get; set; }    
    public string Email { get; set; }
    public string Cnpj { get; set; }
    public string Cpf { get; set; }
    public GenderEnum Gender { get; set; }
    public BloodType BloodType { get; set; }

    public ValidationResult ValidationResult { get; set; }

    public bool IsValid()
    {
        this.ValidationResult = new CreateUserCommandValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }

}
