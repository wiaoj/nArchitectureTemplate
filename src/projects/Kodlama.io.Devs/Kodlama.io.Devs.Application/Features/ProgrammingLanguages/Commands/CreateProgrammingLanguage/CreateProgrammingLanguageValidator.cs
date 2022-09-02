using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
internal class CreateProgrammingLanguageValidator : AbstractValidator<CreateProgrammingLanguageCommand> {
    public CreateProgrammingLanguageValidator() {
        RuleFor(x => x.Name).Name();
    }
}