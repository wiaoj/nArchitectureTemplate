using FluentValidation;
using Kodlama.io.Devs.Application.Features.Authorizations.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Queries.Login;
public class LoginValidator : AbstractValidator<LoginQuery> {
    public LoginValidator() {
        RuleFor(x => x.Login.Email).Email();
        RuleFor(x => x.Login.Password).Password();
    }
}