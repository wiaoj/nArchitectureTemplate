namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;

public class LoginedDto {
    public AccessTokenDto AccessToken { get; set; }
    public RefreshTokenDto RefreshToken { get; set; }
}