using FluentValidation;

namespace DoadorOnline.Application;

public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserValidator()
    {

    }
}
