
using DoadorOnline.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace DoadorOnline.Application;

public class SalesQueries : ISalesQueries
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IHttpContextAccessor _accessor;


    public SalesQueries(IIdentityRepository identityRepository, IHttpContextAccessor accessor)
    {
        _identityRepository = identityRepository;
        _accessor = accessor;
    }

    public async Task<List<SalesViewModel>> GetSales()
    {
        var isAuthenticated = this._accessor.HttpContext != null && this._accessor.HttpContext.User.Identity.IsAuthenticated;

        var userLoggedInId = this._accessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

        var sales = await _identityRepository.GetSales();
        return sales.ToListSalesViewModel(userLoggedInId);
    }

    public async Task<IEnumerable<SalesViewModel>> GetCarouselSales()
    {
        var isAuthenticated = this._accessor.HttpContext != null && this._accessor.HttpContext.User.Identity.IsAuthenticated;

        var userLoggedInId = this._accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti
                                                                                    || x.Properties.Values.Contains(JwtRegisteredClaimNames.Jti)).Value;

        var sales = await _identityRepository.GetCarouselSales();
        return sales.ToListSalesViewModel(userLoggedInId);
    }
}
