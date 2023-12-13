
using DoadorOnline.Infrastructure;

namespace DoadorOnline.Application;

public class SalesQueries : ISalesQueries
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IUserService _userService;

    public SalesQueries(IIdentityRepository identityRepository, IUserService userService)
    {
        _identityRepository = identityRepository;
        _userService = userService;
    }

    public async Task<List<SalesViewModel>> GetSales()
    {
        var sales = await _identityRepository.GetSales();
        return sales.ToListSalesViewModel(_userService.GetUserId());
    }

    public async Task<IEnumerable<SalesViewModel>> GetCarouselSales()
    { 
        var sales = await _identityRepository.GetCarouselSales();
        return sales.ToListSalesViewModel(_userService.GetUserId());
    }
}
