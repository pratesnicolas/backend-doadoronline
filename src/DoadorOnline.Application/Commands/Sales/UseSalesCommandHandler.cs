using DoadorOnline.Infrastructure;
using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class UseSalesCommandHandler : IRequestHandler<UseSalesPointsCommand, ValidationResult>
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IEmailService _emailService;
    public UseSalesCommandHandler(IIdentityRepository identityRepository, IEmailService emailService)
    {
        this._identityRepository = identityRepository;
        this._emailService = emailService;
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

        ;

        _emailService.SendEmail("Uso de Pontos",
                                $@"<br><br>Você usou {sale.Points} no parceiro {sale.SaleName}, seu codigo de uso é {new Random().Next(100000, 999999)} .",
                                user.Email);

        await _identityRepository.SaveChanges();

        return request.ValidationResult;

    }
}

