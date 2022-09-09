namespace Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;
public class RefreshTokenDto {
    public Guid UserId { get; set; }
    public String Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public String CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public String? RevokedByIp { get; set; }
    public String? ReplacedByToken { get; set; }

    public String? ReasonRevoked { get; set; }
}