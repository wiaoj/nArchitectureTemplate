using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
public record RefreshedTokenDto {
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}