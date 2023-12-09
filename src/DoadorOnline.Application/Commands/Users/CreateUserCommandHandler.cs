using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation;
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

        var user = Donator.Factory.NewUser(request.Name,
                                           request.Gender,
                                           request.Email,
                                           request.Cpf,
                                           request.PhoneNumber,
                                           request.BirthDate,
                                           request.UserType,
                                           request.BloodType,
                                           request.RhesusFactor);
                                          
        user.CreateNewPassword(request.Password);

        var userExist = await _identityRepository.GetUserByCpfEmail(request.Cpf, request.Email);
        if (userExist != null)
        {
            user.AddError("Usuário já cadastrado.");
            return user.ValidationResult;
        }

        await _identityRepository.CreateUserAsync(user);

        if (!user.ValidationResult.IsValid)
        {
            user.AddError("Não foi possível realizar o cadastro do usuário.");
            return user.ValidationResult;
        }

        var newAddress = Address.Factory.NewAddress(user.Id.ToString(),
                                                    request.Address.Street,
                                                    request.Address.District,
                                                    request.Address.Number,
                                                    request.Address.AddressLine2,
                                                    request.Address.Country,
                                                    request.Address.City,
                                                    request.Address.State,
                                                    request.Address.ZipCode);

        user.ChangeAddress(newAddress);

        var donationsIntentions = request.DonationType.Select(x => new DonationIntention(user.Id, x));

        await _identityRepository.AddDonationIntentions(donationsIntentions.ToList());
        await _identityRepository.AddAddress(newAddress);

        _emailService.SendEmail("Bem-vindo(a) ao Doador Online",
                                $@"Olá {user.Name}, <br><br>Você foi registrado com sucesso na nossa plataforma.",
                                request.Email);

        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
}