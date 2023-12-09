using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class UpdatePersonalDataCommandHandler : IRequestHandler<UpdatePersonalDataCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public UpdatePersonalDataCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(UpdatePersonalDataCommand request, CancellationToken cancellationToken)
    {

        var user = await _identityRepository.GetUserById(request.UserId);

        if (user is null) 
            throw new Exception("Usuário não encontrado");
    
        user.UpdatePersonalData(request.Name,
                                request.BirthDate,
                                request.Gender,
                                request.PhoneNumber,
                                request.Email);

        await _identityRepository.UpdateUser(user);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;

    }
}
