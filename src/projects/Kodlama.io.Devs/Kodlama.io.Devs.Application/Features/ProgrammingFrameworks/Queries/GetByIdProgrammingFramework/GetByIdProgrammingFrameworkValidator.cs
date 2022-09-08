using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetByIdProgrammingFramework;

public class GetByIdProgrammingFrameworkValidator : AbstractValidator<GetByIdProgrammingFrameworkQuery> {
    public GetByIdProgrammingFrameworkValidator() {
        RuleFor(x => x.Id).Id();
    }
}