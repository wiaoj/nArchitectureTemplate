namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
public record RegisteredDto {
    public AccessTokenDto AccessToken { get; set; }
    public RefreshTokenDto RefreshToken { get; set; }
}