using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class ContactUsCommandHandler : IRequestHandler<ContactUsCommand, ValidationResult>
{

    private readonly IIdentityRepository _identityRepository;
    private readonly IEmailService _emailService;

    public ContactUsCommandHandler(IIdentityRepository identityRepository, IEmailService emailService)
    {
        _identityRepository = identityRepository;
        _emailService = emailService;
    }

    public async Task<ValidationResult> Handle(ContactUsCommand request, CancellationToken cancellationToken)
    {
        _emailService.SendEmailContactUs(request.Name, request.Email, request.Message);
        return request.ValidationResult;
    }
}
