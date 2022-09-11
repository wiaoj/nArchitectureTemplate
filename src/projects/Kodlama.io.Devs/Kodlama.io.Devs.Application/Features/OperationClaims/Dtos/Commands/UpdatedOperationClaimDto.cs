namespace Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;

public record UpdatedOperationClaimDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
}