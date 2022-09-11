namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos;

public record AccessTokenDto {
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}