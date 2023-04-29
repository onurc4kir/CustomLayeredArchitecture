using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT;

public interface ITokenService
{
    AccessToken CreateToken(User user, List<OperationClaim> claims);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
}

public class JwtHelper : ITokenService
{
    private readonly TokenOptions _tokenOptions;
    private readonly IConfiguration Configuration;
    private DateTime _accessTokenExpiration;
    private IEnumerable<IConfiguration> val;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        val = Configuration.GetSection("TokenOptions").GetChildren();
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateToken(User user, List<OperationClaim> claims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions?.AccessTokenExpiration ?? 30);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        var jwt = new JwtSecurityToken(
            _tokenOptions.Issuer,
            _tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaims(user, claims),
            signingCredentials: signingCredentials);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    public RefreshToken CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = new()
        {
            UserId = user.Id,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };

        return refreshToken;
    }

    public bool ValidateRefreshToken(RefreshToken refreshToken, string ipAddress)
    {
        if (!refreshToken.IsActive) return false;
        if (refreshToken.CreatedByIp != ipAddress) return false;

        return true;
    }

    private IEnumerable<Claim> GetClaims(User user, List<OperationClaim> claims)
    {
        var jwtClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.Email, user.Email)
        };

        jwtClaims.AddRange(claims.Select(c => new Claim(ClaimTypes.Role, c.Name)));
        return jwtClaims;
    }
}