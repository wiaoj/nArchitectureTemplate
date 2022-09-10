using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Common.ValidationRulesExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> Email<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Email(1, Byte.MaxValue);
    }
    public static IRuleBuilder<T, String> Email<T>(this IRuleBuilder<T, String> ruleBuilder, Byte minimumLength, Byte maximumLength) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(minimumLength)
            .MaximumLength(maximumLength).EmailAddress();
        return options;
    }

    public static IRuleBuilder<T, String> Password<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Password(1, Byte.MaxValue);
    }
    public static IRuleBuilder<T, String> Password<T>(this IRuleBuilder<T, String> ruleBuilder, Byte minimumLength, Byte maximumLength) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(minimumLength)
            .MaximumLength(maximumLength);
        return options;
    }

    public static IRuleBuilder<T, String> FirstName<T>(this IRuleBuilder<T, String> ruleBuilder) {
        return ruleBuilder.Name(1, 256);
    }
    public static IRuleBuilder<T, String> LastName<T>(this IRuleBuilder<T, String> ruleBuilder) {
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
}