﻿using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class PasswordRecoveryCommandHandler : IRequestHandler<PasswordRecoveryCommand, ValidationResult>
{
    private readonly IIdentityRepository _identidadeRepository;
    private readonly IEmailService _emailService;

    public PasswordRecoveryCommandHandler(IIdentityRepository identidadeRepository,
                                          IEmailService emailService)
    {
        _identidadeRepository = identidadeRepository;
        _emailService = emailService;
    }

    public async Task<ValidationResult> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            return request.ValidationResult;
        }

        var user = await _identidadeRepository.GetUserAsync(request.Email) ?? throw new Exception("Usuário não encontrado.");

        var recoveryToken = await _identidadeRepository.RecoverPassword(user);

        var token = recoveryToken.GerarUrlEncode().GerarBase64Encode();

        _emailService.SendEmail("Recuperação de senha",
                                $@"Click no link a seguir para realizar a alteração da sua senha: https://frontend-doador-online.vercel.app/password-recovery/{user.UserName}/{token}", 
                                user.UserName);

        return request.ValidationResult;
    }
}
