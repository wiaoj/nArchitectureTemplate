using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> Name<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Name(1, 256);
    }
    public static IRuleBuilder<T, String> Name<T>(this IRuleBuilder<T, String> ruleBuilder, Byte minimumLength, Int16 maximumLength) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(minimumLength)
            .MaximumLength(maximumLength);
        return options;
    }

    public static IRuleBuilder<T, Double> Version<T>(this IRuleBuilder<T, Double> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThan(Double.MaxValue);
        return options;
    }

    public static IRuleBuilder<T, String> Tag<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Tag(1, 256);
    }
    public static IRuleBuilder<T, String> Tag<T>(this IRuleBuilder<T, String> ruleBuilder, Byte minimumLength, Int16 maximumLength) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(minimumLength)
            .MaximumLength(maximumLength);
        return options;
    }

    public static IRuleBuilder<T, Guid> ProgrammingLanguageId<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }
}