using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IEmailService _emailService;
    public ChangePasswordCommandHandler(IIdentityRepository identityRepository, IEmailService emailService)
    {
        _identityRepository = identityRepository;
        _emailService = emailService;
    }

    public async Task<ValidationResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
            return request.ValidationResult;

        var user = await _identityRepository.GetUserAsync(request.Email);

        if (user is null)
            throw new Exception("Usuário não encontrado.");

        var tokenDecoded = request.Token.GerarBase64Decode().GerarUrlDecode();

        await _identityRepository.ResetPassword(user, tokenDecoded, request.Password);

        _emailService.SendEmail("Senha alterada", "Sua senha foi alterado com sucesso.", user.Email);

        return request.ValidationResult;
    }
}
