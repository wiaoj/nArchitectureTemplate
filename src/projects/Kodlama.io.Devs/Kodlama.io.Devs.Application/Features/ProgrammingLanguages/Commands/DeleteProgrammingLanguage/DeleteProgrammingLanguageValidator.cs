using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
public class GetByIdProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand> {
	public GetByIdProgrammingLanguageValidator() {
		RuleFor(x => x.Id).Id();
	}
}