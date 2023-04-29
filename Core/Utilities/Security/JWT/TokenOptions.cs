namespace Core.Utilities.Security.JWT;

public class TokenOptions
{
    public TokenOptions(string audience, string issuer, int accessTokenExpiration, string securityKey)
    {
        Audience = audience;
        Issuer = issuer;
        AccessTokenExpiration = accessTokenExpiration;
        SecurityKey = securityKey;
    }

    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
    
}