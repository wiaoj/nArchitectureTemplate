namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Queries;

public record UserOperationClaimListDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}