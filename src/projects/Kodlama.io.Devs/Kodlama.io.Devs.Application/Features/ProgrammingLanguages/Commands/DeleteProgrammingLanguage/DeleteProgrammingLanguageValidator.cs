using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
internal class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand> {
	public DeleteProgrammingLanguageValidator() {
		RuleFor(x => x.Id).Id();
	}
}