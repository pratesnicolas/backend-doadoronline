using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;
using System.Security.Principal;

namespace DoadorOnline.Application;

public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public CreatePartnerCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
    {
      /*  var partner = Partner.Factory.NewPartner(request.Name,
                                                 request.Image.ToArrayBytes(),
                                                 request.Email);

        await _identityRepository.AddPartner(partner);

        await _identityRepository.SaveChanges();*/

        return request.ValidationResult;
    }
}
