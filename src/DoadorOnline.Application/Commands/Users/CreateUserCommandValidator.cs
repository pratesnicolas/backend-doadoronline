using FluentValidation;

namespace DoadorOnline.Application;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator() 
    {

        this.RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome deve ser informado.");
   
    }
}