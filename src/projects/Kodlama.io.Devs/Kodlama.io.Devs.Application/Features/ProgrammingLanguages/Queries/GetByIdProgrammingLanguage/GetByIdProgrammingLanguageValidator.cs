using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
public class GetByIdProgrammingLanguageValidator : AbstractValidator<GetByIdProgrammingLanguageQuery> {
    public GetByIdProgrammingLanguageValidator() {
        RuleFor(x => x.Id).Id();
    }
}