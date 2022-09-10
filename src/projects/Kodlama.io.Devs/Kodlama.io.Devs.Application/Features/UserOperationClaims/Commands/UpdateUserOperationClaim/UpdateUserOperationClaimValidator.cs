using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimValidator : AbstractValidator<UpdateUserOperationClaimCommand> {
    public UpdateUserOperationClaimValidator() {
        RuleFor(x => x.UserId).UserId();
        RuleFor(x => x.OperationClaimId).OperationClaimId();
    }
}