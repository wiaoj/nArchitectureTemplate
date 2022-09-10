using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.CreateProgrammingFramework;

public class CreateUserOperationClaimValidator : AbstractValidator<CreateProgrammingFrameworkCommand> {
    public CreateUserOperationClaimValidator() {
        RuleFor(x => x.Name).Name();
        RuleFor(x => x.Version).Version();
        RuleFor(x => x.Tag).Tag();
        RuleFor(x => x.ProgrammingLanguageId).ProgrammingLanguageId();
    }
}