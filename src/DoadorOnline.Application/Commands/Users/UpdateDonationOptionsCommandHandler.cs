using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;
public class UpdateDonationOptionsCommandHandler : IRequestHandler<UpdateDonationOptionsCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public UpdateDonationOptionsCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(UpdateDonationOptionsCommand request, CancellationToken cancellationToken)
    {

        var usuario = await _identityRepository.GetUserById(request.UserId);

        if (usuario is null)
            throw new Exception("Usuário não existente.");

        var listDonationIntentions = new List<DonationIntention>();

        if (request.IsBloodDonator)
            listDonationIntentions.Add(DonationIntention.Factory.NewBloodDonationIntention(usuario.Id));
        if (request.IsOrganDonator)
            listDonationIntentions.Add(DonationIntention.Factory.NewOrgansDonationIntention(usuario.Id));
        if (request.IsBoneMarrowDonator)
            listDonationIntentions.Add(DonationIntention.Factory.NewBoneMarrowDonationIntention(usuario.Id));

        usuario.UpdateDonationsIntentions(listDonationIntentions);
        usuario.UpdateBloodInfo(request.BloodType, request.RHFactor);

        await _identityRepository.UpdateUser(usuario);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
}