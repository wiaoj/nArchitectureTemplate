using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimCommand> {
    public UpdateOperationClaimValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.Name).Name();
    }
}