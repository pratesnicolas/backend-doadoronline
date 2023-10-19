using FluentValidation;

namespace DoadorOnline.Application;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator() { }
}