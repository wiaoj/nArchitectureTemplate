namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;

public class AccessTokenDto {
    public String Token { get; set; }
    public DateTime Expiration { get; set; }
}