using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class AddDonationCommandHandler : IRequestHandler<AddDonationCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public AddDonationCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(AddDonationCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityRepository.GetUserById(request.UserId);
        if (user == null)  
            throw new Exception("Usuário não encontrado");

 
        var donation = Donation.Factory.NewDonation(user.Id,
                                                    request.DonationType,
                                                    "",
                                                    150,
                                                    request.DonationPlace);


        user.AddDonation(donation);

        await _identityRepository.UpdateUser(user);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
}
