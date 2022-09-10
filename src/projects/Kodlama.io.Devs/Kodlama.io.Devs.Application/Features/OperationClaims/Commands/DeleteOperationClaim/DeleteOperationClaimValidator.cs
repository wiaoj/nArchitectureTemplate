using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimValidator : AbstractValidator<DeleteOperationClaimCommand> {
    public DeleteOperationClaimValidator() {
        RuleFor(x => x.Id).Id();
    }
}