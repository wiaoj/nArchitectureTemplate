using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.DeleteProgrammingFrameworks;

public class DeleteProgrammingFrameworkValidator : AbstractValidator<DeleteProgrammingFrameworkCommand> {
	public DeleteProgrammingFrameworkValidator() {
		RuleFor(x => x.Id).Id();
	}
}