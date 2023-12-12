using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;


namespace DoadorOnline.Application;

public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;

    public DeleteSaleCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<ValidationResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _identityRepository.GetSaleById(request.SaleId);

        if (sale == null) {
            throw new Exception("Promoção não encontrada");
        }

        await _identityRepository.DeleteSale(sale);
        await _identityRepository.SaveChanges();

        return request.ValidationResult;

    }
}

