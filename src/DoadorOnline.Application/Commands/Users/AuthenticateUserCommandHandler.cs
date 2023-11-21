
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public AuthenticateUserCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
            return request.ValidationResult;

        var user = await _identityRepository.GetUserAsync(request.Email);

        if (user is null)
            throw new Exception("Usuário não encontrado.");

        var signIn = await _identityRepository.SignInAsync(user, request.Password);

        if (!signIn.IsValid)
            throw new Exception("E-mail ou senha incorretos.");

        return request.ValidationResult;
    }
}
