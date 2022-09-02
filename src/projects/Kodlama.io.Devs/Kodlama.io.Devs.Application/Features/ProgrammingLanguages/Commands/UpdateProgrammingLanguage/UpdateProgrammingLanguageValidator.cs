using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

internal class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand> {
	public UpdateProgrammingLanguageValidator() {
		RuleFor(x => x.Id).Id();
		RuleFor(x => x.Name).Name();
	}
}