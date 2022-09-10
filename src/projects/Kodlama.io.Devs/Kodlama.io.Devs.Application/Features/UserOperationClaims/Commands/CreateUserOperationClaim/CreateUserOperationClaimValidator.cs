using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class DeleteUserOperationClaimValidator : AbstractValidator<CreateUserOperationClaimCommand> {
    public DeleteUserOperationClaimValidator() {
        RuleFor(x => x.UserId).UserId();
        RuleFor(x => x.OperationClaimId).OperationClaimId();
    }
}