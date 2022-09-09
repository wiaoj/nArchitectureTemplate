namespace Core.Security.JWT;

public class TokenOptions {
    public String Audience { get; set; }
    public String Issuer { get; set; }
    public Int32 AccessTokenExpiration { get; set; }
    public String SecurityKey { get; set; }
    public Int32 RefreshTokenTTL { get; set; }
}