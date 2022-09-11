namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos;

public record LoginedDto {
    public AccessTokenDto AccessToken { get; set; }
    public RefreshTokenDto RefreshToken { get; set; }
}