using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimValidator : AbstractValidator<DeleteUserOperationClaimCommand> {
    public DeleteUserOperationClaimValidator() {
        RuleFor(x => x.Id).Id();
    }
}