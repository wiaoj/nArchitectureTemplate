using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Common.ValidationRulesExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> Name<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Name(1, 1024);
    }
    public static IRuleBuilder<T, String> Name<T>(this IRuleBuilder<T, String> ruleBuilder, Byte minimumLength, Int16 maximumLength) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(minimumLength)
            .MaximumLength(maximumLength);
        return options;
    }
}