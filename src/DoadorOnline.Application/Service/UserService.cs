using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace DoadorOnline.Application;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _accessor;
    public UserService(IHttpContextAccessor accessor)
    => _accessor = accessor;
    
    public bool IsAuthenticated()
      => this._accessor.HttpContext != null && this._accessor.HttpContext.User.Identity.IsAuthenticated;

    public string GetUserId()
    => IsAuthenticated() ? this._accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti
                                                                                || x.Properties.Values.Contains(JwtRegisteredClaimNames.Jti)).Value : string.Empty;
}
