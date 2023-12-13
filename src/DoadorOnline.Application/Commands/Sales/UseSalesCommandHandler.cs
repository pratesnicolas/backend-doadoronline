using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class UseSalesCommandHandler : IRequestHandler<UseSalesPointsCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    public UseSalesCommandHandler(IIdentityRepository identityRepository)
    {
        this._identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(UseSalesPointsCommand request, CancellationToken cancellationToken)
    {
        var sale = await _identityRepository.GetSaleById(request.SaleId);

        if (sale is null)
            throw new Exception("Promoção não encontrada");

        var user = await _identityRepository.GetUserById(request.UserId);

        if(user is null)
            throw new Exception("Usuário não encontrado");

        user.UsePoints(sale.Points);

        await _identityRepository.UpdateUser(user);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;

    }
}

