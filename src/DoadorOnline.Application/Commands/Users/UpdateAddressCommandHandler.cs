using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    public UpdateAddressCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityRepository.GetUserById(request.UserId);
        if (user == null)
        {
            throw new Exception("Usuário não encontrado");
        }

        user.Addresses.FirstOrDefault().UpdateAddress(request.ZipCode,
                                                      request.Street,
                                                      request.District,
                                                      request.Number,
                                                      request.AddressLine2,
                                                      request.City,
                                                      request.State);

        await _identityRepository.UpdateUser(user);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;

    }
}

