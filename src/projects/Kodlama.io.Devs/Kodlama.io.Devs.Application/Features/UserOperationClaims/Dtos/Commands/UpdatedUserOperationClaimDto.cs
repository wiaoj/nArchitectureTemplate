namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;

public class UpdatedUserOperationClaimDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}