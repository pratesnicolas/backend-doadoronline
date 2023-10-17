using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public CreateUserCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            return request.ValidationResult;
        }

        var user = User.Factory.NewUser(request.Name,
                                        request.Gender,
                                        request.Cpf,
                                        request.PhoneNumber,
                                        request.BirthDate,
                                        UserType.Hospital,
                                        request.Email);

        user.CreateNewPassword(request.Password);

        await _identityRepository.CreateUserAsync(user);
        
        if(!user.ValidationResult.IsValid)
        {
            return user.ValidationResult;
        }

        var newAddress = Address.Factory.NewAddress(user.Id.ToString(),
                                                    request.Address.Street,
                                                    request.Address.District,
                                                    request.Address.Number,
                                                    request.Address.Country,
                                                    request.Address.City,
                                                    request.Address.State,
                                                    request.Address.ZipCode);

        var newDonator = Donator.Factory.NewDonator(user.Id,request.BloodType);

        user.AddDonator(newDonator);
        user.ChangeAddress(newAddress);

        await _identityRepository.AddDonator(newDonator);
        await _identityRepository.AddAddress(newAddress);

        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
} 