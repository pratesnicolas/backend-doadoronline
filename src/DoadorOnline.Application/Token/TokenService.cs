using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoadorOnline.Application;
public class TokenService : ITokenService
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IHttpContextAccessor _accessor;

    public TokenService(IIdentityRepository usuarioRepository,
                               IHttpContextAccessor acessor,
                               IConfiguration configuration)
    {
        this._identityRepository = usuarioRepository;
        this._accessor = acessor; ;
    }

    public async Task<JsonWebTokenViewModel> GenerateToken(string cpfCnpj)
    {
        var user = await this._identityRepository.GetUserAsync(cpfCnpj);
        var roles = await this._identityRepository.GetUserRoles(user);

        var identityClaims = this.GetUserClaims(roles, user);
        var encodedToken = this.EncryptToken(identityClaims);

        return new(encodedToken);
    }

    private ClaimsIdentity GetUserClaims(IList<string> roles,
                                              Donator user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow)),
            new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow), ClaimValueTypes.Integer64)
        };

        foreach (var userRole in roles)
            claims.Add(new Claim(ClaimTypes.Role, userRole));

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        return identityClaims;
    }

    private string EncryptToken(ClaimsIdentity identityClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var requestHttpContextAccessor = this._accessor.HttpContext.Request;
        var currentIssuer = $"{requestHttpContextAccessor.Scheme}://{requestHttpContextAccessor.Host}";

        var symmetricKey = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = currentIssuer,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                                                        SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandler.WriteToken(token);
    }

    private static string ToUnixEpochDate(DateTime date)
    {
        var resultDate = date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var resultLong = (long)Math.Round(resultDate.TotalSeconds);
        var resultString = resultLong.ToString();
        return resultString;
    }
}
