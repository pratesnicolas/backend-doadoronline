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
                                        request.Cnpj,
                                        request.BloodType);
      
        await _identityRepository.CreateUserAsync(user);

        return user.ValidationResult;
    }
} 