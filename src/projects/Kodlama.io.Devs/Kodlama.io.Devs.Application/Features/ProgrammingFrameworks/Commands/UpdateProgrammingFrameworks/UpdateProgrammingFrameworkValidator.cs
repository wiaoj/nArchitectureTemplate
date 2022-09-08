using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.UpdateProgrammingFrameworks;

public class UpdateProgrammingFrameworkValidator :AbstractValidator<UpdateProgrammingFrameworkCommand> {
    public UpdateProgrammingFrameworkValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.Name).Name();
        RuleFor(x => x.Version).Version();
        RuleFor(x => x.Tag).Tag();
        RuleFor(x => x.ProgrammingLanguageId).ProgrammingLanguageId();
    }
}
