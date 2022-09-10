using FluentValidation;
using Kodlama.io.Devs.Application.Features.Authorizations.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
public class RegisterValidator : AbstractValidator<RegisterCommand> {
    public RegisterValidator() {
        RuleFor(x => x.Register.Email).Email();
        RuleFor(x => x.Register.Password).Password();
        RuleFor(x => x.Register.FirstName).FirstName();
        RuleFor(x => x.Register.LastName).LastName();
    }
}