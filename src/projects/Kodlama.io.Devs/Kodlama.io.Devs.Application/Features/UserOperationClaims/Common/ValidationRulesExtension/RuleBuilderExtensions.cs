using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Common.ValidationRulesExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, Guid> UserId<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        return ruleBuilder.Id();
    }
    public static IRuleBuilder<T, Guid> OperationClaimId<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        return ruleBuilder.Id();
    }

}