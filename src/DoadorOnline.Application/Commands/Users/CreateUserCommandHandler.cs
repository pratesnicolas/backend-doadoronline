using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IEmailService _emailService;

    public CreateUserCommandHandler(IIdentityRepository identityRepository, IEmailService emailService)
    {
        _identityRepository = identityRepository;
        _emailService = emailService;
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
            throw new Exception(user.ValidationResult.Errors[0].ToString()); 
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

        //_emailService.SendEmail();

        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
} 