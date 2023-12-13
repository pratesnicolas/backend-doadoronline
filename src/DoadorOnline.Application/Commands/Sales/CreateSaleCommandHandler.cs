using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IUserService _userService;
    public CreateSaleCommandHandler(IIdentityRepository identityRepository, IUserService userService)
    {
        _identityRepository = identityRepository;
        _userService = userService;
    }

    public async Task<ValidationResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityRepository.GetUserById(_userService.GetUserId());

        if (user is null)
            throw new Exception("Usuário não encontado");
            
        if(user.UserType != UserType.Partner)
        {
            throw new Exception("Usuário não tem permissão para criar uma promoção.");
        }

        var newSale = PartnerSale.Factory.NewSale(user.Id,
                                                  user.Name,
                                                  request.Description,
                                                  request.Points);

        await _identityRepository.AddSale(newSale);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;
    }
}
