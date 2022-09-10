
using FluentValidation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimValidator : AbstractValidator<CreateOperationClaimCommand> {
    public CreateOperationClaimValidator() {
        RuleFor(x => x.Name).Name();
    }
}