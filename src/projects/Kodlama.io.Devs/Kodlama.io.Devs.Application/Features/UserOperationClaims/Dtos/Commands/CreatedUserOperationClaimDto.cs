namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
public record CreatedUserOperationClaimDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}